using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class Ticker
    {
        private readonly decimal last;
        public decimal LastPrice { get => last; }
        
        private readonly decimal lowestAsk;
        public decimal LowestAsk { get => lowestAsk; }
        
        private readonly decimal highestBid;
        public decimal HighestBid { get => highestBid; }

        private readonly decimal percentChange;
        public decimal PercentChange { get => percentChange; }
        
        private readonly decimal baseVolume;
        public decimal BaseVolume { get => baseVolume; }
        
        private readonly decimal quoteVolume;
        public decimal QuoteVolume { get => quoteVolume; }

        [JsonConstructor]
        public Ticker(string last, string lowestAsk, string highestBid, string percentChange, string baseVolume, string quoteVolume)
        {
            decimal.TryParse(last, Any, InvariantCulture, out this.last);
            decimal.TryParse(lowestAsk, Any, InvariantCulture, out this.lowestAsk);
            decimal.TryParse(highestBid, Any, InvariantCulture, out this.highestBid);
            decimal.TryParse(percentChange, Any, InvariantCulture, out this.percentChange);
            decimal.TryParse(baseVolume, Any, InvariantCulture, out this.baseVolume);
            decimal.TryParse(quoteVolume, Any, InvariantCulture, out this.quoteVolume);
        }
    }
}
