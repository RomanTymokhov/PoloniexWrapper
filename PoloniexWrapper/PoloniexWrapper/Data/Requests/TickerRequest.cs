using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest() :base()
        {
            requestArgs = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };
        }

        public override async Task<string> Make()
        {
            return await Task.Run(() => new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString());
        }

        //public override string ToString()
        //{
        //    //var reqestStr = new StringBuilder(urlSegment);
        //    //reqestStr.AppendFormat("{0}", BuildRequestData(requestArgs));
        //    //return reqestStr.ToString();
        //    return new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString();
        //}
    }
}
