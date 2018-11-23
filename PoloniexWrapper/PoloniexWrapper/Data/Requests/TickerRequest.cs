using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest() :base()
        {
            getArgs = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };

            Url = Build(get).Result;
        }
    }
}
