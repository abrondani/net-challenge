using System;
using System.Runtime.Serialization;

namespace StockServiceLibrary.DataContract
{
    [DataContract, Serializable]
    public class QueueMessage
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
