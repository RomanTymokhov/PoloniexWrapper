using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace PoloniexWrapper
{
    public class PoloClient : IDisposable
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://poloniex.com";

        public PoloClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public PoloClient(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
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
                new StringContent(request.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

    #region Public Methods

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() => await JsonGETAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() =>  await JsonGETAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion

    #region Private Methods

        public async Task<Dictionary<string, string>> ReturnBalances()/* => await JsonPOSTAsync <Dictionary<string, string>> (new BalanceRequest());*/
        {
            var r = new BalanceRequest();
            return await JsonPOSTAsync <Dictionary<string, string>> (r);
        }

    #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
