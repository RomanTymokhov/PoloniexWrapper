using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data
{
    public class CurrencieInfo
    {
        [JsonProperty("id")]
        public uint Id { get; private set; }

        [JsonProperty("name")]
        public string CurrencieName { get; private set; }

        [JsonProperty("humanType")]
        public string HumanType { get; private set; }

        private readonly decimal txFee;
        public decimal TxFee { get => txFee; }

        [JsonProperty("minConf")]
        public ushort MinConf { get; private set; }

        [JsonProperty("depositAddress")]
        public string DepositAddress { get; private set; }

        [JsonProperty("disabled")]
        public byte Disabled { get; private set; }

        [JsonProperty("delisted")]
        public byte Delisted { get; private set; }

        [JsonProperty("frozen")]
        public byte Frozen { get; private set; }

        [JsonProperty("isGeofenced")]
        public bool IsGeofenced { get; private set; }

        [JsonConstructor]
        public CurrencieInfo(string txFee)
        {
            decimal.TryParse(txFee, Any, InvariantCulture, out this.txFee);
        }
    }
}
