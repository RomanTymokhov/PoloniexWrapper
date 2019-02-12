using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Withdraw
    {
        [JsonProperty("response")]
        public string Response { get; private set; }

        [JsonProperty("error")]
        public string Error { get; private set; }
    }
}
