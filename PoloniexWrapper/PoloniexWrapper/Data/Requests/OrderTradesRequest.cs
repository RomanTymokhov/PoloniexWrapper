using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class OrderTradesRequest : RequestObject
    {
        public OrderTradesRequest(string apiSec, ulong orderNumber) : base(apiSec)
        {
            arguments["command"] = "returnOrderTrades";
            arguments["orderNumber"] = orderNumber.ToString();
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
