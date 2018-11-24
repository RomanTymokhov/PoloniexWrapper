using System;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Deposit
    {
        [JsonProperty("currency")]
        public string CurrencyID { get; private set; }

        [JsonProperty("address")]
        public string Adress { get; private set; }

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal? Amount => Convert.ToDecimal(amount, CultureInfo.InvariantCulture);

        [JsonProperty("confirmations")]
        private readonly string confirmations;
        public ushort? Confirmations => Convert.ToUInt16(confirmations, CultureInfo.InvariantCulture);

        [JsonProperty("txid")]
        public string TxID { get; private set; }

        [JsonProperty("timestamp")]
        private readonly string timestamp;
        public ulong? Timestamp => Convert.ToUInt64(timestamp, CultureInfo.InvariantCulture);

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
