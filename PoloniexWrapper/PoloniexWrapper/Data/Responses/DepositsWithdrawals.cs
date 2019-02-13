using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class DepositsWithdrawals
    {
        [JsonProperty("deposits")]
        public List<Deposit> DepositList { get; private set; }

        [JsonProperty("withdrawals")]
        public List<Withdrawal> WithdrawalList { get; private set; }
    }

    public class Deposit
    {
        [JsonProperty("currency")]
        public string CurrencyID { get; private set; }

        [JsonProperty("address")]
        public string Address { get; private set; }

        private readonly decimal amount;
        public decimal Amount => amount;

        [JsonProperty("confirmations")]
        public ushort Confirmations { get; private set; }

        [JsonProperty("txid")]
        public string TxID { get; private set; }

        [JsonProperty("timestamp")]
        public ulong Timestamp { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonConstructor]
        public Deposit(string amount)
        {
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
        }
    }

    public class Withdrawal
    {
        [JsonProperty("withdrawalNumber")]
        public ulong WithdrawalID { get; private set; }

        [JsonProperty("currency")]
        public string CurrencyID { get; private set; }

        [JsonProperty("address")]
        public string OutputAddress { get; private set; }

        private readonly decimal amount;
        public decimal Amount => amount;

        private readonly decimal fee;
        public decimal Fee => fee;

        [JsonProperty("timestamp")]
        public ulong Timestamp { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonProperty("ipAddress")]
        public string IpAdress { get; private set; }

        [JsonConstructor]
        public Withdrawal(string amount, string fee)
        {
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
            decimal.TryParse(fee, Any, InvariantCulture, out this.fee);
        }
    }
}
