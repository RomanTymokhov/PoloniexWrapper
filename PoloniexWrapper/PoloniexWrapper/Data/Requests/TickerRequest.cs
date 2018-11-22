using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest() :base()
        {
            urlArgs = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };

            Url = Make(true).Result;
        }
    }
}
