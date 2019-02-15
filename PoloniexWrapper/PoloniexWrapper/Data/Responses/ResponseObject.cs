using Newtonsoft.Json;
using System.Text;

namespace PoloniexWrapper.Data.Responses
{
    public class ResponseObject
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; } = true;

        [JsonProperty("answer")]
        public object Answer { get; set; }

        private Error error;
        [JsonProperty("isError")]
        public Error Error
        {
            get => error;
            set
            {
                error = value;
                if (value != null) IsSuccess = false;
            }
        }
    }
    public class Error
    {
        [JsonProperty("error")]
        public string Message { get; set; }

        public struct HttpStatus
        {
            public ushort code;
            public string msg;
        }

        public Error() { }

        public Error(HttpStatus status, string errMsg = null)
        {
            var sb = new StringBuilder("Poloniex API Error: ");
 
            if (status.code == 200 || status.code == 422) sb.AppendFormat("{0} - {1}", status.code, errMsg);
            else sb.AppendFormat("{0} - {1}", status.code, status.msg);
            Message = sb.ToString();
        }
    }
}
