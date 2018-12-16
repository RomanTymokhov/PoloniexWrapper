using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class Currencies
    {
        /// <summary>
        /// New currencie will be added here to use
        /// </summary>

        public List<Currencie> Currencies { get; private set; } = new List<Currencie>();

        [JsonProperty("BTC")]
        private CurrencieInfo Btc
        {
            set => Currencies.Add(new Currencie(value, nameof(Btc).ToUpper()));
        }

        [JsonProperty("LTC")]
        private CurrencieInfo Ltc
        {
            set => Currencies.Add(new Currencie(value, nameof(Ltc).ToUpper()));
        }

        [JsonProperty("ETH")]
        private CurrencieInfo Eth
        {
            set => Currencies.Add(new Currencie(value, nameof(Eth).ToUpper()));
        }

        [JsonProperty("ETC")]
        private CurrencieInfo Etc
        {
            set => Currencies.Add(new Currencie(value, nameof(Etc).ToUpper()));
        }

        [JsonProperty("XRP")]
        private CurrencieInfo Xrp
        {
            set => Currencies.Add(new Currencie(value, nameof(Xrp).ToUpper()));
        }

        [JsonProperty("EOS")]
        private CurrencieInfo Eos
        {
            set => Currencies.Add(new Currencie(value, nameof(Eos).ToUpper()));
        }

        [JsonProperty("XEM")]
        private CurrencieInfo Xem
        {
            set => Currencies.Add(new Currencie(value, nameof(Xem).ToUpper()));
        }

        [JsonProperty("SC")]
        private CurrencieInfo Sc
        {
            set => Currencies.Add(new Currencie(value, nameof(Sc).ToUpper()));
        }

        [JsonProperty("STR")]
        private CurrencieInfo Str
        {
            set => Currencies.Add(new Currencie(value, nameof(Str).ToUpper()));
        }

        [JsonProperty("USDC")]
        private CurrencieInfo Usdc
        {
            set => Currencies.Add(new Currencie(value, nameof(Usdc).ToUpper()));
        }

        [JsonProperty("USDT")]
        private CurrencieInfo Usdt
        {
            set => Currencies.Add(new Currencie(value, nameof(Usdt).ToUpper()));
        }
    }
}
