using System;
using System.Collections.Generic;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class TradeHistoryRequest : BaseRequest
    { 
        public TradeHistoryRequest(string apiSec, string pairID, DateTime? start, DateTime? end, ushort limit) : base(apiSec)
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

            GenerateRequest(trade);
        }
    }
}
