using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public enum ReqType { get, post}

    public abstract class BaseRequest
    {
        private readonly string apiKey;

        internal string Url { get; set; }
        internal string POSTdata { get; set; }

        internal const string urlSegmentPub  = "/public?";
        internal const string urlSegmentTrdApi = "/tradingApi?";

        internal Dictionary<string, string> getArgs;
        internal Dictionary<string, string> postArgs;


        public BaseRequest() { }

        public BaseRequest(string apiKey)
        {
            this.apiKey = apiKey;
        }

        private void CreateSignature()
        {
            //todo
        }

        public async Task<string> Build(ReqType type)
        {
            return await Task.Run(() =>
new StringBuilder(type == get ? urlSegmentPub : urlSegmentTrdApi).AppendFormat("{0}", BuildKVPairs(getArgs)).ToString());
        }

        //var reqestStr = new StringBuilder(urlSegment);
        //reqestStr.AppendFormat("{0}", BuildRequestData(requestArgs));
        //return reqestStr.ToString();
        //return new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString();

        internal static string BuildKVPairs(IDictionary<string, string> dict, bool escape = true) => 
                        string.Join("&", dict.Select(kvp =>
                        string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));

        internal string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
    }
}
