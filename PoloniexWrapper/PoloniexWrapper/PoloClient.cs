using static PoloniexWrapper.Helper.Enums.PoloAccount;
using static PoloniexWrapper.Helper.Enums;
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

        public PoloClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public PoloClient(string apiKey, string apiSec)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
            this.apiSec = apiSec;
        }

        protected async Task<T> JsonGETAsync<T>(BaseRequest request)
        {
            var response = await httpClient.GetAsync(request.Url).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> JsonPOSTAsync<T>(BaseRequest request)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", request.Sign);

            var response = await httpClient.PostAsync(request.Url,
                new StringContent(request.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: create Exception handler

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

    #region Public Methods

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() => 
                await JsonGETAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() => 
                await JsonGETAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion


    #region Private Methods

        public async Task<Dictionary<string, string>> ReturnBalancesAsync() => 
                await JsonPOSTAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        public async Task<Dictionary<string, CompleteBalance>> ReturComleteBalancesAsync() =>
                await JsonPOSTAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        public async Task<Dictionary<string, string>> ReturnDepositAdressesAsync() =>
                await JsonPOSTAsync<Dictionary<string, string>>(new DepositAdressesRequest(apiSec));

        public async Task<NewAdress> GenerateNewAddressAsync(string currID) => 
                await JsonPOSTAsync<NewAdress>(new NewAddressRequest(apiSec, currID));

        public async Task<DepositsWithdrawals> ReturnDepositsWithdrawalsAsync(DateTime start, DateTime end) =>
                await JsonPOSTAsync<DepositsWithdrawals>(new DepositsWithdrawalsRequest(apiSec, start, end));

        public async Task<AvailableAccountBalances> ReturnAvailableAccountBalancesAsync(PoloAccount account = all) =>
                await JsonPOSTAsync<AvailableAccountBalances>(new AvailableAccountBalancesRequest(apiSec, account));

    #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
