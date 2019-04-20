using StockServiceController;
using System.ServiceModel;
using System.ServiceProcess;

namespace BotWindowsService
{
    public partial class BotService : ServiceBase
    {
        ServiceHost _serviceHost;
        QueueListener _queueListener;

        public BotService()
        {
            InitializeComponent();
        }

        void StartHost()
        {
            _serviceHost = new ServiceHost(typeof(StockServiceLibrary.StockService));
            _serviceHost.Open();
        }

        void StartListening()
        {
            _queueListener = new QueueListener();
            _queueListener.StartListening("request", true);
        }

        protected override void OnStart(string[] args)
        {
            StartHost();
            StartListening();
        }

        protected override void OnStop()
        {
            _queueListener.Dispose();
            _serviceHost.Close();
        }
    }
}
