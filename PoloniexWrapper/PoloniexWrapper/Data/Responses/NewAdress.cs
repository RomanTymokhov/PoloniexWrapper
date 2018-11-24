using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class NewAdress
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
