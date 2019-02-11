using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Currencies
    {
        /// <summary>
        /// New currencie will be added here to use
        /// </summary>

        public List<Currencie> Collection { get; private set; } = new List<Currencie>();

        [JsonProperty("BTC")]
        private CurrencieInfo Btc
        {
            set => Collection.Add(new Currencie(value, nameof(Btc).ToUpper()));
        }

        [JsonProperty("LTC")]
        private CurrencieInfo Ltc
        {
            set => Collection.Add(new Currencie(value, nameof(Ltc).ToUpper()));
        }

        [JsonProperty("ETH")]
        private CurrencieInfo Eth
        {
            set => Collection.Add(new Currencie(value, nameof(Eth).ToUpper()));
        }

        [JsonProperty("ETC")]
        private CurrencieInfo Etc
        {
            set => Collection.Add(new Currencie(value, nameof(Etc).ToUpper()));
        }

        [JsonProperty("XRP")]
        private CurrencieInfo Xrp
        {
            set => Collection.Add(new Currencie(value, nameof(Xrp).ToUpper()));
        }

        [JsonProperty("EOS")]
        private CurrencieInfo Eos
        {
            set => Collection.Add(new Currencie(value, nameof(Eos).ToUpper()));
        }

        [JsonProperty("XEM")]
        private CurrencieInfo Xem
        {
            set => Collection.Add(new Currencie(value, nameof(Xem).ToUpper()));
        }

        [JsonProperty("SC")]
        private CurrencieInfo Sc
        {
            set => Collection.Add(new Currencie(value, nameof(Sc).ToUpper()));
        }

        [JsonProperty("STR")]
        private CurrencieInfo Str
        {
            set => Collection.Add(new Currencie(value, nameof(Str).ToUpper()));
        }

        [JsonProperty("USDC")]
        private CurrencieInfo Usdc
        {
            set => Collection.Add(new Currencie(value, nameof(Usdc).ToUpper()));
        }

        [JsonProperty("USDT")]
        private CurrencieInfo Usdt
        {
            set => Collection.Add(new Currencie(value, nameof(Usdt).ToUpper()));
        }
    }
}
