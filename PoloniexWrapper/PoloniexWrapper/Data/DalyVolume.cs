using System;
using System.Linq;
using System.Collections.Generic;
using PoloniexWrapper.Exceptions;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data
{
    public class DalyVolume
    {
        //Monitor the response and react to the situation if the dictionary "dalyData" has more than 2 KeyValue pairs

        public readonly string pairID;

        public readonly string baseCurrencyName;
        public readonly decimal baseCurrencyVolume;

        public readonly string quotedCurrencyName;
        public readonly decimal quotedCurrencyVolume;

        public DalyVolume(Dictionary<string, string> dalyc, string pairID)
        {
            if (dalyc.Count == 2)
            {
                this.pairID = pairID;

                baseCurrencyName = dalyc.First().Key;
                decimal.TryParse(dalyc.First().Value, Any, InvariantCulture, out baseCurrencyVolume);

                quotedCurrencyName = dalyc.Last().Key;
                decimal.TryParse(dalyc.Last().Value, Any, InvariantCulture, out quotedCurrencyVolume);
            }
            else throw new PoloException("return 24Volume --> daly volume object not have 2 element");
        }
    }
}
