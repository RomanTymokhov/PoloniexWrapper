using System;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class TradeHistoryRequest : RequestObject
    { 
        public TradeHistoryRequest(string pairID, DateTime? start, DateTime? end) : base()
        {
            arguments["command"] = "returnTradeHistory";
            arguments["currencyPair"] = pairID;
            arguments["nonce"] = GetNonce();

            if (start != null) arguments["start"] = start.ToUnixtime();
            if (end != null) arguments["end"] = end.ToUnixtime();

            GenerateRequest(GET);
        }

        public TradeHistoryRequest(string apiSec, string pairID, DateTime? start, DateTime? end, ushort? limit) : base(apiSec)
        {
            arguments["command"] = "returnTradeHistory";
            arguments["currencyPair"] = pairID;
            arguments["nonce"] = GetNonce();

            if (start != null) arguments["start"] = start.ToUnixtime();
            if (end != null) arguments["end"] = end.ToUnixtime();
            if (limit != null) arguments["limit"] = limit.ToString();

            GenerateRequest(POST);
        }
    }
}
