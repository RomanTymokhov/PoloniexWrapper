using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public abstract class BaseRequest
    {
        private readonly string apiSec;

        internal const string urlSegmentPublic  = "/public?";
        internal const string urlSegmentTrading = "/tradingApi";

        internal Dictionary<string, string> arguments;

        internal string Url { get; private set; }
        internal string Sign { get; private set; }


        public BaseRequest() { }

        public BaseRequest(string apiSec)
        {
            this.apiSec = apiSec;
        }

        internal string GetNonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        internal void GenerateRequest(ReqType type)
        {
            switch(type)
            {
                case post:
                    {
                        Url = new StringBuilder(urlSegmentTrading).ToString();
                        CreateSignature();
                    }; break;
                default: Url = new StringBuilder(urlSegmentPublic).AppendFormat("{0}", arguments.ToKeyValueString()).ToString(); break;
            }           
        }

        private void CreateSignature() 
        {
            var encryptor = new HMACSHA512(Encoding.ASCII.GetBytes(apiSec));
            var postBytes = Encoding.ASCII.GetBytes(arguments.ToKeyValueString());

            Sign = BitConverter.ToString(encryptor.ComputeHash(postBytes)).Replace("-", "").ToLower();
        }
    }
}
