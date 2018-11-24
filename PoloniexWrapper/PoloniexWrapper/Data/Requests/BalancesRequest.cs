using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class BalancesRequest: BaseRequest
    {
        public BalancesRequest(string apiKey):base(apiKey)
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
