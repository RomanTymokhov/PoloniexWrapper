using System.Collections.Generic;
using Newtonsoft.Json;
using PoloniexWrapper.Data.Responses.OrderHeirs;

namespace PoloniexWrapper.Data.Responses
{
    public class MoveOrder
    {
        [JsonProperty("success")]
        public byte Success { get; private set; }

        [JsonProperty("orderNumber")]
        public ulong OrderNumber { get; private set; }

        [JsonProperty("resultingTrades")]
        public Dictionary<string, List<Order>> ResultingTrades { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; private set; }
    }
}
