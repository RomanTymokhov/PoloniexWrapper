using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using PoloniexWrapper.Data.Responses.OrderHeirs;

namespace PoloniexWrapper.Data.Responses
{
    public class MoveOrder : ResponseObject
    {
        [JsonConstructor]
        public MoveOrder(string orderNumber, JObject resultingTrades)
        {
            Answer = new MovedOrder
            {
                OrderNumber = ulong.Parse(orderNumber),
                ResultingTrades = resultingTrades.ToObject<Dictionary<string, List<Order>>>()
            };
        }
    }    
}
