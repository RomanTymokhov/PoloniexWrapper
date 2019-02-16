using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Withdraw : ResponseObject
    {
        [JsonConstructor]
        public Withdraw(string response)
        {
            Answer = response;
        }
    }
}
