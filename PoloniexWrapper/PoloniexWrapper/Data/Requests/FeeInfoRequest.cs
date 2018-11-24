using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class FeeInfoRequest : BaseRequest
    {
        public FeeInfoRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnFeeInfo",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(trade);
        }
    }
}
