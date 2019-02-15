using Newtonsoft.Json;
using PoloniexWrapper.Data.Responses.OrderHeirs;

namespace PoloniexWrapper.Data.Responses
{
    public class CancelOrder : ResponseObject
    {
        [JsonConstructor]
        public CancelOrder(string message, string amount)
        {
            Answer = new CanceledOrder(amount, message);
        }
    }
}
