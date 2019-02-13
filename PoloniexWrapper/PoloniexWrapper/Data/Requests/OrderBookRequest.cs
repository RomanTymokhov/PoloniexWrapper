using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    class OrderBookRequest : RequestObject
    {
        public OrderBookRequest(string pairId, ushort? depth) : base()
        {
            arguments["command"] = "returnOrderBook";
            arguments["currencyPair"] = pairId;
            arguments["nonce"] = GetNonce();

            if (depth != null) arguments["depth"] = depth.ToString();

            GenerateRequest(GET);
        }
    }
}
