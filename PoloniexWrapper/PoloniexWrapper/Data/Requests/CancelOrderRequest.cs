using System;
using System.Collections.Generic;
using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    class CancelOrderRequest : RequestObject
    {
        public CancelOrderRequest(string apiSec, ulong orderNumber) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "cancelOrder",
                ["orderNumber"] = orderNumber.ToString(),
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
