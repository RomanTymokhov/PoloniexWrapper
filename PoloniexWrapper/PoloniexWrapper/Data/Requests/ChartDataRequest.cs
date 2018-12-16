using System;
using System.Collections.Generic;
using System.Text;

namespace PoloniexWrapper.Data.Requests
{
    public class ChartDataRequest : RequestObject
    {
        public ChartDataRequest(string pairID, uint period, DateTime? start, DateTime? end) : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnChartData",
                ["currencyPair"] = pairID,
                ["period"] = period.ToString(),
                ["nonce"] = GetNonce()
            };

            if (start != null) arguments.Add("start", start.ToUnixtime());
            if (end != null) arguments.Add("end", end.ToUnixtime());

            GenerateRequest(GET);
        }
    }
}
