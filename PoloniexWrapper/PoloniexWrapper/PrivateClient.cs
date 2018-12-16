using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using PoloniexWrapper.Exceptions;
using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using PoloniexWrapper.Data.Responses.TradeHeirs;
using PoloniexWrapper.Data.Responses.OrderHeirs;

using static PoloniexWrapper.Data.PairID;
using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.TradingAccount;

namespace PoloniexWrapper
{
    public sealed class PrivateClient : PoloClient
    {
        private readonly string apiSec;

        public PrivateClient(string apiKey, string apiSec) : base(apiKey)
        {
            this.apiSec = apiSec;
        }

        public async Task<Dictionary<string, string>> ReturnBalancesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        public async Task<Dictionary<string, CompleteBalance>> ReturnComleteBalancesAsync() =>
                await HttpPostAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        public async Task<Dictionary<string, string>> ReturnDepositAdressesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new DepositAdressesRequest(apiSec));

        public async Task<NewAdress> GenerateNewAddressAsync(string currID) =>
                await HttpPostAsync<NewAdress>(new NewAddressRequest(apiSec, currID));

        public async Task<DepositsWithdrawals> ReturnDepositsWithdrawalsAsync(DateTime start, DateTime end) =>
                await HttpPostAsync<DepositsWithdrawals>(new DepositsWithdrawalsRequest(apiSec, start, end));

        public async Task<AvailableAccountBalances> ReturnAvailableAccountBalancesAsync(TradingAccount account = all) =>
                await HttpPostAsync<AvailableAccountBalances>(new AvailableAccountBalancesRequest(apiSec, account));

        public async Task<FeeInfo> ReturnFeeInfoAsync() => 
                await HttpPostAsync<FeeInfo>(new FeeInfoRequest(apiSec));


        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T"> Dictionary<string, List<OpenOrder>> </typeparam>
        /// <param name="pairID">allPairs</param>
        /// <returns> Dictionary<string, List<OpenOrder>> </returns>
        /// <typeparam name="T"> List<OpenOrder> </typeparam>
        /// <param name="pairID">concret pair</param>
        /// <returns> List<OpenOrder> </returns>
        public async Task<T> ReturnOpenOrdersAsync<T>(string pairID = allPairs) =>
                await HttpPostAsync<T>(new OpenOrdersRequest(apiSec, pairID));

        /// <summary>
        /// Returns your trade history for a given market, specified by the "pairID" POST parameter 
        /// </summary>
        /// <typeparam name="T">List<PrivateTrade> or Dictionary<string, List<PrivateTrade>></string></typeparam>
        /// <param name="start">UNIX timestamp format</param>
        /// <param name="end">UNIX timestamp format</param>
        /// <param name="pairID">currencyPair ID</param>
        /// <param name="limit">number of entries</param>
        /// <returns></returns>
        public async Task<T> ReturnTradeHistoryAsync<T>(DateTime? start = null, DateTime? end = null, string pairID = allPairs, ushort limit = 500) =>
                await HttpPostAsync<T>(new TradeHistoryRequest(apiSec, pairID, start, end, limit));

        public async Task<List<OrderTrade>> ReturnOrderTradesAsync(ulong? orderNumber) =>
                await HttpPostAsync<List<OrderTrade>>(new OrderTradesRequest(apiSec, orderNumber));

        public async Task<Dictionary<ulong?, FillOrder>> ReturnOrderStatusAsync(ulong? orderNumber)
        {
            var answer = await HttpPostAsync<OrderStatus>(new OrderStatusRequest(apiSec, orderNumber));

            if (answer.Success == 1) return await UnpackingResponseAsync<Dictionary<ulong?, FillOrder>>(answer.Result);
            else throw new PoloException(UnpackingResponseAsync<Error>(answer.Result).Result.ErrorMessage);
        }

        /// <summary>
        /// Method creating orders (buy or sell)
        /// </summary>
        /// <param name="type">order type (buy or sell)</param>
        /// <param name="rate"></param>
        /// <param name="amount"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        public async Task<PlaceOrder> PlaceOrderAsync(OrderType type, decimal rate, decimal amount, string pair, byte postOnly = 0) =>      
                await HttpPostAsync<PlaceOrder>(new PlaceOrderRequest(apiSec, type, rate, amount, pair, postOnly));

        public async Task<CancelOrder> CancelOrderAsync(ulong orderNumber)
        {
            var answer = await HttpPostAsync<CancelOrder>(new CancelOrderRequest(apiSec, orderNumber));

            if (answer.Success != 0) return answer;
            else throw new PoloException(answer.ErrorMessage);
        }

        public async Task<MoveOrder> MoveOrderAsync(ulong orderNumber, decimal rate, decimal? amount = null, byte postOnly = 0)
        {
            var answer = await HttpPostAsync<MoveOrder>(new MoveOrderRequest(apiSec, orderNumber, rate, amount, postOnly));

            if (answer.Success != 0) return answer;
            else throw new PoloException(answer.ErrorMessage);
        }

        public async Task<Withdraw> WithdrawAsync(string currencyId, decimal amount, string adress) =>
                await HttpPostAsync<Withdraw>(new WithdrawRequest(apiSec, currencyId, amount, adress));
    }
}
