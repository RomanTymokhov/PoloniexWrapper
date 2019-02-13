using static PoloniexWrapper.Helper.Enums.RequestType;
using static System.Globalization.CultureInfo;

namespace PoloniexWrapper.Data.Requests
{
    public class WithdrawRequest : RequestObject
    {
        public WithdrawRequest(string apiSec, string currencyId, decimal amount, string adress, string paymentId) : base(apiSec)
        {
            arguments["command"] = "withdraw";
            arguments["currency"] = currencyId;
            arguments["amount"] = amount.ToString(GetCultureInfo("en-US"));
            arguments["address"] = adress;
            arguments["nonce"] = GetNonce();

            if (paymentId != null) arguments["paymentId"] = paymentId;

            GenerateRequest(POST);
        }
    }
}
