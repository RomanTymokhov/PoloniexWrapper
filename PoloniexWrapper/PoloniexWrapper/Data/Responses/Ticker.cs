using System;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Ticker
    {
        [JsonProperty("last")]
        private readonly string last;
        public decimal? LastPrice => Convert.ToDecimal(last, CultureInfo.InvariantCulture);

        [JsonProperty("lowestAsk")]
        private readonly string lowestAsk;
        public decimal? LowestAsk => Convert.ToDecimal(lowestAsk, CultureInfo.InvariantCulture);

        [JsonProperty("highestBid")]
        private readonly string highestBid;
        public decimal? HighestBid => Convert.ToDecimal(highestBid, CultureInfo.InvariantCulture);

        [JsonProperty("percentChange")]
        private readonly string percentChange;
        public decimal? PercentChange => Convert.ToDecimal(percentChange, CultureInfo.InvariantCulture);

        [JsonProperty("baseVolume")]
        private readonly string baseVolume;
        public decimal? BaseVolume => Convert.ToDecimal(baseVolume, CultureInfo.InvariantCulture);

        [JsonProperty("quoteVolume")]
        private readonly string quoteVolume;
        public decimal? QuoteVolume => Convert.ToDecimal(quoteVolume, CultureInfo.InvariantCulture);
    }
}
