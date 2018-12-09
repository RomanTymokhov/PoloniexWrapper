using System;
using System.Linq;
using System.Collections.Generic;

using PoloniexWrapper;
using PoloniexWrapper.Data;
using PoloniexWrapper.Data.Responses.TradeHeirs;
using PoloniexWrapper.Data.Responses.OrderHeirs;

using static System.Console;
using static PoloniexWrapper.Data.PairID;
using static PoloniexWrapper.Data.CurrencieID;
using static PoloniexWrapper.Helper.Enums;
using static PoloniexWrapper.Helper.Enums.TradingAccount;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var poloClientPub = new PublicClient();



            //GetTickerData(poloClientPub, usdc_str);
            //GetDalyVolume(poloClientPub, btc_eth);
            //GetBalances(poloClientPriv, sc);
            //GetCompleteBalances(poloClientPriv, xem);
            //GetDepositAdresses(poloClientPriv, etc);
            //GetNewAdress(poloClientPriv, etc);
            //GetDepositsWithdravals(poloClientPriv, new DateTime(2017, 10, 1), DateTime.Now);
            //GetAvailableAccountBalances(poloClientPriv, exchange, eth);
            //GetFeeInfo(poloClientPriv);
            //GetOpenOrders(poloClientPriv, btc_xem);
            //GetTradeHistory(poloClientPriv, new DateTime(2018, 01, 30), DateTime.Now, allPairs, 1000);
            GetOrderTrades(poloClientPriv, 62593394139);

        }

        private static void GetTickerData(PublicClient client, string tickerID)
        {
            var ticker = client.ReturnTickerAsync().Result.FirstOrDefault(tckr => tckr.Key == tickerID).Value;

            WriteLine("LastPrice --> " + ticker.LastPrice);
            WriteLine("LowestAsk --> " + ticker.LowestAsk);
            WriteLine("HighestBid --> " + ticker.HighestBid);
            WriteLine("PercentChange --> " + ticker.PercentChange);
            WriteLine("BaseVolume --> " + ticker.BaseVolume);
            WriteLine("QuoteVolume --> " + ticker.QuoteVolume);
            WriteLine("--------------------------------------------");
        }
        private static void GetDalyVolume(PublicClient client, string tickerID)
        {
            var dv = client.ReturnDalyVolumesAsync().Result.VolumeList.FirstOrDefault(i => i.pairID == tickerID);

            WriteLine("VolumePair --> " + dv.pairID);
            WriteLine(dv.baseCurrencyName + " -- " + dv.baseCurrencyVolume);
            WriteLine(dv.quotedCurrencyName + " -- " + dv.quotedCurrencyVolume);
            WriteLine("--------------------------------------------");
        }

        private static void GetBalances(PrivateClient client, string currID)
        {
            var b = client.ReturnBalancesAsync().Result.FirstOrDefault(c => c.Key == currID);

            WriteLine("Ballance " + b.Key + " = " + b.Value);
            WriteLine("--------------------------------------------");
        }
        private static void GetCompleteBalances(PrivateClient client, string currId)
        {
            var b = client.ReturnComleteBalancesAsync().Result.FirstOrDefault(k => k.Key == currId);

            WriteLine("Avalible --> " + b.Value.Availabel);
            WriteLine("OnOrders --> " + b.Value.OnOrders);
            WriteLine("BtcValue --> " + b.Value.BtcValue);
            WriteLine("--------------------------------------------");
        }
        private static void GetDepositAdresses(PrivateClient client, string currId)
        {
            var a = client.ReturnDepositAdressesAsync().Result.FirstOrDefault(k => k.Key == currId);

            WriteLine(a.Key + " -- " + a.Value);
            WriteLine("--------------------------------------------");
        }
        private static void GetNewAdress(PrivateClient client, string currId)
        {
            var na = client.GenerateNewAddressAsync(currId).Result;

            WriteLine("new " + currId + " adress --> " + na.Response);
            WriteLine("--------------------------------------------");
        }
        private static void GetDepositsWithdravals(PrivateClient client, DateTime start, DateTime end)
        {
            var dw = client.ReturnDepositsWithdrawalsAsync(start, end).Result;

            WriteLine("------------  DepositList  -----------");
            foreach (var deposit in dw.DepositList)
            {
                WriteLine("Adress --> " + deposit.Adress);
                WriteLine("Amount --> " + deposit.Amount);
                WriteLine("Confirmation --> " + deposit.Confirmations);
                WriteLine("Currecy --> " + deposit.CurrencyID);
                WriteLine("Status --> " + deposit.Status);
                WriteLine("Timestamp --> " + deposit.Timestamp);
                WriteLine("TxID --> " + deposit.TxID);
                WriteLine("*******************");
            }

            WriteLine("------------  WithdrawalList  -------------");
            foreach (var witdrawal in dw.WithdrawalList)
            {
                WriteLine("Adress --> " + witdrawal.Adress);
                WriteLine("Amount --> " + witdrawal.Amount);
                WriteLine("Currency --> " + witdrawal.CurrencyID);
                WriteLine("IpAdress --> " + witdrawal.IpAdress);
                WriteLine("Status --> " + witdrawal.Status);
                WriteLine("Timestamp --> " + witdrawal.Timestamp);
                WriteLine("WithdrawalID --> " + witdrawal.WithdrawalID);
                WriteLine("******************");
            }
        }
        private static void GetAvailableAccountBalances(PrivateClient client, TradingAccount acc, string currId)
        {
            var aab = client.ReturnAvailableAccountBalancesAsync(acc).Result;

            foreach (var aacc in aab.Exchange)
            {
                WriteLine(aacc.Key + " -- " + aacc.Value);
            }
            WriteLine("--------------------------------------------");

            WriteLine(currId + " -- " + aab.Exchange.FirstOrDefault(p => p.Key == currId).Value);
        }
        private static void GetFeeInfo(PrivateClient client)
        {
            var fi = client.ReturnFeeInfoAsync().Result;

            WriteLine("MakerFee --> " + fi.MakerFee);
            WriteLine("TakerFee --> " + fi.TakerFee);
            WriteLine("ThirtyDayVolume --> " + fi.ThirtyDayVolume);
            WriteLine("NextTier --> " + fi.NextTier);
        }
        private static void GetOpenOrders(PrivateClient client, string pairId)
        {
            if(pairId == allPairs)
            {
                var ol = client.ReturnOpenOrdersAsync<Dictionary<string, List<OpenOrder>>>().Result;

                foreach (var item in ol)
                {
                    foreach (var order in item.Value)
                    {

                    WriteLine(item.Key + " -- " + item.Value.FirstOrDefault(k => k.Margin == 0).Rate + " -- "
                                                + item.Value.FirstOrDefault(k => k.Margin == 0).Amount + " -- "
                                                + item.Value.FirstOrDefault(k => k.Margin == 0).DateTime.ToLocalTime());

                    }
                }
            }
            else
            {
                var oo = client.ReturnOpenOrdersAsync<List<OpenOrder>>(pairId).Result;

                WriteLine("Rate --> " + oo.FirstOrDefault(k => k.Margin == 0).Rate);
                WriteLine("Amount --> " + oo.FirstOrDefault(k => k.Margin == 0).Amount);
                WriteLine("DateTime --> " + oo.FirstOrDefault(k => k.Margin == 0).DateTime.ToLocalTime());
                WriteLine("OrderNumber --> " + oo.FirstOrDefault(k => k.Margin == 0).OrderNumber);
            }            
        }
        private static void GetTradeHistory(PrivateClient client, DateTime start, DateTime end, string pairID, ushort limit)
        {
            if (pairID == allPairs)
            {
                var dict = client.ReturnTradeHistoryAsync<Dictionary<string, List<Trade>>>(start, end).Result;
                var tradeList = dict.FirstOrDefault(p => p.Key == btc_xrp).Value;
                var trade = tradeList.FirstOrDefault(t => t.AccountCategory == exchange.ToString());

                WriteLine(" GlobalTradeID--> " + trade.GlobalTradeID);
                WriteLine(" TradeID--> " + trade.TradeID);
                WriteLine(" OrderNumber--> " + trade.OrderNumber);
                WriteLine(" Type--> " + trade.Type);
                WriteLine(" Rate--> " + trade.Rate);
                WriteLine(" Amount--> " + trade.Amount);
                WriteLine(" Fee--> " + trade.Fee);
                WriteLine(" DateTime--> " + trade.DateTime);
                WriteLine(" AccountCategory--> " + trade.AccountCategory);
                WriteLine("--------------------------------------------");
            }
        }
        private static void GetOrderTrades(PrivateClient client, ulong? orderNumber)
        {
            var o = client.ReturnOrderTradesAsync(orderNumber).Result;

            foreach (var trade in o)
            {
                WriteLine(" GlobalTradeID--> " + trade.GlobalTradeID);
                WriteLine(" TradeID--> " + trade.TradeID);
                WriteLine(" CurrencyPair--> " + trade.CurrencyPair);
                WriteLine(" Type--> " + trade.Type);
                WriteLine(" Rate--> " + trade.Rate);
                WriteLine(" Amount--> " + trade.Amount);
                WriteLine(" Total--> " + trade.Total);
                WriteLine(" Fee--> " + trade.Fee);
                WriteLine(" DateTime--> " + trade.DateTime);
                WriteLine("--------------------------------------------");
            }
        }
    }
}
