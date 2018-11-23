using Newtonsoft.Json;
using PoloniexWrapper.Data;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

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

        public PoloClient(string apiKey):base()
        {
            ApiKey = apiKey;
        }

        protected async Task<T> JsonGETAsync<T>(BaseRequest request)
        {
            var str = request.ToString();
<<<<<<< HEAD
            var response = await httpClient.GetAsync(request.Make().Result).ConfigureAwait(false);
=======
            var response = await httpClient.GetAsync(request.Url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> JsonPOSTAsync<T>(BaseRequest request)
        {
            var response = await httpClient.PostAsync(request.Url,
                new StringContent("? todo", Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);
>>>>>>> dev/tohoff82

            response.EnsureSuccessStatusCode();         // throw if web request failed
            //todo: creae Exception handler

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

    #region Public Methods
<<<<<<< HEAD
=======

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() => await JsonGETAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() =>  await JsonGETAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion
>>>>>>> dev/tohoff82

    #region Private Methods

<<<<<<< HEAD
        public async Task<DalyVolumes> GetDalyVolumeAsync() =>  await JsonGETAsync<DalyVolumes> (new DalyVolumeRequest());

    #endregion

    #region Private Methods
        //TODO 
=======
        public async Task<Dictionary<string, string>> ReturnBalances() => await JsonPOSTAsync <Dictionary<string, string>> (new BalanceRequest());

>>>>>>> dev/tohoff82
    #endregion

        public void Dispose() => httpClient.Dispose();
    }
}
