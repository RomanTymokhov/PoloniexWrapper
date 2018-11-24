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
}
