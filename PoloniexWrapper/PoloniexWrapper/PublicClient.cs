using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using PoloniexWrapper.Data.Responses.TradeHeirs;

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

        /// <summary>
        /// Returns the past 200 trades for a given market, or up to 50,000 trades between a range specified in UNIX timestamps by the "start" and "end"
        /// </summary>
        /// <param name="start">UNIX timestamp format</param>
        /// <param name="end">UNIX timestamp format</param>
        /// <param name="pairID">currencyPair ID</param>
        /// <returns></returns>
        public async Task<List<PublicTrade>> ReturnTradeHistoryAsync(string pairID, DateTime? start = null, DateTime? end = null) =>
                await HttpPostAsync<List<PublicTrade>>(new TradeHistoryRequest(pairID, start, end));
    }
}
