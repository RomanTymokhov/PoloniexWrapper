﻿using PoloniexWrapper;
using PoloniexWrapper.Data;
<<<<<<< HEAD
using PoloniexWrapper.Data.Responses;
using System;
using System.Collections.Generic;
=======
>>>>>>> dev/tohoff82
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

<<<<<<< HEAD
            //GetTickerData(poloClientPub, PairID.usdc_str);
            //GetDalyVolume(poloClientPub, PairID.btc_eth);
=======
            GetTickerData(poloClientPub, PairID.usdc_str);
            GetDalyVolume(poloClientPub, PairID.btc_eth);
>>>>>>> dev/tohoff82
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
<<<<<<< HEAD
            var dv = client.GetDalyVolumeAsync().Result.VolumeList.FirstOrDefault(i => i.pairID == tickerID);
=======
            var dv = client.ReturnDalyVolumesAsync().Result.VolumeList.FirstOrDefault(i => i.pairID == tickerID);
>>>>>>> dev/tohoff82

            WriteLine("VolumePair --> " + dv.pairID);
            WriteLine(dv.baseName + " -- " + dv.based);
            WriteLine(dv.quotedName + " -- " + dv.quoted);
            WriteLine("--------------------------------------------");
        }
    }
}
