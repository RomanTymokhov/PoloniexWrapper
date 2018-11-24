using System;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class CompleteBalance
    {
        [JsonProperty("available")]
        private readonly string available;
        public decimal? Availabel => Convert.ToDecimal(available, CultureInfo.InvariantCulture);

        [JsonProperty("onOrders")]
        private readonly string onOrders;
        public decimal? OnOrders => Convert.ToDecimal(onOrders, CultureInfo.InvariantCulture);

        [JsonProperty("btcValue")]
        private readonly string btcValue;
        public decimal? BtcValue => Convert.ToDecimal(btcValue, CultureInfo.InvariantCulture);
    }
}
