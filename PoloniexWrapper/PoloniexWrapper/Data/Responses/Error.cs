using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}
