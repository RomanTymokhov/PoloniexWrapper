using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class CancelOrder
    {
        [JsonProperty("success")]
        public byte Success { get; set; }

        [JsonProperty("amount")]
        private readonly string result;
        public decimal Result => Convert.ToDecimal(result, CultureInfo.InvariantCulture);

        [JsonProperty("message")]
        public string Message { get; private set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; private set; }
    }
}
