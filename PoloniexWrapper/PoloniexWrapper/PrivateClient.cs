﻿using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.TradingAccount;
using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Data.PairID;

namespace PoloniexWrapper
{
    public class PrivateClient : PoloClient
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

        public async Task<FeeInfo> ReturnFeeInfoAsync() => await HttpPostAsync<FeeInfo>(new FeeInfoRequest(apiSec));


        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T"> Dictionary<string, List<Order>> </typeparam>
        /// <param name="pairID">allPairs</param>
        /// <returns> Dictionary<string, List<Order>> </returns>
        /// <typeparam name="T"> List<Order> </typeparam>
        /// <param name="pairID">concret pair</param>
        /// <returns> List<Order> </returns>

        public async Task<T> ReturnOpenOrdersAsync<T>(string pairID = allPairs) =>
                await HttpPostAsync<T>(new OpenOrdersRequest(apiSec, pairID));


        /// <summary>
        /// depending on "pairID" return a specific result
        /// </summary>
        /// <typeparam name="T"> List<Trade> or Dictionary<string, List<Trade>> </typeparam>
        /// <param name="apiSec"> apiSec </param>
        /// <param name="pairID"> pairId</param>
        /// <param name="start"> time period begin</param>
        /// <param name="end"> time period end</param>
        /// <param name="limit"> quontity trades (minimum = 500, maximum = 10 000), if you do not specify a "limit", it will be limited to one day  </param>
        /// <returns></returns>

        public async Task<T> ReturnTradeHistoryAsync<T>(DateTime start, DateTime end, string pairID = allPairs, ushort limit = 500) =>
                await HttpPostAsync<T>(new TradeHistoryRequest(apiSec, start, end, pairID, limit));
    }
}