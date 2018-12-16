using System;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses.TradeHeirs
{
    public class OrderTrade
    {
        [JsonProperty("globalTradeID")]
        public ulong GlobalTradeID { get; private set; }

        [JsonProperty("tradeID")]
        public ulong TradeID { get; private set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; private set; }

        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        private readonly decimal rate;
        public decimal Rate { get => rate; }

        private readonly decimal amount;
        public decimal Amount { get => amount; }

        private readonly decimal total;
        public decimal Total { get => total; }

        private readonly decimal fee;
        public decimal Fee { get => fee; }

        [JsonProperty("date")]
        public DateTime DateTime { get; private set; }

        [JsonConstructor]
        public OrderTrade(string rate, string amount, string total, string fee)
        {
            decimal.TryParse(rate, Any, InvariantCulture, out this.rate);
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
            decimal.TryParse(total, Any, InvariantCulture, out this.total);
            decimal.TryParse(fee, Any, InvariantCulture, out this.fee);
        }
    }
}
