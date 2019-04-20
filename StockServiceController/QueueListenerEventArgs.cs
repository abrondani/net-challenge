using StockServiceController.StockServiceReference;
using System;

namespace StockServiceController
{
    public class QueueListenerEventArgs : EventArgs
    {
        public QueueListenerEventArgs(QueueMessage message)
        {
            Message = message;
        }

        public QueueListenerEventArgs(QueueMessage message, string exchange) : this(message)
        {
            Exchange = exchange;
        }

        public QueueMessage Message { get; private set; }

        public string Exchange { get; private set; }
    }
}
