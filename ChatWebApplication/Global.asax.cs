using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChatWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IModel _channel;
        IConnection _connection;
        EventingBasicConsumer _consumer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var factory = new ConnectionFactory() { HostName = "localhost" };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "response", durable: false, exclusive: false, autoDelete: false, arguments: null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: "response", autoAck: true, consumer: _consumer);
        }

        void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            using (var wcfClient = new StockServiceReference.StockServiceClient())
            {
                var queueMessage = wcfClient.FromByteArray(e.Body);
                var hubContext = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                hubContext.Clients.User(queueMessage.UserName).addNewMessageToPage("Bot", queueMessage.Message, DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
            }
        }
    }
}