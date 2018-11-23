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
            getArgs = new Dictionary<string, string>
            {
                ["command"] = "returnBalances"
            };

            Url = Build(get).Result;

            postArgs = new Dictionary<string, string>
            {
                ["tonce"] = GetTonce()
            };

            //POSTdata = 
        }
    }
}
