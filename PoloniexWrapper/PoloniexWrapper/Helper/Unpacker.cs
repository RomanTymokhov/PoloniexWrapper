﻿using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoloniexWrapper.Data.Responses;
using static PoloniexWrapper.Data.Responses.Error;

namespace PoloniexWrapper.Helper
{
    public class Unpacker
    {
        private readonly string json;
        private readonly HttpStatus httpStatus;
        private readonly bool isSuccessStatusCode;

        public Unpacker(HttpResponseMessage response)
        {
            json = response.Content.ReadAsStringAsync().Result;
            isSuccessStatusCode = response.IsSuccessStatusCode;

            httpStatus.code = (ushort)response.StatusCode;
            httpStatus.msg = response.StatusCode.ToString();
            response.Dispose();
        }

        public ResponseObject Unpack<T>()
        {
            if (isSuccessStatusCode)
            {
                if (!IsError(out var error))
                {
                    var obj = JsonConvert.DeserializeObject<T>(json);
                    return new ResponseObject { Answer = obj };
                }
                else return new ResponseObject { Error = error };
            }
            else return new ResponseObject { Error = new Error(httpStatus) };
        }

        private bool IsError(out Error error)
        {
            if (JsonIsEmpty(out var emptyError)) { error = emptyError; return true; }
            else
            {
                if (JsonIsObject(out var jObj) && jObj.ContainsKey("error"))
                {
                    error = new Error(httpStatus, errMsg: jObj.Property("error").Value.ToString());
                    return true;
                }
                else { error = null; return false; }
            }
        }

        private bool JsonIsEmpty(out Error error)
        {
            if (json == string.Empty || json == null)
            { error = new Error(httpStatus, errMsg: "Polo Json Object is empty"); return true; }
            else{ error = null; return false; }
        }

        private bool JsonIsObject(out JObject obj)
        {            
            var jError = JToken.Parse(json);
            if (jError is JObject)
            {
                obj = jError as JObject;
                return true;
            }
            else
            {
                obj = null;
                return false;
            }
        }
    }
}