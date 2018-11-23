using PoloniexWrapper;
using PoloniexWrapper.Data;
using System.Linq;

using static System.Console;
using static PoloniexWrapper.Data.Responses.Ticker;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var poloClientPub  = new PoloClient();
            var poloClientPriv = new PoloClient("apiKey");

            GetTickerData(poloClientPub, PairID.usdc_str);
            GetDalyVolume(poloClientPub, PairID.btc_eth);
        }

        private static void GetTickerData(PoloClient client, string tickerID)
        {
            var ticker = client.ReturnTickerAsync().Result.FirstOrDefault((tckr => tckr.Key == tickerID)).Value;

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
    }
}
