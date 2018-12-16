using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

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
            set => VolumeList.Add(new DalyVolume(value, nameof(Btc_xrp).ToUpper()));
        }

        [JsonProperty("BTC_XEM")]
        private Dictionary<string, string> Btc_xem
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Btc_xem).ToUpper()));
        }

        [JsonProperty("BTC_ETH")]
        private Dictionary<string, string> Btc_eth
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Btc_eth).ToUpper()));
        }

        [JsonProperty("BTC_SC")]
        private Dictionary<string, string> Btc_sc
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Btc_sc).ToUpper()));
        }

        [JsonProperty("BTC_EOS")]
        private Dictionary<string, string> Btc_eos
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Btc_eos).ToUpper()));
        }

        [JsonProperty("ETH_EOS")]
        private Dictionary<string, string> Eth_eos
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Eth_eos).ToUpper()));
        }

        [JsonProperty("USDC_BTC")]
        private Dictionary<string, string> Usdc_btc
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_btc).ToUpper()));
        }

        [JsonProperty("USDC_LTC")]
        private Dictionary<string, string> Usdc_ltc
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_ltc).ToUpper()));
        }

        [JsonProperty("USDC_STR")]
        private Dictionary<string, string> Usdc_str
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_str).ToUpper()));
        }

        [JsonProperty("USDC_XRP")]
        private Dictionary<string, string> Usdc_xrp
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_xrp).ToUpper()));
        }

        [JsonProperty("USDC_ETH")]
        private Dictionary<string, string> Usdc_eth
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_eth).ToUpper()));
        }

        [JsonProperty("USDC_USDT")]
        private Dictionary<string, string> Usdc_usdt
        {
            set => VolumeList.Add(new DalyVolume(value, nameof(Usdc_usdt).ToUpper()));
        }
        
        private readonly decimal totalBTC;
        public decimal TotalBTC { get => totalBTC; }
        
        private readonly decimal totalETH;
        public decimal TotalETH { get => totalETH; }

        private readonly decimal totalUSDC;
        public decimal TotalUSDC { get => totalUSDC; }

        private readonly decimal totalUSDT;
        public decimal TotalUSDT { get => totalUSDT; }

        private readonly decimal totalXMR;
        public decimal TotalXMR { get => totalXMR; }

        private readonly decimal totalXUSD;
        public decimal TotalXUSD { get => totalXUSD; }

        [JsonConstructor]
        public DalyVolumes(string totalBTC, string totalETH, string totalUSDC, string totalUSDT, string totalXMR, string totalXUSD)
        {
            decimal.TryParse(totalBTC, Any, InvariantCulture, out this.totalBTC);
            decimal.TryParse(totalETH, Any, InvariantCulture, out this.totalETH);
            decimal.TryParse(totalUSDC, Any, InvariantCulture, out this.totalUSDC);
            decimal.TryParse(totalUSDT, Any, InvariantCulture, out this.totalUSDT);
            decimal.TryParse(totalXMR, Any, InvariantCulture, out this.totalXMR);
            decimal.TryParse(totalXUSD, Any, InvariantCulture, out this.totalXUSD);
        }
    }
}
