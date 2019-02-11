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
        public PublicClient(bool devMode) : base(devMode) { }

        /// <summary>
        /// Returns the ticker for all markets
        /// </summary>
        /// <returns>PoloResponse.Answer -> Dictionary string, Ticker </returns>
        public async Task<PoloResponse> ReturnTickerAsync() =>
            await GenerateAnswer<Dictionary<string, Ticker>>(new TickerRequest());


        /// <summary>
        /// Returns the 24-hour volume for all markets, plus totals for primary currencies
        /// </summary>
        /// <returns>PoloResponse.Answer -> DalyVolumes</returns>
        public async Task<PoloResponse> ReturnDalyVolumesAsync() =>
            await GenerateAnswer<DalyVolumes>(new DalyVolumeRequest());


        /// <summary>
        /// Returns the order book for a given market, as well as a sequence number for use with the Push API and an indicator specifying whether the market is frozen
        /// </summary>
        /// <typeparam name="T">OrderBook or Dictonary string, Orderook </typeparam>
        /// <param name="pairId">allPairs --> Dictionary, particular pair --> OrderBook</param>
        /// <param name="depthSize">deep of depth, default(null) = 50, max = 20k</param>
        /// <returns>OrderBook or Dictonary string, Orderook </returns>
        public async Task<PoloResponse> ReturnOrderBookAsync<T>(string pairId = allPairs, ushort? depthSize = null) =>
                await GenerateAnswer<T>(new OrderBookRequest(pairId, depthSize));

        ///// <summary>
        ///// Returns the past 200 trades for a given market, or up to 50,000 trades between a range specified in DateTime timestamps by the "start" and "end"
        ///// </summary>
        ///// <param name="start">DateTime timestamp format</param>
        ///// <param name="end">DateTime timestamp format</param>
        ///// <param name="pairID">currencyPair ID</param>
        ///// <returns></returns>
        //public async Task<List<PublicTrade>> ReturnTradeHistoryAsync(string pairID, DateTime? start = null, DateTime? end = null) =>
        //        await HttpGetAsync<List<PublicTrade>>(new TradeHistoryRequest(pairID, start, end));

        ///// <summary>
        ///// Returns candlestick chart data
        ///// </summary>
        ///// <param name="pairId">currencyPair</param>
        ///// <param name="period">candlestick period in seconds; valid values are 300, 900, 1800, 7200, 14400, and 86400</param>
        ///// <param name="start">DateTime timestamp format</param>
        ///// <param name="end">DateTime timestamp format</param>
        ///// <returns></returns>
        //public async Task<List<Candlestick>> ReturnChartDataAsync(string pairId, uint period, DateTime start, DateTime end) =>
        //        await HttpGetAsync<List<Candlestick>>(new ChartDataRequest(pairId, period, start, end));

        ///// <summary>
        ///// Returns information about currencies
        ///// </summary>
        ///// <returns>Currencies</returns>
        //public async Task<Currencies> ReturnCurrenciesAsync() =>
        //        await HttpGetAsync<Currencies>(new CurrenciesRequest());
    }
}
