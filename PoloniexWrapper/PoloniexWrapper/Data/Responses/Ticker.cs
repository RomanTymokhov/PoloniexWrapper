using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class Ticker
    {
        [JsonProperty("id")]
        public ushort Id { get; private set; } 

        private readonly decimal last;
        public decimal LastPrice => last; 
        
        private readonly decimal lowestAsk;
        public decimal LowestAsk => lowestAsk;
        
        private readonly decimal highestBid;
        public decimal HighestBid => highestBid;

        private readonly decimal percentChange;
        public decimal PercentChange => percentChange;
        
        private readonly decimal baseVolume;
        public decimal BaseVolume => baseVolume;
        
        private readonly decimal quoteVolume;
        public decimal QuoteVolume => quoteVolume;

        [JsonProperty("isFrozen")]
        public string IsFrozen { get; private set; }
        
        private readonly decimal high24hr;
        public decimal High24Hr => high24hr;

        private readonly decimal low24hr;
        public decimal Low24hr => low24hr;


        [JsonConstructor]
        public Ticker(string last, string lowestAsk, string highestBid, string percentChange, string baseVolume, string quoteVolume, string high24hr, string low24hr)
        {
            decimal.TryParse(last, Any, InvariantCulture, out this.last);
            decimal.TryParse(lowestAsk, Any, InvariantCulture, out this.lowestAsk);
            decimal.TryParse(highestBid, Any, InvariantCulture, out this.highestBid);
            decimal.TryParse(percentChange, Any, InvariantCulture, out this.percentChange);
            decimal.TryParse(baseVolume, Any, InvariantCulture, out this.baseVolume);
            decimal.TryParse(quoteVolume, Any, InvariantCulture, out this.quoteVolume);
            decimal.TryParse(high24hr, Any, InvariantCulture, out this.high24hr);
            decimal.TryParse(low24hr, Any, InvariantCulture, out this.low24hr);
        }
    }
}
