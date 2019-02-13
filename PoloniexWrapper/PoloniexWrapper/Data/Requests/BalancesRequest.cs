using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class BalancesRequest: RequestObject
    {
        public BalancesRequest(string apiSec):base(apiSec)
        {
            arguments["command"] = "returnBalances";
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
