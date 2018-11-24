using System;
using System.Collections.Generic;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class DepositsWithdrawalsRequest :BaseRequest
    {
        public DepositsWithdrawalsRequest(string apiSec, DateTime startDate, DateTime endDate) : base(apiSec)
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "returnDepositsWithdrawals",
                ["start"] = startDate.ToUnixtime(),
                ["end"] = endDate.ToUnixtime(),
                ["nonce"] = GetNonce()
            };

            GenerateRequest(trade);
        }
    }
}
