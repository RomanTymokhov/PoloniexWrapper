using Newtonsoft.Json;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoloniexWrapper
{
    public class PoloClient : IDisposable
    {
        private string ApiKey { get; set; }

        private readonly HttpClient httpClient;

        private const string baseAddress = "https://poloniex.com";

        public PoloClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public PoloClient(string apiKey)
        {
            ApiKey = apiKey;
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        protected async Task<T> JsonGETAsync<T>(BaseRequest request)
        {
            var str = request.ToString();
            var response = await httpClient.GetAsync(request.ToString()).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }


        public async Task<Dictionary<string, Ticker>> GetTickerAsync() => await JsonGETAsync<Dictionary<string, Ticker>>(new TickerRequest());



        public void Dispose() => httpClient.Dispose();
    }
}
