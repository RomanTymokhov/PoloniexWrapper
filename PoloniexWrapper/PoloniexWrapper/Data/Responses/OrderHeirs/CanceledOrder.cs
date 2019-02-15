using Newtonsoft.Json;
using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses.OrderHeirs
{
    public class CanceledOrder
    {
        [JsonProperty("amount")]
        private readonly decimal amount;
        public decimal Amount => amount;

        [JsonProperty("message")]
        public string Message { get; private set; }
        
        public CanceledOrder(string amount, string message)
        {
            Message = message;
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
        }
    }
}
