using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class NewAddressRequest : RequestObject
    {
        public NewAddressRequest(string apiSec, string curr) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "generateNewAddress",
                ["currency"] = curr,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
