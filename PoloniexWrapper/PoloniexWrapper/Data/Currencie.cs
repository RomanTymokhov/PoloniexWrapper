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
            CurrencieId = currencieId;
            CurrencieInfo = currencieInfo;
        }
    }
}
