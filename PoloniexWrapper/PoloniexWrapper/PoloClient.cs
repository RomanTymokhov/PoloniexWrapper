using PoloniexWrapper.Extensions;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Linq;
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

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

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
            //todo: creae Exception handler

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

    #region Public Methods

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() => await JsonGETAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() =>  await JsonGETAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion


    #region Private Methods

        public async Task<Dictionary<string, string>> ReturnBalancesAsync() => await JsonPOSTAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        public async Task<Dictionary<string, CompleteBalance>> ReturComleteBalancesAsync() => await JsonPOSTAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
