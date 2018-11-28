using static PoloniexWrapper.Helper.Enums.TradingAccount;
using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Data.PairID;
using PoloniexWrapper.Helper;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System;
using Newtonsoft.Json;

namespace PoloniexWrapper
{
    public class PoloClient : IDisposable
    {
        private readonly string apiSec;
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://poloniex.com";

        public PoloClient() => httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };

        public PoloClient(string apiKey, string apiSec)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
            this.apiSec = apiSec;
        }

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: create Exception handler

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

    #region Public Methods

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() => 
                await HttpGetAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() => 
                await HttpGetAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion


    #region Private Methods

        public async Task<Dictionary<string, string>> ReturnBalancesAsync() => 
                await HttpPostAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        public async Task<Dictionary<string, CompleteBalance>> ReturnComleteBalancesAsync() =>
                await HttpPostAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        public async Task<Dictionary<string, string>> ReturnDepositAdressesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new DepositAdressesRequest(apiSec));

        public async Task<NewAdress> GenerateNewAddressAsync(string currID) => 
                await HttpPostAsync<NewAdress>(new NewAddressRequest(apiSec, currID));

        public async Task<DepositsWithdrawals> ReturnDepositsWithdrawalsAsync(DateTime start, DateTime end) =>
                await HttpPostAsync<DepositsWithdrawals>(new DepositsWithdrawalsRequest(apiSec, start, end));

        public async Task<AvailableAccountBalances> ReturnAvailableAccountBalancesAsync(TradingAccount account = all) =>
                await HttpPostAsync<AvailableAccountBalances>(new AvailableAccountBalancesRequest(apiSec, account));

        public async Task<FeeInfo> ReturnFeeInfoAsync() => await HttpPostAsync<FeeInfo>(new FeeInfoRequest(apiSec));

        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T"> Dictionary<string, List<Order>> </typeparam>
        /// <param name="pairID">allPairs</param>
        /// <returns> Dictionary<string, List<Order>> </returns>
        /// <typeparam name="T"> List<Order> </typeparam>
        /// <param name="pairID">concret pair</param>
        /// <returns> List<Order> </returns>

        public async Task<T> ReturnOpenOrdersAsync<T>(string pairID = allPairs) =>
                await HttpPostAsync<T>(new OpenOrdersRequest(apiSec, pairID));

        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T"> List<Trade> or Dictionary<string, List<Trade>> </typeparam>
        /// <param name="apiSec"> apiSec </param>
        /// <param name="pairID"> pairId</param>
        /// <param name="start"> time period begin</param>
        /// <param name="end"> time period end</param>
        /// <param name="limit"> quontity trades (minimum = 500, maximum = 10 000), if you do not specify a "limit", it will be limited to one day  </param>
        /// <returns></returns>

        public async Task<T> ReturnTradeHistoryAsync<T>( DateTime start, DateTime end, string pairID = allPairs, ushort limit = 500) =>
                await HttpPostAsync<T>(new TradeHistoryRequest(apiSec, start, end, pairID, limit));

        #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
