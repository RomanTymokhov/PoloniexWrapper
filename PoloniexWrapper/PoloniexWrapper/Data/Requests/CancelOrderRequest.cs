using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    class CancelOrderRequest : RequestObject
    {
        public CancelOrderRequest(string apiSec, ulong orderNumber) : base(apiSec)
        {
            arguments["command"] = "cancelOrder";
            arguments["orderNumber"] = orderNumber.ToString();
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
