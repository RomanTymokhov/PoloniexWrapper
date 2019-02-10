using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class PoloResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("answer")]
        public object Answer { get; set; }
    }
}
