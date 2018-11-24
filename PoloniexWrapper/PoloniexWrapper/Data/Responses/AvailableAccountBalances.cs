using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class AvailableAccountBalances
    {
        [JsonProperty("exchange")]
        public Dictionary<string, string> Exchange { get; private set; }

        [JsonProperty("margin")]
        public Dictionary<string, string> Margin { get; private set; }

        [JsonProperty("lending")]
        public Dictionary<string, string> Lending { get; private set; }
    }
}
