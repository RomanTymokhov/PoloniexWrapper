using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class OrderStatusRequest : RequestObject
    {
        public OrderStatusRequest(string apiSec, ulong orderNumber) : base(apiSec)
        {
            arguments["command"] = "returnOrderStatus";
            arguments["orderNumber"] = orderNumber.ToString();
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
