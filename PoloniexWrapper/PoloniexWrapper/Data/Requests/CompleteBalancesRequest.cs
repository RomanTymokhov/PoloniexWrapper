﻿using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class CompleteBalancesRequest : RequestObjec
    {
        public CompleteBalancesRequest(string apiSec) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnCompleteBalances",
                ["nonce"] = GetNonce()
            }; 

            GenerateRequest(post);
        }
    }
}
