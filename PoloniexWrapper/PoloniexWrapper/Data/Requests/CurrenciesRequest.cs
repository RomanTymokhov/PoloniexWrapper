using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class CurrenciesRequest : RequestObject
    {
        public CurrenciesRequest() : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnCurrencies",
                ["nonce"] = GetNonce()
            };

            GenerateRequest(GET);
        }
    }
}
