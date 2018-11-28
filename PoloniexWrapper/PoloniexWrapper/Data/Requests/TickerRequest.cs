using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest() :base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };

            GenerateRequest(get);
        }
    }
}
