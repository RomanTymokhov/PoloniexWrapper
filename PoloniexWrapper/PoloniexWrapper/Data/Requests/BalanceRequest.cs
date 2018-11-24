using System;
using System.Collections.Generic;
using System.Text;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class BalanceRequest: BaseRequest
    {
        public BalanceRequest():base()
        {
            requestArgs = new Dictionary<string, string>
            {
                ["command"] = "returnBalances",
                ["tonce"] = GetTonce()
            };

            GenerateRequest(trade);
        }
    }
}
