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
        QueueMessage SendMessage(string message, string queue, string exchange, string user_name);

        [OperationContract]
        List<string> GetMessages(string queue);

        [OperationContract]
        byte[] ToByteArray(QueueMessage obj);

        [OperationContract]
        QueueMessage FromByteArray(byte[] data);
    }
}
