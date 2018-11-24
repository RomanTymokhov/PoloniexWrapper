using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class CompleteBalancesRequest : BaseRequest
    {
        public CompleteBalancesRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnCompleteBalances",
                ["nonce"] = GetNonce()
            }; 

            GenerateRequest(trade);
        }
    }
}
