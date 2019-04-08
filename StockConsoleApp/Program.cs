using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.ServiceModel;
using System.Text;

namespace StockConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(StockServiceLibrary.StockService));
            host.Open();

            var stockController = new StockServiceController.StockController();
            stockController.StartListening();

            Console.WriteLine("Press <Enter> to stop the services.");
            Console.ReadLine();

            stockController.Dispose();
            host.Close();
        }
    }
}
