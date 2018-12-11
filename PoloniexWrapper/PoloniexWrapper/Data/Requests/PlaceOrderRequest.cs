using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.RequestType;
using static System.Globalization.CultureInfo;

namespace PoloniexWrapper.Data.Requests
{
    public class PlaceOrderRequest : RequestObject
    {
        public PlaceOrderRequest(string apiSec, OrderType type, decimal rate, decimal amount, string pair) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = type.ToString(),
                ["rate"] = rate.ToString(GetCultureInfo("en-US")),
                ["amount"] = amount.ToString(GetCultureInfo("en-US")),
                ["currencyPair"] = pair,
                ["nonce"] = GetNonce()
            };

            GenerateRequest(POST);
        }
    }
}
