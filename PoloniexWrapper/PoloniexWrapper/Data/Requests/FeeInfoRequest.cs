using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class FeeInfoRequest : RequestObject
    {
        public FeeInfoRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnFeeInfo",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
