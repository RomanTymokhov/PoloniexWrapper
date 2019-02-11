using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class ApiError
    {
        [JsonProperty("error")]
        public string Message { get; set; }
    }
}
