using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceController
{
    public class StockController : IDisposable
    {
        IModel _channel;
        IConnection _connection;
        EventingBasicConsumer _consumer;

        public void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "request", durable: false, exclusive: false, autoDelete: false, arguments: null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: "request", autoAck: true, consumer: _consumer);
        }

        void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var stock_code = Encoding.UTF8.GetString(body);
            SendStockMessage(stock_code, e.Exchange);
        }

        public static void SendStockMessage(string stock_code, string queue)
        {
            using (var wcfClient = new StockServiceReference.StockServiceClient())
            {
                var stock = wcfClient.GetStock(stock_code);
                if (stock.Success)
                    wcfClient.SendMessage($"{stock.Symbol} quote is {stock.CloseTyped.ToString("C2")} per share", queue, null);
                else
                    wcfClient.SendMessage(stock.ErrorMessage, queue, null);
                wcfClient.Close();
            }
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
