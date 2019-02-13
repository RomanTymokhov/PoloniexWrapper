using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using PoloniexWrapper.Helper;

using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public abstract class RequestObject
    {
        private readonly string apiSec;

        private const string urlSegmentPublic  = "/public?";
        private const string urlSegmentTrading = "/tradingApi";

        internal Dictionary<string, string> arguments;

        internal string Url { get; private set; }
        internal string Sign { get; private set; }


        public RequestObject()
        {
            arguments = new Dictionary<string, string>();
        }

        public RequestObject(string apiSec) : this()
        {
            this.apiSec = apiSec;
        }

        protected string GetNonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        protected void GenerateRequest(RequestType type)
        {
            if (type == POST)
            {
                Url = new StringBuilder(urlSegmentTrading).ToString();
                CreateSignature();
            }
            else Url = new StringBuilder(urlSegmentPublic).AppendFormat("{0}", arguments.ToKeyValueString()).ToString();
        }

        private void CreateSignature() 
        {
            using (var encryptor = new HMACSHA512(Encoding.ASCII.GetBytes(apiSec)))
            {
                byte[] postBytes = Encoding.ASCII.GetBytes(arguments.ToKeyValueString());

                Sign = BitConverter.ToString(encryptor.ComputeHash(postBytes)).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
