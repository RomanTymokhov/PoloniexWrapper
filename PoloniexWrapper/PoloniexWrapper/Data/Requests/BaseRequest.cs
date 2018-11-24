using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using PoloniexWrapper.Extensions;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public enum ReqType { pub, trade}

    public abstract class BaseRequest
    {
        private readonly string apiKey;

        internal const string urlSegmentPub  = "/public?";
        internal const string urlSegmentTrdApi = "/tradingApi";

        internal Dictionary<string, string> requestArgs;

        internal string Url { get; set; }
        internal string Sign { get; set; }


        public BaseRequest() { }

        public BaseRequest(string apiKey)
        {
            this.apiKey = apiKey;
        }

        internal string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        internal void GenerateRequest(ReqType type)
        {
            if (type == pub) Url = new StringBuilder(urlSegmentPub).AppendFormat("{0}", requestArgs.ToKeyValueString()).ToString();
            else
            {
                Url = new StringBuilder(urlSegmentTrdApi).ToString();
                CreateSignature();
            }
                
        }

        private void CreateSignature() 
        {
            
        }
    }
}
