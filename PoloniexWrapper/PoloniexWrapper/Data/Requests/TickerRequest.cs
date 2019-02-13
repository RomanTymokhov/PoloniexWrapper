using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: RequestObject
    {
        public TickerRequest() :base()
        {
            arguments["command"] = "returnTicker";         

            GenerateRequest(GET);
        }
    }
}
