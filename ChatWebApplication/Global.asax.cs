using StockServiceController;
using StockServiceController.StockServiceReference;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChatWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        QueueListener _queueListener;

        protected void Application_End()
        {
            _queueListener.Dispose();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _queueListener = new QueueListener();
            _queueListener.Received += _queueListener_Received;
            _queueListener.StartListening("response");
        }

        void _queueListener_Received(object sender, QueueListenerEventArgs e)
        {
            SendMessage(e.Message);
        }

        void SendMessage(QueueMessage queueMessage)
        {
            var hubContext = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hubContext.Clients.User(queueMessage.UserName).addNewMessageToPage("Bot", queueMessage.Message, DateTime.Now.ToString("dd/MM/yy HH:mm:ss"));
        }
    }
}