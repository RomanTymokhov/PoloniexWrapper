using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data
{
    public class CurrencieInfo
    {
        [JsonProperty("id")]
        public uint Id { get; private set; }

        private readonly decimal maxDailyWithdrawal;
        public decimal MaxDailyWithdrawal { get => maxDailyWithdrawal; }

        private readonly decimal txFee;
        public decimal TxFee { get => txFee; }

        [JsonProperty("minConf")]
        public ushort MinConf { get; private set; }

        [JsonProperty("disabled")]
        public byte Disabled { get; private set; }

        [JsonConstructor]
        public CurrencieInfo(string maxDailyWithdrawal, string txFee)
        {
            decimal.TryParse(maxDailyWithdrawal, Any, InvariantCulture, out this.maxDailyWithdrawal);
            decimal.TryParse(txFee, Any, InvariantCulture, out this.txFee);
        }
    }
}
