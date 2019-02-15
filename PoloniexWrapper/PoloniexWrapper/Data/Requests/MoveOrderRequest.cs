using static PoloniexWrapper.Helper.Enums.RequestType;
using static System.Globalization.CultureInfo;

namespace PoloniexWrapper.Data.Requests
{
    public class MoveOrderRequest : RequestObject
    {
        public MoveOrderRequest(string apiSec, ulong orderNumber, decimal rate, decimal? amount, byte postOnly, byte immediateOrCancel) : base(apiSec)
        {
            arguments["command"] = "moveOrder";
            arguments["orderNumber"] = orderNumber.ToString();
            arguments["rate"] = rate.ToString(GetCultureInfo("en-US"));
            arguments["nonce"] = GetNonce();

            if (amount != null) arguments["amount"] = ((decimal)amount).ToString(GetCultureInfo("en-US"));
            if (immediateOrCancel == 1) arguments["immediateOrCancel"] = immediateOrCancel.ToString();
            if (postOnly == 1) arguments["postOnly"] = postOnly.ToString();

            GenerateRequest(POST);
        }
    }
}
