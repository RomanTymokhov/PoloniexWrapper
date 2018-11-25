using System;
using System.Globalization;
using Newtonsoft.Json;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses
{
    public class Order
    {
        [JsonProperty("orderNumber")]
        private readonly string orderNumber;
        public ulong? OrderNumber => Convert.ToUInt64(orderNumber, CultureInfo.InvariantCulture);

        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        [JsonProperty("rate")]
        private readonly string rate;
        public decimal? Rate => Convert.ToDecimal(rate, CultureInfo.InvariantCulture);

        [JsonProperty("startingAmount")]
        private readonly string startingAmount;
        public decimal? StartingAmount => Convert.ToDecimal(startingAmount, CultureInfo.InvariantCulture);

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal? Amount => Convert.ToDecimal(amount, CultureInfo.InvariantCulture);

        [JsonProperty("total")]
        private readonly string total;
        public decimal? Total => Convert.ToDecimal(total, CultureInfo.InvariantCulture);

        [JsonProperty("date")]
        public DateTime DateTime { get; private set; }

        [JsonProperty("margin")]
        private readonly string margin;
        public decimal? Margin => Convert.ToDecimal(margin, CultureInfo.InvariantCulture);
    }
}
