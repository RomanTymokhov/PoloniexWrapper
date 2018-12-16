using System;
using System.Collections.Generic;
using System.Text;

namespace PoloniexWrapper.Data
{
    public class Currencie
    {
        public uint Id { get; private set; }

        public string CurrencieId { get; private set; }

        public CurrencieInfo CurrencieInfo { get; private set; }

        public Currencie(CurrencieInfo currencieInfo, string currencieId)
        {
            Id = currencieInfo.Id;
            CurrencieInfo = currencieInfo;
            CurrencieId = currencieId;
        }
    }
}
