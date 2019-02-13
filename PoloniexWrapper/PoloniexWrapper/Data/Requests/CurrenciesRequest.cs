using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class CurrenciesRequest : RequestObject
    {
        public CurrenciesRequest() : base()
        {
            arguments["command"] = "returnCurrencies";
            arguments["nonce"] = GetNonce();           

            GenerateRequest(GET);
        }
    }
}
