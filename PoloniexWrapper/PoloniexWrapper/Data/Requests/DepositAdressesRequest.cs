using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class DepositAdressesRequest : RequestObject
    {
        public DepositAdressesRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnDepositAddresses",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
