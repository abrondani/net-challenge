using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StockServiceController.StockServiceReference;
using System;

namespace StockServiceController
{
    public class QueueListener : IDisposable
    {
        IModel _channel;
        IConnection _connection;
        EventingBasicConsumer _consumer;

        public event EventHandler<QueueListenerEventArgs> Received;

        public void StartListening(string queue, bool? subscribeQueueListenerReceived = false)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue, false, false, false, null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += Consumer_Received;

            if (subscribeQueueListenerReceived.Value)
                Received += QueueListener_Received;

            _channel.BasicConsume(queue, true, _consumer);
        }

        void QueueListener_Received(object sender, QueueListenerEventArgs e)
        {
            StockController.SendStockMessage(e.Message, e.Exchange);
        }

        void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var queueMessage = StockController.FromByteArray(e.Body);
            Received?.Invoke(sender, new QueueListenerEventArgs(queueMessage, e.Exchange));
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
