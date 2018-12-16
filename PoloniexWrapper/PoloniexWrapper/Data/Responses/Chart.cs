using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class Chart
    {
        [JsonProperty("date")]
        public ulong Timestamp { get; private set; }

        private readonly decimal high;
        public decimal High { get => high; }

        private readonly decimal low;
        public decimal Low { get => low; }

        private readonly decimal open;
        public decimal Open { get => open; }

        private readonly decimal close;
        public decimal Close { get => close; }

        private readonly decimal volume;
        public decimal Volume { get => volume; }

        private readonly decimal quoteVolume;
        public decimal QuoteVolume { get => quoteVolume; }

        private readonly decimal weightedAverage;
        public decimal WeightedAverage { get => weightedAverage; }

        [JsonConstructor]
        public Chart(string high, string low, string open, string close, string volume, string quoteVolume, string weightedAverage)
        {
            decimal.TryParse(high, Any, InvariantCulture, out this.high);
            decimal.TryParse(low, Any, InvariantCulture, out this.low);
            decimal.TryParse(open, Any, InvariantCulture, out this.open);
            decimal.TryParse(close, Any, InvariantCulture, out this.close);
            decimal.TryParse(volume, Any, InvariantCulture, out this.volume);
            decimal.TryParse(quoteVolume, Any, InvariantCulture, out this.quoteVolume);
            decimal.TryParse(weightedAverage, Any, InvariantCulture, out this.weightedAverage);
        }
    }
}
