using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StockServiceUnitTest
{
    [TestClass]
    public class Stock
    {
        [TestMethod]
        public void TestStock()
        {
            var service = new StockServiceLibrary.StockService();
            var stock = service.GetStock("aapl.us");
            Assert.IsTrue(stock.Success, stock.ErrorMessage);
        }

        [TestMethod]
        public void TestReceiveMessages()
        {
            var test_message = "This is a test Message";
            var service = new StockServiceLibrary.StockService();

            service.SendMessage(test_message, "test_queue", null);
            var messages = service.GetMessages("test_queue");

            Assert.IsTrue(messages.Contains(test_message), "Message not received");
        }
    }
}
