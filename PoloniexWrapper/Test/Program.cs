using PoloniexWrapper;
using PoloniexWrapper.Data;
using System.Linq;

using static System.Console;
using static PoloniexWrapper.Data.PairID;
using static PoloniexWrapper.Data.CurrID;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var poloClientPub = new PoloClient();

            //GetTickerData(poloClientPub, usdc_str);
            //GetDalyVolume(poloClientPub, btc_eth);
            //GetBalances(poloClientPriv, sc);
            //GetCompleteBalances(poloClientPriv, xem);
            //GetDepositAdresses(poloClientPriv, btc);
            //GetNewAdress(poloClientPriv, etc);
            //GetDepositsWithdravals(poloClientPriv, new DateTime(2017, 10, 1), DateTime.Now);
        }

        private static void GetTickerData(PoloClient client, string tickerID)
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
        private static void GetDalyVolume(PoloClient client, string tickerID)
        {
            var dv = client.ReturnDalyVolumesAsync().Result.VolumeList.FirstOrDefault(i => i.pairID == tickerID);

            WriteLine("VolumePair --> " + dv.pairID);
            WriteLine(dv.baseName + " -- " + dv.based);
            WriteLine(dv.quotedName + " -- " + dv.quoted);
            WriteLine("--------------------------------------------");
        }

        private static void GetBalances(PoloClient client, string currID)
        {
            var b = client.ReturnBalancesAsync().Result.FirstOrDefault(c => c.Key == currID);

            WriteLine("Ballance " + b.Key + " = " + b.Value);
            WriteLine("--------------------------------------------");
        }
        private static void GetCompleteBalances(PoloClient client, string currId)
        {
            var b = client.ReturComleteBalancesAsync().Result.FirstOrDefault(k => k.Key == currId);

            WriteLine("Avalible --> " + b.Value.Availabel);
            WriteLine("OnOrders --> " + b.Value.OnOrders);
            WriteLine("BtcValue --> " + b.Value.BtcValue);
            WriteLine("--------------------------------------------");
        }
        private static void GetDepositAdresses(PoloClient client, string currId)
        {
            var a = client.ReturnDepositAdressesAsync().Result.FirstOrDefault(k => k.Key == currId);

            WriteLine(a.Key + " -- " + a.Value);
            WriteLine("--------------------------------------------");
        }
        private static void GetNewAdress(PoloClient client, string currId)
        {
            var na = client.GenerateNewAddressAsync(currId).Result;

            WriteLine("new " + currId + " adress --> " + na.Response);
            WriteLine("--------------------------------------------");
        }
        private static void GetDepositsWithdravals(PoloClient client, DateTime start, DateTime end)
        {
            var dw = client.ReturnDepositsWithdrawalsAsync(start, end).Result;

            foreach (var deposit in dw.DepositList)
            {
                WriteLine("Adress --> " + deposit.Adress);
                WriteLine("Amount --> " + deposit.Amount);
                WriteLine("onfirmation --> " + deposit.Confirmations);
                WriteLine("Currecy --> " + deposit.CurrencyID);
                WriteLine("Status --> " + deposit.Status);
                WriteLine("Timestamp --> " + deposit.Timestamp);
                WriteLine("TxID --> " + deposit.TxID);
                WriteLine("*******************");
            }

            WriteLine("--------------------------------------------");

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
    }
}
