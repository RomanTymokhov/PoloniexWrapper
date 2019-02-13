using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class CompleteBalancesRequest : RequestObject
    {
        public CompleteBalancesRequest(string apiSec) : base(apiSec)
        {
            arguments["command"] = "returnCompleteBalances";
            arguments["nonce"] = GetNonce();          

            GenerateRequest(POST);
        }
    }
}
