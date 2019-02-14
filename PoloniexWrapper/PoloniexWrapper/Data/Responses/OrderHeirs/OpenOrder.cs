using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class OpenOrder
    {
        [JsonProperty("orderNumber")]
        public ulong OrderNumber { get; private set; }

        [JsonProperty("resultingTrades")]
        public List<Order> ResultingTrades { get; private set; }
    }
}
