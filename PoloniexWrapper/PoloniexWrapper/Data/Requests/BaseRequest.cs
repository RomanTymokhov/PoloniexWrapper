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

        internal const string urlSegmentPublic  = "/public?";
        internal const string urlSegmentTrading = "/tradingApi";

        internal Dictionary<string, string> arguments;

        internal string Url { get; private set; }
        internal string Sign { get; private set; }


        public BaseRequest() { }

        public BaseRequest(string apiKey)
        {
            this.apiKey = apiKey;
        }

        internal string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        internal void GenerateRequest(ReqType type)
        {
            if (type == pub) Url = new StringBuilder(urlSegmentPublic).AppendFormat("{0}", arguments.ToKeyValueString()).ToString();
            else
            {
                Url = new StringBuilder(urlSegmentTrading).ToString();
                CreateSignature();
            }
                
        }

        private void CreateSignature() 
        {
            
        }
    }
}
