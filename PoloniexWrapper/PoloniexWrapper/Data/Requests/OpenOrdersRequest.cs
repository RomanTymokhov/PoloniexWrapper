using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class OpenOrdersRequest : RequestObject
    {
        public OpenOrdersRequest(string apiSec, string pair) : base(apiSec)
        {
            arguments["command"] = "returnOpenOrders";
            arguments["currencyPair"] = pair;
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
