using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class OrderStatusRequest : RequestObject
    {
        public OrderStatusRequest(string apiSec, ulong? orderNumber) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnOrderStatus",
                ["orderNumber"] = orderNumber.ToString(),
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
