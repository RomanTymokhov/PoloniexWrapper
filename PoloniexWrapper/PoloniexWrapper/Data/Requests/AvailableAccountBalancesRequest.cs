using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Requests
{
    public class AvailableAccountBalancesRequest : RequestObject
    {
        public AvailableAccountBalancesRequest(string apiSec, TradingAccount account) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnAvailableAccountBalances",
                ["account"] = account.ToString(),
                ["nonce"]   = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
