using System.Collections.Generic;
using System.Threading.Tasks;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;

using static PoloniexWrapper.Data.PairID;

namespace PoloniexWrapper
{
    public class PublicClient : PoloClient
    {
        public PublicClient() : base() { }

        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() =>
               await HttpGetAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() =>
                await HttpGetAsync<DalyVolumes>(new DalyVolumeRequest());

        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T">OrderBook or Dictonary<string, Orderook></string></typeparam>
        /// <param name="pairId">allPairs --> Dictionary, particular pair --> OrderBook</param>
        /// <param name="depthSize">deep of depth, default(null) = 50, max = 20k</param>
        /// <returns>OrderBook or Dictonary<string, Orderook></returns>
        public async Task<T> ReturnOrderBookAsync<T>(string pairId = allPairs, ushort? depthSize = null) =>
                await HttpGetAsync<T>(new OrderBookRequest(pairId, depthSize));

        //dfsdfsdfsdfsdf
    }
}
