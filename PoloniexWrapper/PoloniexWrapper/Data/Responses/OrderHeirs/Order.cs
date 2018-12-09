using System;
using System.Globalization;
using Newtonsoft.Json;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
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

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal? Amount => Convert.ToDecimal(amount, CultureInfo.InvariantCulture);

        [JsonProperty("total")]
        private readonly string total;
        public decimal? Total => Convert.ToDecimal(total, CultureInfo.InvariantCulture);
    }
}
