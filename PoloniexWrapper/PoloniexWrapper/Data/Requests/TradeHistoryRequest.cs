using System;
using System.Collections.Generic;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class TradeHistoryRequest : RequestObject
    { 
        public TradeHistoryRequest(string apiSec, DateTime start, DateTime end, string pairID, ushort limit) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnTradeHistory",
                ["currencyPair"] = pairID,
                ["start"] = start.ToUnixtime(),
                ["end"] = end.ToUnixtime(),
                ["limit"] = limit.ToString(),
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
