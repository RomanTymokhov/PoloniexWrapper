using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => 
                        string.Join("&", dict.Select(kvp =>
                        string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
    }
}
