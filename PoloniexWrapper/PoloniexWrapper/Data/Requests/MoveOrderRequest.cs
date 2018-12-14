using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;
using static System.Globalization.CultureInfo;

namespace PoloniexWrapper.Data.Requests
{
    public class MoveOrderRequest : RequestObject
    {
        public MoveOrderRequest(string apiSec, ulong orderNumber, decimal rate, decimal? amount, byte postOnly) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "moveOrder",
                ["orderNumber"] = orderNumber.ToString(),
                ["rate"] = rate.ToString(GetCultureInfo("en-US")),
                ["nonce"] = GetNonce()
            };

            if (amount != null) arguments.Add("amount", ((decimal)amount).ToString(GetCultureInfo("en-US")));
            if (postOnly == 1) arguments.Add("postOnly", postOnly.ToString());

            GenerateRequest(POST);
        }
    }
}
