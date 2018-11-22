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

        public DalyVolume(Dictionary<string, string> volume, string id)
        {
            pairID = id;

            baseName = volume.First().Key;
            based = Convert.ToDecimal(volume.First().Value, CultureInfo.InvariantCulture);

            quotedName = volume.Last().Key;
            quoted = Convert.ToDecimal(volume.Last().Value, CultureInfo.InvariantCulture);
        }

        //private void SetPairId()
        //{
        //    pairID = new StringBuilder(baseName).AppendFormat("_{0}", quotedName).ToString();
        //}
    }
}
