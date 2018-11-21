using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PoloniexWrapper.Data.Requests
{
    public abstract class BaseRequest
    {
        private readonly string apiKey;

        internal const string urlSegment = "/public?";

        internal Dictionary<string, string> requestArgs;

        public BaseRequest() { }

        public BaseRequest(string apiKey)
        {
            this.apiKey = apiKey;
        }

        private void CreateSignature()
        {
            //todo
        }

        public async Task<string> Make() => await Task.Run(() =>
               new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString());

        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => 
                        string.Join("&", dict.Select(kvp =>
                        string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
    }
}
