using System;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class DepositsWithdrawalsRequest :RequestObject
    {
        public DepositsWithdrawalsRequest(string apiSec, DateTime? startDate, DateTime? endDate) : base(apiSec)
        {
            arguments["command"] = "returnDepositsWithdrawals";
            arguments["start"] = startDate.ToUnixtime();
            arguments["end"] = endDate.ToUnixtime();
            arguments["nonce"] = GetNonce();

            GenerateRequest(POST);
        }
    }
}
