using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace PoloniexWrapper.Data
{
    public class DalyVolume
    {
        public string pairID;

        public string baseCurrencyName;
        public decimal? baseCurrencyVolume;

        public string quotedCurrencyName;
        public decimal? quotedCurrencyVolume;

        public DalyVolume(Dictionary<string, string> dalyData, string id)
        {
            pairID = id;

            baseCurrencyName   = dalyData.First().Key;
            baseCurrencyVolume = Convert.ToDecimal(dalyData.First().Value, CultureInfo.InvariantCulture);

            quotedCurrencyName   = dalyData.Last().Key;
            quotedCurrencyVolume = Convert.ToDecimal(dalyData.Last().Value, CultureInfo.InvariantCulture);
        }
    }
}
