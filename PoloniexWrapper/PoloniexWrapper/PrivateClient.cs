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

        /// <summary>
        /// Returns all of your available balances
        /// </summary>
        /// <returns>Dictionary</returns>
        public async Task<Dictionary<string, string>> ReturnBalancesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        /// <summary>
        /// Returns all of your balances, including available balance, balance on orders, and the estimated BTC value of your balance
        /// </summary>
        /// <returns>Dictionary</returns>
        public async Task<Dictionary<string, CompleteBalance>> ReturnComleteBalancesAsync() =>
                await HttpPostAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        /// <summary>
        /// Returns all of your deposit addresses
        /// </summary>
        /// <returns>Dictionary</returns>
        public async Task<Dictionary<string, string>> ReturnDepositAdressesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new DepositAdressesRequest(apiSec));

        /// <summary>
        /// Generates a new deposit address for the currency specified by the "currency" POST parameter
        /// </summary>
        /// <param name="currID">currency</param>
        /// <returns>NewAdress</returns>
        public async Task<NewAdress> GenerateNewAddressAsync(string currID) =>
                await HttpPostAsync<NewAdress>(new NewAddressRequest(apiSec, currID));

        /// <summary>
        /// Returns your deposit and withdrawal history within a range, specified by the "start" and "end" POST parameters, both of which should be given as DateTime timestamps
        /// </summary>
        /// <param name="start">DateTime timestamp format</param>
        /// <param name="end">DateTime timestamp format</param>
        /// <returns>DepositsWithdrawals</returns>
        public async Task<DepositsWithdrawals> ReturnDepositsWithdrawalsAsync(DateTime start, DateTime end) =>
                await HttpPostAsync<DepositsWithdrawals>(new DepositsWithdrawalsRequest(apiSec, start, end));

        /// <summary>
        /// Returns your balances sorted by account
        /// </summary>
        /// <param name="account">optionally specify the "account" POST parameter if you wish to fetch only the balances of one account</param>
        /// <returns>AvailableAccountBalances</returns>
        public async Task<AvailableAccountBalances> ReturnAvailableAccountBalancesAsync(TradingAccount account = all) =>
                await HttpPostAsync<AvailableAccountBalances>(new AvailableAccountBalancesRequest(apiSec, account));

        /// <summary>
        /// If you are enrolled in the maker-taker fee schedule, returns your current trading fees and trailing 30-day volume in BTC
        /// This information is updated once every 24 hours
        /// </summary>
        /// <returns>FeeInfo</returns>
        public async Task<FeeInfo> ReturnFeeInfoAsync() => 
                await HttpPostAsync<FeeInfo>(new FeeInfoRequest(apiSec));


        /// <summary>
        /// Returns your open orders for a given market
        /// Set "currencyPair" to "all" to return open orders for all markets
        /// </summary>
        /// <typeparam name="T"> Dictionary string, OpenOrder</typeparam>
        /// <param name="pairID">currencyPair --> allPairs</param>
        /// <returns> Dictionary </returns>
        /// <typeparam name="T"> List OpenOrder </typeparam>
        /// <param name="pairID">currencyPair --> concret pair</param>
        /// <returns> List OpenOrder </returns>
        public async Task<T> ReturnOpenOrdersAsync<T>(string pairID = allPairs) =>
                await HttpPostAsync<T>(new OpenOrdersRequest(apiSec, pairID));

        /// <summary>
        /// Returns your trade history for a given market, specified by the "pairID" POST parameter 
        /// </summary>
        /// <typeparam name="T">List PrivateTrade or Dictionary string, Privaterade</typeparam>
        /// <param name="start">DateTime timestamp format</param>
        /// <param name="end">DateTime timestamp format</param>
        /// <param name="pairID">currencyPair ID</param>
        /// <param name="limit">number of entries</param>
        /// <returns>List PrivateTrade or Dictionary string, Privaterade</returns>
        public async Task<T> ReturnTradeHistoryAsync<T>(DateTime? start = null, DateTime? end = null, string pairID = allPairs, ushort limit = 500) =>
                await HttpPostAsync<T>(new TradeHistoryRequest(apiSec, pairID, start, end, limit));

        /// <summary>
        /// Returns all trades involving a given order
        /// If no trades for the order have occurred or you specify an order that does not belong to you, you will receive an error
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>OrderTrade</returns>
        public async Task<List<OrderTrade>> ReturnOrderTradesAsync(ulong orderNumber) =>
                await HttpPostAsync<List<OrderTrade>>(new OrderTradesRequest(apiSec, orderNumber));

        /// <summary>
        /// Returns the status of a given order
        /// If the specified orderNumber is not open, or it is not yours, you will receive an error
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>Dictionary ulong, FillOrder</returns>
        public async Task<Dictionary<ulong, FillOrder>> ReturnOrderStatusAsync(ulong orderNumber)
        {
            var answer = await HttpPostAsync<OrderStatus>(new OrderStatusRequest(apiSec, orderNumber));

            if (answer.Success == 1) return await UnpackingResponseAsync<Dictionary<ulong, FillOrder>>(answer.Result);
            else throw new PoloException(UnpackingResponseAsync<Error>(answer.Result).Result.ErrorMessage);
        }

        /// <summary>
        /// Method creating orders (buy or sell)
        /// </summary>
        /// <param name="type">order type (buy or sell)</param>
        /// <param name="rate"></param>
        /// <param name="amount"></param>
        /// <param name="pair"></param>
        /// <param name="postOnly">optionally post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills</param>
        /// <returns>PlaceOrder</returns>
        public async Task<PlaceOrder> PlaceOrderAsync(OrderType type, decimal rate, decimal amount, string pair, byte postOnly = 0) =>      
                await HttpPostAsync<PlaceOrder>(new PlaceOrderRequest(apiSec, type, rate, amount, pair, postOnly));

        /// <summary>
        /// Cancels an order you have placed in a given market
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>CancelOrder</returns>
        public async Task<CancelOrder> CancelOrderAsync(ulong orderNumber)
        {
            var answer = await HttpPostAsync<CancelOrder>(new CancelOrderRequest(apiSec, orderNumber));

            if (answer.Success != 0) return answer;
            else throw new PoloException(answer.ErrorMessage);
        }

        /// <summary>
        /// Cancels an order and places a new one of the same type in a single atomic transaction, meaning either both operations will succeed or both will fail
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <param name="rate"></param>
        /// <param name="amount">optionally specify "amount" if you wish to change the amount of the new order</param>
        /// <param name="postOnly">optionally post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills</param>
        /// <returns></returns>
        public async Task<MoveOrder> MoveOrderAsync(ulong orderNumber, decimal rate, decimal? amount = null, byte postOnly = 0)
        {
            var answer = await HttpPostAsync<MoveOrder>(new MoveOrderRequest(apiSec, orderNumber, rate, amount, postOnly));

            if (answer.Success != 0) return answer;
            else throw new PoloException(answer.ErrorMessage);
        }

        /// <summary>
        /// Immediately places a withdrawal for a given currency, with no email confirmation
        /// </summary>
        /// <param name="currencyId"></param>
        /// <param name="amount"></param>
        /// <param name="adress"></param>
        /// <returns></returns>
        public async Task<Withdraw> WithdrawAsync(string currencyId, decimal amount, string adress) =>
                await HttpPostAsync<Withdraw>(new WithdrawRequest(apiSec, currencyId, amount, adress));
    }
}
