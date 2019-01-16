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
using static PoloniexWrapper.Helper.Enums.RequestType;
using static PoloniexWrapper.Helper.Enums.OrderType;
using PoloniexWrapper.Exceptions;
using Newtonsoft.Json;
using PoloniexWrapper.Data.Responses;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var poloClientPub = new PublicClient();

            //GetTickerData(poloClientPub, usdc_str);
            //GetDalyVolume(poloClientPub, btc_eth);
            //GetOrderBook(poloClientPub, usdc_usdt, 50000);
            //GetPublicTradeHistory(poloClientPub, new DateTime(2018, 11, 18), DateTime.Now, btc_sc);
            //GetChartData(poloClientPub, btc_xrp, 86400, new DateTime(2018, 01, 30), DateTime.Now);
            //GetCurrecies(poloClientPub);

            //GetBalances(poloClientPriv, sc);
            GetCompleteBalances(poloClientPriv, xem);
            //GetDepositAdresses(poloClientPriv, str);
            //GetNewAdress(poloClientPriv, etc);
            //GetDepositsWithdravals(poloClientPriv, new DateTime(2017, 10, 1), DateTime.Now);
            //GetAvailableAccountBalances(poloClientPriv, exchange, eth);
            //GetFeeInfo(poloClientPriv);
            //GetOpenOrders(poloClientPriv, allPairs);
            //GetTradeHistory(poloClientPriv, new DateTime(2018, 01, 30), DateTime.Now, btc_xrp, 1000);
            //GetOrderTrades(poloClientPriv, 62593394139);
            //GetOrderStatus(poloClientPriv, 57731672650);
            //PlaceOrder(poloClientPriv, sell, 0.00000075m, 133.4m, btc_sc );
            //CancelOrder(poloClientPriv, 26957718447);
            //MoveOrder(poloClientPriv, 26957578587, 0.00000211m);
            //Withdraw(poloClientPriv, str, 0.0000001m, "GAIYQHE4K6YBTZJUMFWBH4AALTZZWQQ6HT6GTM6VK2FLQDC6TK7QR3QQ", "260825634");

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
            var obj = client.ReturnDalyVolumesAsync().Result;
            var dv = obj.VolumeList.FirstOrDefault(i => i.pairID == tickerID);

            WriteLine("TotalBTC --> " + obj.TotalBTC);
            WriteLine("VolumePair --> " + dv.pairID);
            WriteLine(dv.baseCurrencyName + " -- " + dv.baseCurrencyVolume);
            WriteLine(dv.quotedCurrencyName + " -- " + dv.quotedCurrencyVolume);
            WriteLine("--------------------------------------------");
        }
        private static void GetOrderBook(PublicClient client, string pairId, ushort deptSize)
        {
            var ob = client.ReturnOrderBookAsync < Dictionary<string, OrderBook>>(/*pairId*/depthSize: deptSize).Result;
            var obj = ob.FirstOrDefault(p => p.Key == "BTC_SC").Value;
            WriteLine("----" + obj.SequenceId);
            //WriteLine("IsFrozen --> " + ob.IsFrozen);
            //WriteLine("SequenceId --> " + ob.SequenceId);
            //WriteLine("Rate -- Amount (Asks) --> " + ob.Asks.First().Rate + " -- " + ob.Asks.First().Amount);
        }
        private static void GetPublicTradeHistory(PublicClient client, DateTime start, DateTime end, string pairID)
        {
            var th = client.ReturnTradeHistoryAsync(pairID).Result;

            foreach (var pt in th)
            {
                WriteLine("DateTime --> " + pt.DateTime);
                WriteLine("Type --> " + pt.Type);
                WriteLine("Rate --> " + pt.Rate);
                WriteLine("Amount --> " + pt.Amount);
                WriteLine("Total --> " + pt.Total);
                WriteLine("*********************************");
            }
        }
        private static void GetChartData(PublicClient client, string pairId, uint period, DateTime start, DateTime end)
        {
            var chd = client.ReturnChartDataAsync(pairId, period, start, end).Result;
            int i = 0;
            foreach (var candle in chd)
            {
                WriteLine("High --> " + candle.High);
                WriteLine("Low --> " + candle.Low);
                WriteLine("Open --> " + candle.Open);
                WriteLine("Close --> " + candle.Close);
                WriteLine("******** Candle number --> " + (chd.Count - (i++)) + " *************");
            }
        }
        private static void GetCurrecies(PublicClient client)
        {
            var cur = client.ReturnCurrenciesAsync().Result;
            var cr = cur.CurrencieList.FirstOrDefault(p => p.CurrencieId == "STR");
            var info = cr.CurrencieInfo;

            WriteLine("Id --> " + cr.Id);
            WriteLine("CurrencieId --> " + cr.CurrencieId);
            WriteLine("HumanType --> " + info.HumanType);
            WriteLine("MinConf --> " + info.MinConf);
            WriteLine("TxFee --> " + info.TxFee);
            WriteLine("DepositAddress --> " + info.DepositAddress);
            WriteLine("CurrencieName --> " + info.CurrencieName);
            WriteLine("***********************************");
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
            var add = client.ReturnDepositAdressesAsync().Result;
            var a = add.FirstOrDefault(k => k.Key == currId);

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

                WriteLine("OrderNumber --> " + oo.FirstOrDefault(k => k.Margin == 0).OrderNumber);
                WriteLine("Type --> " + oo.FirstOrDefault(k => k.Margin == 0).Type);
                WriteLine("Rate --> " + oo.FirstOrDefault(k => k.Margin == 0).Rate);
                WriteLine("Amount --> " + oo.FirstOrDefault(k => k.Margin == 0).Amount);
                WriteLine("Total --> " + oo.FirstOrDefault(k => k.Margin == 0).Total);
                WriteLine("StartingAmount --> " + oo.FirstOrDefault(k => k.Margin == 0).StartingAmount);
                WriteLine("DateTime --> " + oo.FirstOrDefault(k => k.Margin == 0).DateTime.ToLocalTime());
                WriteLine("Margin --> " + oo.FirstOrDefault(k => k.Margin == 0).Margin);
            }            
        }
        private static void GetTradeHistory(PrivateClient client, DateTime start, DateTime end, string pairID, ushort limit)
        {
            if (pairID == allPairs)
            {
                var dict = client.ReturnTradeHistoryAsync<Dictionary<string, List<PrivateTrade>>>(start, end).Result;
                var tradeList = dict.FirstOrDefault(p => p.Key == btc_sc).Value;
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
            else
            {
                var dict = client.ReturnTradeHistoryAsync<List<PrivateTrade>>(start, end, pairID).Result;
                var trade = dict.FirstOrDefault(t => t.AccountCategory == exchange.ToString());

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
        private static void GetOrderTrades(PrivateClient client, ulong orderNumber)
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
        private static void GetOrderStatus(PrivateClient client, ulong orderNumber)
        {
            var obj = client.ReturnOrderStatusAsync(orderNumber).Result;            

                WriteLine("Orderumber --> " + obj.First().Key);
                WriteLine("Status --> " + obj.First().Value.Status);
                WriteLine("Type --> " + obj.First().Value.Type);
                WriteLine("CurrencyPair --> " + obj.First().Value.CurrencyPair);
                WriteLine("Amount --> " + obj.First().Value.Amount);
                WriteLine("StartingAmount --> " + obj.First().Value.StartingAmount);
                WriteLine("Rate --> " + obj.First().Value.Rate);
                WriteLine("Total --> " + obj.First().Value.Total);
                WriteLine("DateTime --> " + obj.First().Value.DateTime);
                WriteLine("--------------------------------------------");
        }
        private static void PlaceOrder(PrivateClient client, OrderType type, decimal rate, decimal amount, string tickerID)
        {
            var bo = client.PlaceOrderAsync(type, rate, amount, tickerID).Result;          
            WriteLine("Orderumber --> " + bo.OrderNumber);
            if (bo.ResultingTrades.Count != 0)
            {
                WriteLine("*********************************");
                WriteLine("TradeID --> " + bo.ResultingTrades.First().TradeID);
                WriteLine("Rate --> " + bo.ResultingTrades.First().Rate);
                WriteLine("Total --> " + bo.ResultingTrades.First().Total);
                WriteLine("Type --> " + bo.ResultingTrades.First().Type);
                WriteLine("Amount --> " + bo.ResultingTrades.First().Amount);
                WriteLine("DateTime --> " + bo.ResultingTrades.First().DateTime);
            }
        }
        private static void CancelOrder(PrivateClient client, ulong orderNumber)
        {
            var co = client.CancelOrderAsync(orderNumber).Result;

            WriteLine(co.Message + " - Amount - " + co.Amount);
        }
        private static void MoveOrder(PrivateClient client, ulong orderNumber, decimal rate, decimal? amount = null)
        {
            var mo = client.MoveOrderAsync(orderNumber, rate, amount).Result;

            WriteLine("Success  --> " + mo.Success);
            WriteLine("OrderNum --> " + mo.OrderNumber);

        }
        private static void Withdraw(PrivateClient client, string currId, decimal amount, string adress, string payId)
        {
            var ww = client.WithdrawAsync(currId, amount, adress, payId).Result;

            WriteLine(ww.Response);
        }
    }
}
