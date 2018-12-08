using Newtonsoft.Json;
namespace PoloniexWrapper.Exceptions
{
    public class Error
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; private set; }
    }
}
