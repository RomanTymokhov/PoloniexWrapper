using System;
using System.Collections.Generic;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class ChartDataRequest : RequestObject
    {
        public ChartDataRequest(string pairID, uint period, DateTime start, DateTime end) : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnChartData",
                ["currencyPair"] = pairID,
                ["period"] = period.ToString(),
                ["start"] = start.ToUnixtime(),
                ["end"] = end.ToUnixtime(),
                ["nonce"] = GetNonce()
            };

            GenerateRequest(GET);
        }
    }
}
