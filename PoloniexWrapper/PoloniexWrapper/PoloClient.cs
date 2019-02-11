using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
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
        private readonly bool IsDevelopmentMode = true;

        public PoloClient(bool devMode)
        {
            IsDevelopmentMode = devMode;
            httpClient = new HttpClient { BaseAddress = new Uri("https://poloniex.com") };
        }
        public PoloClient(bool devMode, string apiKey) : this(devMode)
        {
            httpClient.DefaultRequestHeaders.Add("Key", apiKey);
        }

        protected async Task<HttpResponseMessage> HttpGetAsync(RequestObject requestObj)
        {
            return await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);
        }

        protected async Task<HttpResponseMessage> HttpPostAsync(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            return await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);
        }

        protected async Task<T> UnpackingResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }
        protected async Task<T> UnpackingResponseAsync<T>(object responseMessage) =>
                    await Task.Run(() => JsonConvert.DeserializeObject<T>(responseMessage.ToString()));

        protected async  Task<Error> CheckStatusCodeOk(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<Error>(json);
                if (response.Content != null) response.Content.Dispose();
                if (!IsDevelopmentMode) return error;
                else
                {
                    throw new PoloException($"{NewLine} StatusCode:   {(ushort)response.StatusCode},  {response.StatusCode.ToString()}" +
                                            $"{NewLine} ErrorMessage: {error.ErrorMessage}");
                }
            }
            else return null;
        }

        protected async Task<PoloResponse> GenerateAnswer<T>(RequestObject requestObj)
        {
            var response = await HttpGetAsync(requestObj);
            var error = await CheckStatusCodeOk(response);

            if (error == null)
            {
                var answer = await UnpackingResponseAsync<T>(response);
                return new PoloResponse { Success = true, Answer = answer, Error = null };
            }
            else
            {
                return new PoloResponse { Success = false, Answer = null, Error = error };
            }
        }

        public void Dispose() => httpClient.Dispose();
    }
}
