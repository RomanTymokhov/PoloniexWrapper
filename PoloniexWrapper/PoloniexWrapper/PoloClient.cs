using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

namespace PoloniexWrapper
{
    public abstract class PoloClient : IDisposable
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://poloniex.com";

        public PoloClient() => httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };

        public PoloClient(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
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

        public void Dispose() => httpClient.Dispose();
    }
}
