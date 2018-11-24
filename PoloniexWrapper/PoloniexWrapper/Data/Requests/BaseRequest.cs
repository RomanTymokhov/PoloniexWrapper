using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using PoloniexWrapper.Extensions;

using static PoloniexWrapper.Data.Requests.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public enum ReqType {pub, trade}

    public abstract class BaseRequest
    {
        private readonly string apiSec;

<<<<<<< HEAD
<<<<<<< HEAD
        internal const string urlSegment = "/public?";

        internal Dictionary<string, string> requestArgs;
=======
        internal string Url { get; set; }
        internal string POSTdata { get; set; }
=======
        internal const string urlSegmentPublic  = "/public?";
        internal const string urlSegmentTrading = "/tradingApi";
>>>>>>> dev/tohoff82

        internal Dictionary<string, string> arguments;

        internal string Url { get; private set; }
        internal string Sign { get; private set; }

>>>>>>> dev/tohoff82

        public BaseRequest() { }

        public BaseRequest(string apiSec)
        {
            this.apiSec = apiSec;
        }

        internal string GetNonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

        internal void GenerateRequest(ReqType type)
        {
            if (type == pub) Url = new StringBuilder(urlSegmentPublic).AppendFormat("{0}", arguments.ToKeyValueString()).ToString();
            else
            {
                Url = new StringBuilder(urlSegmentTrading).ToString();
                CreateSignature();
            }                
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public async Task<string> Make() => await Task.Run(() =>
               new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString());
=======
        public async Task<string> Build(ReqType type) =>
                await Task.Run(() => new StringBuilder(type == get ? urlSegmentPub : urlSegmentTrdApi).AppendFormat("{0}", BuildKVPairs(getArgs)).ToString());
>>>>>>> dev/tohoff82

        //var reqestStr = new StringBuilder(urlSegment);
        //reqestStr.AppendFormat("{0}", BuildRequestData(requestArgs));
        //return reqestStr.ToString();
        //return new StringBuilder(urlSegment).AppendFormat("{0}", BuildRequestData(requestArgs)).ToString();

<<<<<<< HEAD
        internal static string BuildRequestData(IDictionary<string, string> dict, bool escape = true) => 
                        string.Join("&", dict.Select(kvp =>
                        string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));
=======
        internal static string BuildKVPairs(IDictionary<string, string> dict, bool escape = true) => 
                        string.Join("&", dict.Select(kvp =>
                        string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));

        internal string GetTonce() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
>>>>>>> dev/tohoff82
=======
        private void CreateSignature() 
        {
            var encryptor = new HMACSHA512(Encoding.ASCII.GetBytes(apiSec));
            var postBytes = Encoding.ASCII.GetBytes(arguments.ToKeyValueString());

            Sign = BitConverter.ToString(encryptor.ComputeHash(postBytes)).Replace("-", "").ToLower();
        }
>>>>>>> dev/tohoff82
    }
}
