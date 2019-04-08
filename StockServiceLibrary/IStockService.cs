using StockServiceLibrary.DataContract;
using System.Collections.Generic;
using System.ServiceModel;

namespace StockServiceLibrary
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        Stock GetStock(string stock_cod);

        [OperationContract]
        void SendMessage(string message, string queue, string exchange);

        [OperationContract]
        List<string> GetMessages(string queue);
    }
}
