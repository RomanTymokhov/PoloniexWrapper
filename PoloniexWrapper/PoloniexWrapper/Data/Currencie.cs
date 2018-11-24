using System;
using System.Collections.Generic;
using System.Globalization;

namespace PoloniexWrapper.Data
{
    public class Currencie
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; } 

        public Currencie (KeyValuePair<string, string> keyValue)
        {
            Name = keyValue.Key;
            Price = Convert.ToDecimal(keyValue.Value, CultureInfo.InvariantCulture);
        }
    }
}
