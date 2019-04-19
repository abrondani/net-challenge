using RabbitMQ.Client;
using StockServiceLibrary.DataContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;

namespace StockServiceLibrary
{
    public class StockService : IStockService
    {
        public Stock GetStock(string stock_code)
        {
            List<string> lines;
            var stock = new Stock();

            try
            {
                lines = GetFileLines(stock_code);
            }
            catch (Exception)
            {
                stock.ErrorMessage = "Service unavailable";
                return stock;
            }

            var line_header = lines[0].Split(',');
            var line_body = lines[1].Split(',');

            var keyPairLine = new Dictionary<string, object>();
            for (int i = 0; i < line_header.Length; i++)
                keyPairLine.Add(line_header[i], line_body[i]);

            foreach (var item in keyPairLine)
            {
                var property = typeof(Stock).GetProperty(item.Key);
                if (property != null) property.SetValue(stock, item.Value, null);
            }

            if (stock.DateTyped.HasValue)
                stock.Success = true;
            else
                stock.ErrorMessage = "Stock code not found";

            return stock;

        }

        public List<string> GetMessages(string queue)
        {
            var result = new List<string>();
            var messages = ReceiveMessages(queue);
            foreach (var item in messages)
                result.Add(Encoding.UTF8.GetString(item.Body));
            return result;
        }

        public QueueMessage SendMessage(string message, string queue, string exchange, string user_name)
        {
            var factory = new ConnectionFactory() { HostName = ServiceConfigurationSection.Instance.RabbitMQ_HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);
                if (!string.IsNullOrEmpty(exchange))
                {
                    channel.ExchangeDeclare(exchange, ExchangeType.Direct);
                    channel.QueueBind(queue, exchange, queue, null);
                }
                var result = new QueueMessage { Message = message, UserName = user_name };
                channel.BasicPublish(exchange ?? string.Empty, queue, body: ToByteArray(result));
                return result;
            }
        }

        List<BasicGetResult> ReceiveMessages(string queue)
        {
            var factory = new ConnectionFactory() { HostName = ServiceConfigurationSection.Instance.RabbitMQ_HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var result = new List<BasicGetResult>();
                channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                BasicGetResult basicGet = null;
                do
                {
                    basicGet = channel.BasicGet(queue, true);
                    if (basicGet != null) result.Add(basicGet);
                }
                while (basicGet != null);

                return result;
            }
        }

        List<string> GetFileLines(string stock_code)
        {
            var result = new List<string>();
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create($"https://stooq.com/q/l/?s={stock_code}&f=sd2t2ohlcv&h&e=csv");
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var httpResponseStream = httpResponse.GetResponseStream())
            using (var reader = new StreamReader(httpResponseStream))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
            }
            return result;
        }

        public byte[] ToByteArray(QueueMessage obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public QueueMessage FromByteArray(byte[] data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (QueueMessage)obj;
            }
        }
    }
}