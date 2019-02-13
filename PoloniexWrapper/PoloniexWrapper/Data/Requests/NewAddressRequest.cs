using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class NewAddressRequest : RequestObject
    {
        public NewAddressRequest(string apiSec, string curr) : base(apiSec)
        {
            arguments["command"] = "generateNewAddress";
            arguments["currency"] = curr;
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
