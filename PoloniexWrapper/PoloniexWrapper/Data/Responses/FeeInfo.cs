using System;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class FeeInfo
    {
        [JsonProperty("makerFee")]
        private readonly string makerFee;
        public decimal? MakerFee => Convert.ToDecimal(makerFee, CultureInfo.InvariantCulture);

        [JsonProperty("takerFee")]
        private readonly string takerFee;
        public decimal? TakerFee => Convert.ToDecimal(takerFee, CultureInfo.InvariantCulture);

        [JsonProperty("thirtyDayVolume")]
        private readonly string thirtyDayVolume;
        public decimal? ThirtyDayVolume => Convert.ToDecimal(thirtyDayVolume, CultureInfo.InvariantCulture);

        [JsonProperty("nextTier")]
        private readonly string nextTier;
        public decimal? NextTier => Convert.ToDecimal(nextTier, CultureInfo.InvariantCulture);
    }
}
