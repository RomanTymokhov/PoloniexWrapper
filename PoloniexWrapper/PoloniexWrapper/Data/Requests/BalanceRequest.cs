using System;
using System.Collections.Generic;
using System.Text;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class BalanceRequest: BaseRequest
    {
        public BalanceRequest(string apiKey):base(apiKey)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnBalances",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(trade);
        }
    }
}
