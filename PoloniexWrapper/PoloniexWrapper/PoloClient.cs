using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Exceptions;
using PoloniexWrapper.Helper;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using PoloniexWrapper.Data.Responses;

namespace PoloniexWrapper
{
    public abstract class PoloClient : IDisposable
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

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            return await Task.Run(() => GetAnswerWihCheckException<T>(response));
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(), 
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            return await Task.Run(() => GetAnswerWihCheckException<T>(response));
        }

        private Task<T> GetAnswerWihCheckException<T>(HttpResponseMessage responseMessage)
        {
            var successResponse = new SuccessResponse(responseMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PoloException(successResponse.Error.ErrorMessage);
            if (responseMessage.IsSuccessStatusCode && !successResponse.Status)
                throw new PoloException(successResponse.Error.ErrorMessage);
            else return successResponse.GetMessage<T>(responseMessage);
        }

        public void Dispose() => httpClient.Dispose();
    }
}
