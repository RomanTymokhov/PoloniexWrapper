using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace PoloniexWrapper.Data.Responses
{
    public class DalyVolumes
    {
        /// <summary>
        /// New pairs will be added here to use.
        /// </summary>
        
        public List<DalyVolume> VolumeList = new List<DalyVolume>(); 

        [JsonProperty("BTC_XRP")]
        private Dictionary<string, string> Btc_xrp
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Btc_xrp).ToUpper()));}
        }

        [JsonProperty("BTC_XEM")]
        private Dictionary<string, string> Btc_xem
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Btc_xem).ToUpper())); }
        }

        [JsonProperty("BTC_ETH")]
        private Dictionary<string, string> Btc_eth
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Btc_eth).ToUpper())); }
        }

        [JsonProperty("BTC_SC")]
        private Dictionary<string, string> Btc_sc
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Btc_sc).ToUpper())); }
        }

        [JsonProperty("BTC_EOS")]
        private Dictionary<string, string> Btc_eos
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Btc_eos).ToUpper())); }
        }

        [JsonProperty("ETH_EOS")]
        private Dictionary<string, string> Eth_eos
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Eth_eos).ToUpper())); }
        }

        [JsonProperty("USDC_BTC")]
        private Dictionary<string, string> Usdc_btc
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_btc).ToUpper())); }
        }

        [JsonProperty("USDC_LTC")]
        private Dictionary<string, string> Usdc_ltc
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_ltc).ToUpper())); }
        }

        [JsonProperty("USDC_STR")]
        private Dictionary<string, string> Usdc_str
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_str).ToUpper())); }
        }

        [JsonProperty("USDC_XRP")]
        private Dictionary<string, string> Usdc_xrp
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_xrp).ToUpper())); }
        }

        [JsonProperty("USDC_ETH")]
        private Dictionary<string, string> Usdc_eth
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_eth).ToUpper())); }
        }

        [JsonProperty("USDC_USDT")]
        private Dictionary<string, string> Usdc_usdt
        {
            set { VolumeList.Add(new DalyVolume(value, nameof(Usdc_usdt).ToUpper())); }
        }

        [JsonProperty("totalBTC")]
        private readonly string totalBTC;
        public decimal? TotalBTC => Convert.ToDecimal(totalBTC, CultureInfo.InvariantCulture);

        [JsonProperty("totalETH")]
        private readonly string totalETH;
        public decimal? TotalETH => Convert.ToDecimal(totalETH, CultureInfo.InvariantCulture);

        [JsonProperty("totalUSDC")]
        private readonly string totalUSDC;
        public decimal? TotalUSDC => Convert.ToDecimal(totalUSDC, CultureInfo.InvariantCulture);

        [JsonProperty("totalUSDT")]
        private readonly string totalUSDT;
        public decimal? TotalUSDT => Convert.ToDecimal(totalUSDT, CultureInfo.InvariantCulture);

        [JsonProperty("totalXMR")]
        private readonly string totalXMR;
        public decimal? TotalXMR => Convert.ToDecimal(totalXMR, CultureInfo.InvariantCulture);

        [JsonProperty("totalXUSD")]
        private readonly string totalXUSD;
        public decimal? TotalXUSD => Convert.ToDecimal(totalXUSD, CultureInfo.InvariantCulture);
    }
}
