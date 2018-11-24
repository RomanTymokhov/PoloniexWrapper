using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class NewAddressRequest : BaseRequest
    {
        public NewAddressRequest(string apiSec, string curr) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "generateNewAddress",
                ["currency"] = curr,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(trade);
        }
    }
}
