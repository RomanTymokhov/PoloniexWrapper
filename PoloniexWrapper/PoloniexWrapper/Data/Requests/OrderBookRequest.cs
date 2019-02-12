using System.Collections.Generic;
using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    class OrderBookRequest : RequestObject
    {
        public OrderBookRequest(string pairId, ushort? depth) : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnOrderBook",
                ["currencyPair"] = pairId,
                ["nonce"] = GetNonce()
            };

            if (depth != null) arguments.Add("depth", depth.ToString());

            GenerateRequest(GET);
        }
    }
}
