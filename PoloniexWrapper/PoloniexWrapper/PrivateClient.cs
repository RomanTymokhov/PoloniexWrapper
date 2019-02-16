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
        /// <returns>PoloResponse.Answer -> Dictionary</returns>
        public async Task<ResponseObject> ReturnBalancesAsync() =>
            await HttpPostAsync<Dictionary<string, string>>(new BalancesRequest(apiSec));

        /// <summary>
        /// Returns all of your balances, including available balance, balance on orders, and the estimated BTC value of your balance
        /// </summary>
        /// <returns>PoloResponse.Answer -> Dictionary (string, CompleteBalance)</returns>
        public async Task<ResponseObject> ReturnComleteBalancesAsync() =>
            await HttpPostAsync<Dictionary<string, CompleteBalance>>(new CompleteBalancesRequest(apiSec));

        /// <summary>
        /// Returns all of your deposit addresses
        /// </summary>
        /// <returns>PoloResponse.Answer -> Dictionary (string, string) </returns>
        public async Task<ResponseObject> ReturnDepositAdressesAsync() =>
                await HttpPostAsync<Dictionary<string, string>>(new DepositAdressesRequest(apiSec));

        /// <summary>
        /// Generates a new deposit address for the currency specified by the "currency" POST parameter
        /// </summary>
        /// <param name="currID">currency</param>
        /// <returns>PoloResponse.Answer -> NewAdress</returns>
        public async Task<ResponseObject> GenerateNewAddressAsync(string currID) =>
                await HttpPostAsync<NewAdress>(new NewAddressRequest(apiSec, currID));

        /// <summary>
        /// Returns your deposit and withdrawal history within a range, specified by the "start" and "end" POST parameters, both of which should be given as DateTime timestamps
        /// </summary>
        /// <param name="start">DateTime timestamp format</param>
        /// <param name="end">DateTime timestamp format</param>
        /// <returns>PoloResponse.Answer -> DepositsWithdrawals</returns>
        public async Task<ResponseObject> ReturnDepositsWithdrawalsAsync(DateTime start, DateTime end) =>
                await HttpPostAsync<DepositsWithdrawals>(new DepositsWithdrawalsRequest(apiSec, start, end));

        /// <summary>
        /// Returns your balances sorted by account
        /// </summary>
        /// <param name="account">optionally specify the "account" POST parameter if you wish to fetch only the balances of one account</param>
        /// <returns>PoloResponse.Answer -> AvailableAccountBalances</returns>
        public async Task<ResponseObject> ReturnAvailableAccountBalancesAsync(TradingAccount account = all) =>
                await HttpPostAsync<AvailableAccountBalances>(new AvailableAccountBalancesRequest(apiSec, account));

        /// <summary>
        /// If you are enrolled in the maker-taker fee schedule, returns your current trading fees and trailing 30-day volume in BTC
        /// This information is updated once every 24 hours
        /// </summary>
        /// <returns>PoloResponse.Answer -> FeeInfo</returns>
        public async Task<ResponseObject> ReturnFeeInfoAsync() =>
                await HttpPostAsync<FeeInfo>(new FeeInfoRequest(apiSec));


        /// <summary>
        /// Returns your open orders for a given market
        /// Set "currencyPair" to "all" to return open orders for all markets
        /// </summary>
        /// <typeparam name="T"> Dictionary (string, OpenOrder)</typeparam>
        /// <param name="pairID">currencyPair --> allPairs</param>
        /// <returns> Dictionary </returns>
        /// <typeparam name="T"> List OpenOrder </typeparam>
        /// <param name="pairID">currencyPair --> concret pair</param>
        /// <returns> List OpenOrder </returns>
        public async Task<ResponseObject> ReturnOpenOrdersAsync<T>(string pairID = allPairs) =>
                await HttpPostAsync<T>(new OpenOrdersRequest(apiSec, pairID));

        /// <summary>
        /// Returns your trade history for a given market, specified by the "pairID" POST parameter 
        /// </summary>
        /// <typeparam name="T">List PrivateTrade or Dictionary string, Privaterade</typeparam>
        /// <param name="start">DateTime timestamp format</param>
        /// <param name="end">DateTime timestamp format</param>
        /// <param name="pairID">currencyPair ID</param>
        /// <param name="limit">number of entries</param>
        /// <returns>PoloResponse.Answer -> List PrivateTrade or Dictionary string, Privaterade</returns>
        public async Task<ResponseObject> ReturnTradeHistoryAsync<T>(DateTime? start = null, DateTime? end = null, string pairID = allPairs, ushort limit = 500) =>
                await HttpPostAsync<T>(new TradeHistoryRequest(apiSec, pairID, start, end, limit));

        /// <summary>
        /// Returns all trades involving a given order
        /// If no trades for the order have occurred or you specify an order that does not belong to you, you will receive an error
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>PoloResponse.Answer -> List OrderTrade</returns>
        public async Task<ResponseObject> ReturnOrderTradesAsync(ulong orderNumber) =>
                await HttpPostAsync<List<OrderTrade>>(new OrderTradesRequest(apiSec, orderNumber));

        /// <summary>
        /// Returns the status of a given order
        /// If the specified orderNumber is not open, or it is not yours, you will receive an error
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>PoloResponse.Answer -> Dictionary ulong, FillOrder</returns>
        public async Task<ResponseObject> ReturnOrderStatusAsync(ulong orderNumber) =>
            await HttpPostAsync<OrderStatus>(new OrderStatusRequest(apiSec, orderNumber));

        /// <summary>
        /// Method creating orders (buy or sell)
        /// </summary>
        /// <param name="type">order type (buy or sell)</param>
        /// <param name="rate"></param>
        /// <param name="amount"></param>
        /// <param name="pair"></param>
        /// <param name="fillOrKill">optionally - Set to "1" if this order should either fill in its entirety or be completely aborted</param>
        /// <param name="immediateOrCancel">optionally - Set to "1" if this order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled</param>
        /// <param name="postOnly">optionally post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills</param>
        /// <returns>PoloResponse.Answer -> PlaceOrder</returns>
        public async Task<ResponseObject> PlaceOrderAsync(OrderType type, decimal rate, decimal amount, string pair, byte fillOrKill = 0, byte immediateOrCancel = 0, byte postOnly = 0) =>
                await HttpPostAsync<PlacedOrder>(new PlaceOrderRequest(apiSec, type, rate, amount, pair, fillOrKill, immediateOrCancel, postOnly));

        /// <summary>
        /// Cancels an order you have placed in a given market
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <returns>PoloResponse.Answer -> CancelOrder</returns>
        public async Task<ResponseObject> CancelOrderAsync(ulong orderNumber) =>
            await HttpPostAsync<CancelOrder>(new CancelOrderRequest(apiSec, orderNumber));

        /// <summary>
        /// Cancels an order and places a new one of the same type in a single atomic transaction, meaning either both operations will succeed or both will fail
        /// </summary>
        /// <param name="orderNumber">number of given order</param>
        /// <param name="rate"></param>
        /// <param name="amount">optionally specify "amount" if you wish to change the amount of the new order</param>
        /// <param name="postOnly">optionally post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills</param>
        /// <param name="immediateOrCancel">>optionally - Set to "1" if this order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled</param>
        /// <returns>PoloResponse.Answer -> MoveOrder</returns>
        public async Task<ResponseObject> MoveOrderAsync(ulong orderNumber, decimal rate, decimal? amount = null, byte postOnly = 0, byte immediateOrCancel = 0) =>
            await HttpPostAsync<MoveOrder>(new MoveOrderRequest(apiSec, orderNumber, rate, amount, postOnly, immediateOrCancel));

        /// <summary>
        /// Immediately places a withdrawal for a given currency, with no email confirmation
        /// </summary>
        /// <param name="currencyId"></param>
        /// <param name="amount"></param>
        /// <param name="adress">address of the recipient</param>
        /// <param name="paymentId">For XMR & etc. withdrawals, you may optionally specify "paymentId"</param>
        /// <returns>PoloResponse.Answer -> Withdraw</returns>
        public async Task<ResponseObject> WithdrawAsync(string currencyId, decimal amount, string adress, string paymentId = null) =>
            await HttpPostAsync<Withdraw>(new WithdrawRequest(apiSec, currencyId, amount, adress, paymentId));

    }
}
