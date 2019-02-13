using System;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class ChartDataRequest : RequestObject
    {
        public ChartDataRequest(string pairID, uint period, DateTime start, DateTime end) : base()
        {
            arguments["command"] = "returnChartData";
            arguments["currencyPair"] = pairID;
            arguments["period"] = period.ToString();
            arguments["start"] = start.ToUnixtime();
            arguments["end"] = end.ToUnixtime();
            arguments["nonce"] = GetNonce();            

            GenerateRequest(GET);
        }
    }
}
