using Newtonsoft.Json;
using System.Text;

namespace PoloniexWrapper.Data.Responses
{
    public class ResponseObject
    {
        [JsonProperty("success")]
        public bool Success { get; set; } = true;

        [JsonProperty("answer")]
        public object Answer { get; set; }

        private Error error;
        [JsonProperty("error")]
        public Error Error
        {
            get => error;
            set
            {
                error = value;
                if (value != null) Success = false;
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

            if (status.code != 200) sb.AppendFormat("{0} - {1}", status.code, status.msg);
            if (status.code == 200) sb.AppendFormat("{0} - {1}", status.code, errMsg);
            Message = sb.ToString();
        }
    }
}
