using PoloniexWrapper;
using PoloniexWrapper.Data;
using System.Linq;

using static System.Console;
using static PoloniexWrapper.Data.PairID;
using static PoloniexWrapper.Data.CurrID;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var poloClientPub  = new PoloClient();

            //GetTickerData(poloClientPub, usdc_str);
            //GetDalyVolume(poloClientPub, btc_eth);
            //GetBalances(poloClientPriv, sc);
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

        private static void GetBalances(PoloClient client, string tickerID)
        {
            var b = client.ReturnBalances().Result.FirstOrDefault(c => c.Key == tickerID);

            WriteLine("Ballance " + b.Key + " = " + b.Value);
        }
    }
}
