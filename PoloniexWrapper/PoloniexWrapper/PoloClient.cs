using Newtonsoft.Json;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoloniexWrapper
{
    public class PoloClient : IDisposable
    {
        private string ApiKey { get; set; }

        private readonly HttpClient httpClient;

        private const string baseAddress = "https://poloniex.com";


        public PoloClient(string apiKey)
        {
            ApiKey = apiKey;
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        protected async Task<T> JsonGETAsync<T>(BaseRequest request)
        {
            var response = await httpClient.GetAsync(request.ToString()).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }


        public async Task<Ticker> GetTickerAsync() => await JsonGETAsync<Ticker>(new TickerRequest(ApiKey));



        public void Dispose() => httpClient.Dispose();
    }
}
