using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoloniexWrapper.Data.Responses.OrderHeirs;
using System.Collections.Generic;

namespace PoloniexWrapper.Data.Responses
{
    public class OrderStatus : ResponseObject
    {
        [JsonConstructor]
        public OrderStatus(JObject result)
        {
            if (result.ContainsKey("error")) Error = new Error { Message = "Poloniex API Error: 200 - Order not Found" };
            else Answer = result.ToObject<Dictionary<ulong, FillOrder>>();
        }
    }
}
