using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using PoloniexWrapper.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System;

namespace PoloniexWrapper
{
    public abstract class PoloClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public PoloClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://poloniex.com") };
        }

        public PoloClient(string apiKey) : this()
        {
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
        }

        protected async Task<ResponseObject> HttpGetAsync<T>(RequestObject requestObj)
        {
            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            return response.Unpack<T>();
        }

        protected async Task<ResponseObject> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            return response.Unpack<T>();
        }

        public void Dispose() => httpClient.Dispose();
    }
}
