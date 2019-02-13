using static PoloniexWrapper.Helper.Enums.RequestType;
using static PoloniexWrapper.Helper.Enums;

namespace PoloniexWrapper.Data.Requests
{
    public class AvailableAccountBalancesRequest : RequestObject
    {
        public AvailableAccountBalancesRequest(string apiSec, TradingAccount account) : base(apiSec)
        {
            arguments["command"] = "returnAvailableAccountBalances";
            arguments["account"] = account.ToString();
            arguments["nonce"] = GetNonce();           

            GenerateRequest(POST);
        }
    }
}
