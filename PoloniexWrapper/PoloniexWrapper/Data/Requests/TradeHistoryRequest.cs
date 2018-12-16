using System;
using System.Collections.Generic;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class TradeHistoryRequest : RequestObject
    { 
        public TradeHistoryRequest(string pairID, DateTime? start, DateTime? end) : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnTradeHistory",
                ["currencyPair"] = pairID,
                ["nonce"] = GetNonce()
            };

            if (start != null) arguments.Add("start", start.ToUnixtime());
            if (end != null) arguments.Add("end", end.ToUnixtime());

            GenerateRequest(GET);
        }

        public TradeHistoryRequest(string apiSec, string pairID, DateTime? start, DateTime? end, ushort? limit) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnTradeHistory",
                ["currencyPair"] = pairID,
                ["nonce"] = GetNonce()
            };

            if (start != null) arguments.Add("start", start.ToUnixtime());
            if (end != null) arguments.Add("end", end.ToUnixtime());
            if (limit != null) arguments.Add("limit", limit.ToString());

            GenerateRequest(POST);
        }
    }
}
