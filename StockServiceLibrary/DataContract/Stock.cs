using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StockServiceLibrary.DataContract
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public string Open { get; set; }

        [DataMember]
        public string High { get; set; }

        [DataMember]
        public string Low { get; set; }

        private string _close;
        [DataMember]
        public string Close
        {
            get { return _close; }
            set
            {
                _close = value;
                if (!string.IsNullOrEmpty(value))
                {
                    CloseTyped = decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                    CloseTyped = 0;

            }
        }

        [DataMember]
        public decimal CloseTyped { get; set; }

        [DataMember]
        public string Volume { get; set; }
    }
}
