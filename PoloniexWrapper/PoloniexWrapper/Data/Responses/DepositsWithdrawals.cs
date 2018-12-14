using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class DepositsWithdrawals
    {
        [JsonProperty("deposits")]
        public List<Deposit> DepositList { get; private set; }

        [JsonProperty("withdrawals")]
        public List<Withdrawal> WithdrawalList { get; private set; }
    }

    public class Withdrawal
    {
        [JsonProperty("withdrawalNumber")]
        private readonly string witdrawalID;
        public ulong? WithdrawalID => Convert.ToUInt64(witdrawalID, CultureInfo.InvariantCulture);

        [JsonProperty("currency")]
        public string CurrencyID { get; private set; }

        [JsonProperty("address")]
        public string Adress { get; private set; }

        [JsonProperty("amount")]
        private readonly string amount;
        public decimal? Amount => Convert.ToDecimal(amount, CultureInfo.InvariantCulture);

        [JsonProperty("timestamp")]
        private readonly string timestamp;
        public ulong? Timestamp => Convert.ToUInt64(timestamp, CultureInfo.InvariantCulture);

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonProperty("ipAddress")]
        public string IpAdress { get; private set; }
    }
}
