using System;
using System.Globalization;
using Newtonsoft.Json;

using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses
{
    public class Trade
    {
        [JsonProperty("globalTradeID")]
        private readonly string globalTradeID;
        public ulong? GlobalTradeID => Convert.ToUInt64(globalTradeID, CultureInfo.InvariantCulture);

        [JsonProperty("tradeID")]
        private readonly string tradeID;
        public ulong? TradeID => Convert.ToUInt64(tradeID, CultureInfo.InvariantCulture);

        [JsonProperty("date")]
        public DateTime DateTime { get; private set; }

        [JsonProperty("rate")]
        private readonly string rate;
        public decimal? Rate => Convert.ToDecimal(rate, CultureInfo.InvariantCulture);

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal? Amount => Convert.ToDecimal(amount, CultureInfo.InvariantCulture);

        [JsonProperty("total")]
        private readonly string total;
        public decimal? Total => Convert.ToDecimal(total, CultureInfo.InvariantCulture);

        [JsonProperty("fee")]
        private readonly string fee;
        public decimal? Fee => Convert.ToDecimal(fee, CultureInfo.InvariantCulture);

        [JsonProperty("orderNumber")]
        private readonly string orderNumber;
        public ulong? OrderNumber => Convert.ToUInt64(orderNumber, CultureInfo.InvariantCulture);

        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        [JsonProperty("category")]
        public TradingAccount AccountCategory { get; private set; }
    }
}
