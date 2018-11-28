﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PoloniexWrapper.Helper
{
    public class Enums
    {
        public enum ReqType { GET, POST }

        public enum OrderType { buy, sell}

        public enum TradingAccount { all, exchange, margin, lending }
    }
}
