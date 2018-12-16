using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class CancelOrder
    {
        [JsonProperty("success")]
        public byte Success { get; private set; }

        private readonly decimal amount;
        public decimal Amount { get => amount; }

        [JsonProperty("message")]
        public string Message { get; private set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; private set; }

        [JsonConstructor]
        public CancelOrder(string amount)
        {
            decimal.TryParse(amount, Any, InvariantCulture, out this.amount);
        }
    }
}
