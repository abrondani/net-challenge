using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

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
            SendStockMessage(e.Body, e.Exchange);
        }

        void SendStockMessage(byte[] body, string queue)
        {
            using (var wcfClient = new StockServiceReference.StockServiceClient())
            {
                var queueMessage = wcfClient.FromByteArray(body);
                var stock = wcfClient.GetStock(queueMessage.Message);
                if (stock.Success)
                    wcfClient.SendMessage($"{stock.Symbol} quote is {stock.CloseTyped.ToString("C2")} per share", queue, null, queueMessage.UserName);
                else
                    wcfClient.SendMessage(stock.ErrorMessage, queue, null, queueMessage.UserName);
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
