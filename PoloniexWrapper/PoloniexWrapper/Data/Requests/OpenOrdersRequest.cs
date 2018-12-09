using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class OpenOrdersRequest : RequestObject
    {
        public OpenOrdersRequest(string apiSec, string pair) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnOpenOrders",
                ["currencyPair"] = pair,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
