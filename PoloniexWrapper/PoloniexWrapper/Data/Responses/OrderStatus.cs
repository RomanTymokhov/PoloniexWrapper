using System.Collections.Generic;
using Newtonsoft.Json;
using PoloniexWrapper.Data.Responses.OrderHeirs;

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
