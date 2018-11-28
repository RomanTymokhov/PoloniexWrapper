using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class BalancesRequest: RequestObject
    {
        public BalancesRequest(string apiSec):base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnBalances",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(post);
        }
    }
}
