using Newtonsoft.Json;
using System.Collections.Generic;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class PlacedOrder
    {
        [JsonProperty("orderNumber")]
        public ulong OrderNumber { get; private set; }

        [JsonProperty("resultingTrades")]
        public List<Order> ResultingTrades { get; private set; }
    }
}
