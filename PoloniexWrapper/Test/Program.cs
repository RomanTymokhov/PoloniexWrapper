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
            var poloClientPub = new PoloClient();
            
            WriteLine("--> " + poloClientPub.GetTickerAsync().Result.FirstOrDefault((ticker => ticker.Key == "USDC_USDT")).Value.LastPrice);
        }
    }
}
