using System;
using System.Collections.Generic;
using System.Text;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest(string apiKey) :base(apiKey)
        {
            RequestArgs = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };
        }

        public override string ToString()
        {
            var url = new StringBuilder("?");
            url.AppendFormat("{0}", BuildRequestData(RequestArgs));
            return url.ToString();
        }
    }
}
