using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PoloniexWrapper.Data
{
    public class DalyVolume
    {
        public string pairID;

        public string baseName;
        public decimal? based;

        public string quotedName;
        public decimal? quoted;

        public DalyVolume(IDictionary<string, object> volume)
        {
            var kvp = volume.First().Value as Dictionary<string, string>;

            pairID = volume.First().Key;

            baseName = kvp.First().Key;
            based = Convert.ToDecimal(kvp.First().Value, CultureInfo.InvariantCulture);

            quotedName = kvp.Last().Key;
            quoted =  Convert.ToDecimal(kvp.Last().Value, CultureInfo.InvariantCulture);
        }
    }
}
