using StockServiceController.StockServiceReference;
using System.Threading.Tasks;

namespace StockServiceController
{
    public static class StockController
    {
        public static void SendStockMessage(QueueMessage queueMessage, string queue)
        {
            using (var wcfClient = new StockServiceClient())
            {
                var stock = wcfClient.GetStock(queueMessage.Message);
                if (stock.Success)
                    wcfClient.SendMessageAsync($"{stock.Symbol} quote is {stock.CloseTyped.ToString("C2")} per share", queue, null, queueMessage.UserName);
                else
                    wcfClient.SendMessageAsync(stock.ErrorMessage, queue, null, queueMessage.UserName);
                wcfClient.Close();
            }
        }

        public static async Task SendCodeMessage(string message, string userName)
        {
            using(var wcfClient = new StockServiceClient())
            {
                await wcfClient.SendMessageAsync(message, "request", "response", userName);
                wcfClient.Close();
            }
        }

        public static QueueMessage FromByteArray(byte[] body)
        {
            using (var wcfClient = new StockServiceClient())
            {
                var result = wcfClient.FromByteArray(body);
                wcfClient.Close();
                return result;
            }
        }
    }
}
