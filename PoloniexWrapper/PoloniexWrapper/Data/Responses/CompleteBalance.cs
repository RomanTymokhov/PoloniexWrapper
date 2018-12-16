using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class CompleteBalance
    {
        private readonly decimal available;
        public decimal Availabel { get => available; }
        
        private readonly decimal onOrders;
        public decimal OnOrders { get => onOrders; }

        private readonly decimal btcValue;
        public decimal BtcValue { get => btcValue; }

        [JsonConstructor]
        public CompleteBalance(string available, string onOrders, string btcValue)
        {
            decimal.TryParse(available, Any, InvariantCulture, out this.available);
            decimal.TryParse(onOrders, Any, InvariantCulture, out this.onOrders);
            decimal.TryParse(btcValue, Any, InvariantCulture, out this.btcValue);
        }
    }
}
