using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class DepositAdressesRequest : BaseRequest
    {
        public DepositAdressesRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnDepositAddresses",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(trade);
        }
    }
}
