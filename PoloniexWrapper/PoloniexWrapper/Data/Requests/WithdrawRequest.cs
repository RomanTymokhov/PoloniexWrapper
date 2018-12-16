using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;
using static System.Globalization.CultureInfo;

namespace PoloniexWrapper.Data.Requests
{
    public class WithdrawRequest : RequestObject
    {
        public WithdrawRequest(string apiSec, string currencyId, decimal amount, string adress, string paymentId) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "withdraw",
                ["currency"] = currencyId,
                ["amount"] = amount.ToString(GetCultureInfo("en-US")),
                ["address"] = adress,
                ["nonce"] = GetNonce()
            };

            if (paymentId != null) arguments.Add("paymentId", paymentId);

            GenerateRequest(POST);
        }
    }
}
