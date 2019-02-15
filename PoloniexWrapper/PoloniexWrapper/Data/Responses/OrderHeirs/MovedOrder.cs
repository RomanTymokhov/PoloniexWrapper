using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class MovedOrder
    {
        [JsonProperty("orderNumber")]
        public ulong OrderNumber { get; set; }

        [JsonProperty("resultingTrades")]
        public Dictionary<string, List<Order>> ResultingTrades { get; set; }
    }
}
