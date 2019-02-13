using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class FeeInfoRequest : RequestObject
    {
        public FeeInfoRequest(string apiSec) : base(apiSec)
        {
            arguments["command"] = "returnFeeInfo";
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
