using StockServiceController;
using StockServiceLibrary;
using System;
using System.ServiceModel;

namespace StockConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(StockService));
            host.Open();

            var queueListener = new QueueListener();
            queueListener.StartListening("request", true);

            Console.WriteLine("Press <Enter> to stop the services.");
            Console.ReadLine();

            queueListener.Dispose();
            host.Close();
        }
    }
}
