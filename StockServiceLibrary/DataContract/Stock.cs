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
        private string _date;
        private string _open;
        private string _close;

        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                if (!string.IsNullOrEmpty(value))
                {
                    DateTime outValue;
                    DateTime.TryParseExact(value, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out outValue);
                    DateTyped = outValue;
                }
                else
                    DateTyped = null;
            }
        }

        [DataMember]
        public DateTime? DateTyped { get; set; }

        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public string Open
        {
            get { return _open; }
            set
            {
                _open = value;
                if (!string.IsNullOrEmpty(value))
                {
                    decimal outValue;
                    decimal.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out outValue);
                    OpenTyped = outValue;
                }
                else
                    OpenTyped = 0;
            }
        }

        public decimal OpenTyped { get; set; }

        [DataMember]
        public string High { get; set; }

        [DataMember]
        public string Low { get; set; }

        [DataMember]
        public string Close
        {
            get { return _close; }
            set
            {
                _close = value;
                if (!string.IsNullOrEmpty(value))
                {
                    decimal outValue;
                    decimal.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out outValue);
                    CloseTyped = outValue;
                }
                else
                    CloseTyped = 0;
            }
        }

        [DataMember]
        public decimal CloseTyped { get; set; }

        [DataMember]
        public string Volume { get; set; }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
