using System;
using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class OrderTradesRequest : RequestObject
    {
        public OrderTradesRequest(string apiSec, ulong? orderNumber) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"]     = "returnOrderTrades",
                ["orderNumber"] = orderNumber.ToString(),
                ["nonce"]       = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
