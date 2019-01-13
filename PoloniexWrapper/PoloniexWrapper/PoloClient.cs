using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Exceptions;
using PoloniexWrapper.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System;
using Newtonsoft.Json;

using static System.Environment;

namespace PoloniexWrapper
{
    public abstract class PoloClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public PoloClient() => httpClient = new HttpClient { BaseAddress = new Uri("https://poloniex.com") };
        public PoloClient(string apiKey) : this() => httpClient.DefaultRequestHeaders.Add("Key", apiKey);

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            await EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            await EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        protected async Task<T> UnpackingResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }
        protected async Task<T> UnpackingResponseAsync<T>(object responseMessage) =>
                    await Task.Run(() => JsonConvert.DeserializeObject<T>(responseMessage.ToString()));

        private async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                if (response.Content != null) response.Content.Dispose();

                string message = JsonConvert.DeserializeObject<Error>(json).ErrorMessage;

                throw new PoloException($"{NewLine} StatusCode:   {(ushort)response.StatusCode},  {response.StatusCode.ToString()}" +
                                        $"{NewLine} ErrorMessage: {message}");
            }
        }

        public void Dispose() => httpClient.Dispose();
    }
}
