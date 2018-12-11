using System;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using PoloniexWrapper.Data.Responses.OrderHeirs;

namespace PoloniexWrapper.Data.Responses
{
    public class PlaceOrder
    {
        [JsonProperty("orderNumber")]
        public ulong? OrderNumber { get; private set; }

        [JsonProperty("resultingTrades")]
        public List<Order> ResultingTrades { get; set; }
    }
}
