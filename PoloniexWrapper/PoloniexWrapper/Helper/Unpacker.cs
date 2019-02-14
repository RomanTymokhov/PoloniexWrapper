using System.Net.Http;
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
        private readonly bool isUnprocessableStatusCode = false;

        public Unpacker(HttpResponseMessage response)
        {
            json = response.Content.ReadAsStringAsync().Result;
            isSuccessStatusCode = response.IsSuccessStatusCode;
            if ((ushort)response.StatusCode == 422) isUnprocessableStatusCode = true;

            httpStatus.code = (ushort)response.StatusCode;
            httpStatus.msg = response.StatusCode.ToString();
            response.Dispose();
        }

        public ResponseObject Unpack<T>()
        {
            if (isSuccessStatusCode || isUnprocessableStatusCode)
            {
                if (!IsError(out var error))
                {
                    var obj = JsonConvert.DeserializeObject<T>(json);
                    if (obj is ResponseObject) return obj as ResponseObject;
                    else return new ResponseObject { Answer = obj };
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
                    string m = jObj.Property("error").Value.ToString();
                    error = new Error(httpStatus, errMsg: m);
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
