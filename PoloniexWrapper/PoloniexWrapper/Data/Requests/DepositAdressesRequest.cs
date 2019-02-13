using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class DepositAdressesRequest : RequestObject
    {
        public DepositAdressesRequest(string apiSec) : base(apiSec)
        {
            arguments["command"] = "returnDepositAddresses";
            arguments["nonce"] = GetNonce();            

            GenerateRequest(POST);
        }
    }
}
