using Newtonsoft.Json.Linq;
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

        public DalyVolume(KeyValuePair<string, Dictionary<string, string>> volume)
        {
            pairID = volume.Key;

            baseName = volume.Value.First().Key;
            based = Convert.ToDecimal(volume.Value.First().Value, CultureInfo.InvariantCulture);

            quotedName = volume.Value.Last().Key;
            quoted = Convert.ToDecimal(volume.Value.Last().Value, CultureInfo.InvariantCulture);
        }
    }
}
