using System;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class OpenOrder
    {
        [JsonProperty("orderNumber")]
        public ulong OrderNumber { get; private set; }

        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        private readonly decimal rate;
        public decimal Rate => rate;

        private readonly decimal amount;
        public decimal Amount => amount;

        private readonly decimal total;
        public decimal Total => total;

        private readonly decimal startingAmount;
        public decimal StartingAmount => startingAmount;

        [JsonProperty("date")]
        public DateTime DateTime { get; private set; }

        [JsonProperty("margin")]
        public byte Margin { get; private set; }

        [JsonConstructor]
        public OpenOrder(string rate, string amount, string total, string startingAmount)
        {
            decimal.TryParse(rate, Any, InvariantCulture, out this.rate);
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
            decimal.TryParse(total, Any, InvariantCulture, out this.total);
            decimal.TryParse(startingAmount, Any, InvariantCulture, out this.startingAmount);
        }
    }
}
