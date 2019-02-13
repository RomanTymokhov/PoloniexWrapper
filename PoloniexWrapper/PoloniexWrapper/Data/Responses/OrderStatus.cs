using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class OrderStatus
    {
        [JsonProperty("result")]
        public object Result { get; private set; }

        [JsonProperty("success")]
        public byte Success { get; set; }
    }
}
