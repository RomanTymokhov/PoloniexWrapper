using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using PoloniexWrapper.Data.Responses;

namespace PoloniexWrapper.Helper
{
    public static class Extensions
    {
        public static string ToKeyValueString(this Dictionary<string, string> dict, bool escape = true) =>
                      string.Join("&", dict.Select(kvp => string.Format("{0}={1}", kvp.Key, escape ? HttpUtility.UrlEncode(kvp.Value) : kvp.Value)));        

        public static string ToUnixtime(this DateTime? dateTime) => ((int)((DateTime)dateTime - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        public static string ToUnixtime(this DateTime dateTime) => ((int)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds).ToString();

        public static ResponseObject Unpack<T>(this System.Net.Http.HttpResponseMessage response)
        {
            return new Unpacker(response).Unpack<T>();
        }
    }
}
