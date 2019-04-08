using StockServiceController;
using System.ServiceModel;
using System.ServiceProcess;

namespace BotWindowsService
{
    public partial class BotService : ServiceBase
    {
        ServiceHost _serviceHost;
        StockController stockController;

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
            stockController = new StockController();
            stockController.StartListening();
        }

        protected override void OnStart(string[] args)
        {
            StartHost();
            StartListening();
        }

        protected override void OnStop()
        {
            stockController.Dispose();
            _serviceHost.Close();
        }
    }
}
