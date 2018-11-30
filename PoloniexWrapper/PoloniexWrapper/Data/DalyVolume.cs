using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace PoloniexWrapper.Data
{
    public class DalyVolume
    {
        //Monitor the response and react to the situation if the dictionary "dalyData" has more than 2 KeyValue pairs

        public string pairID;

        public string baseCurrencyName;
        public decimal? baseCurrencyVolume;

        public string quotedCurrencyName;
        public decimal? quotedCurrencyVolume;

        public DalyVolume(Dictionary<string, string> dalyc, string pairID)
        {
            if (dalyc.Count == 2)
            {
                this.pairID = pairID;

                baseCurrencyName = dalyc.First().Key;
                baseCurrencyVolume = Convert.ToDecimal(dalyc.First().Value, CultureInfo.InvariantCulture);

                quotedCurrencyName = dalyc.Last().Key;
                quotedCurrencyVolume = Convert.ToDecimal(dalyc.Last().Value, CultureInfo.InvariantCulture);
            }
            else new Exception("retur 24Volume --> daly volume object not have 2 element");
        }
    }
}
