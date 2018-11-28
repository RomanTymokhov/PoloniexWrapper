﻿using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class OpenOrdersRequest : BaseRequest
    {
        public OpenOrdersRequest(string apiSec, string pair) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnOpenOrders",
                ["currencyPair"] = pair,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(post);
        }
    }
}
