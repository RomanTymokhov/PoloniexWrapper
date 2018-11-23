using System;
using System.Collections.Generic;
using System.Text;

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

            Url = Make(false).Result;

            postArgs = new Dictionary<string, string>
            {
                ["tonce"] = GetTonce()
            };

            POSTdata = 
        }
    }
}
