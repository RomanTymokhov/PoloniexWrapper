using System;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class FillOrder
    {
        [JsonProperty("status")]
        public string Status { get; private set; }

        private readonly decimal rate;
        public decimal Rate { get => rate; }

        private readonly decimal amount;
        public decimal Amount { get => amount; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; private set; }

        [JsonProperty("date")]
        public DateTime DateTime { get; private set; }

        private readonly decimal total;
        public decimal Total { get => total; }

        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        private readonly decimal startingAmount;
        public decimal StartingAmount { get => startingAmount; }

        [JsonConstructor]
        public FillOrder(string rate, string amount, string total, string startingAmount)
        {
            decimal.TryParse(rate, Any, InvariantCulture, out this.rate);
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
            decimal.TryParse(total, Any, InvariantCulture, out this.total);
            decimal.TryParse(startingAmount, Any, InvariantCulture, out this.startingAmount);
        }
    }
}
