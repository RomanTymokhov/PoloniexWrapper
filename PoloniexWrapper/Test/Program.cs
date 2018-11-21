using PoloniexWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var poloClientPub  = new PoloClient();
            var poloClientPriv = new PoloClient("apiKey");

            GetTickerData(poloClientPub, "USDC_USDT");
        }

        private static void GetTickerData(PoloClient client, string tickerID)
        {
            var ticker = client.GetTickerAsync().Result.FirstOrDefault((tckr => tckr.Key == tickerID)).Value;

            WriteLine("LastPrice --> " + ticker.LastPrice);
            WriteLine("LowestAsk --> " + ticker.LowestAsk);
            WriteLine("HighestBid --> " + ticker.HighestBid);
            WriteLine("PercentChange --> " + ticker.PercentChange);
            WriteLine("BaseVolume --> " + ticker.BaseVolume);
            WriteLine("QuoteVolume --> " + ticker.QuoteVolume);
        }
    }
}
