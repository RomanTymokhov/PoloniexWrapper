using System.Collections.Generic;
using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class PlaceOrderRequest : RequestObject
    {
        public PlaceOrderRequest(string apiSec, OrderType type, decimal rate, decimal amount, string pair) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = type.ToString(),
                ["rate"] = rate.ToString(),
                ["amount"] = amount.ToString(),
                ["currencyPair"] = pair,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
