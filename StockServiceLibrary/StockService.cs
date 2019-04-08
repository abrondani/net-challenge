﻿using RabbitMQ.Client;
using StockServiceLibrary.DataContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StockServiceLibrary
{
    public class StockService : IStockService
    {
        public Stock GetStock(string stock_code)
        {
            var lines = GetFileLines(stock_code);

            var line_header = lines[0].Split(',');
            var line_body = lines[1].Split(',');

            var keyPairLine = new Dictionary<string, object>();
            for (int i = 0; i < line_header.Length; i++)
                keyPairLine.Add(line_header[i], line_body[i]);

            var stock = new Stock();
            foreach (var item in keyPairLine)
            {
                var property = typeof(Stock).GetProperty(item.Key);
                if (property != null) property.SetValue(stock, item.Value, null);
            }
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

        public void SendMessage(string message, string queue, string exchange)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue, false, false, false, null);
                if (!string.IsNullOrEmpty(exchange))
                {
                    channel.ExchangeDeclare(exchange, ExchangeType.Direct);
                    channel.QueueBind(queue, exchange, queue, null);
                }
                channel.BasicPublish(exchange ?? string.Empty, queue, body: Encoding.UTF8.GetBytes(message));
            }
        }

        List<BasicGetResult> ReceiveMessages(string queue)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
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
    }
}