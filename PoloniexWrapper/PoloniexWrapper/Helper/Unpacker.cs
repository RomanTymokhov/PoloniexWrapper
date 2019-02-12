using System.Net.Http;
using Newtonsoft.Json;
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
                if (IsError(out var error)) return new ResponseObject { Error = error };
                else return new ResponseObject { Answer = JsonConvert.DeserializeObject<T>(json)};
            }
            else return new ResponseObject { Error = new Error(httpStatus) };
        }

        private bool IsError(out Error error)
        {
            var apiError = JsonConvert.DeserializeObject<ApiError>(json);

            if (apiError.Message != null)
            {
                error = new Error(httpStatus, errMsg: apiError.Message);
                return true;
            }
            else
            {
                error = null;
                return false;
            }
        }
    }
}
