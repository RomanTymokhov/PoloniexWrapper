using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class NewAdress
    {
        [JsonProperty("success")]
        public string Success { get; private set; }

        [JsonProperty("response")]
        public string ApiResponse { get; private set; }
    }
}
