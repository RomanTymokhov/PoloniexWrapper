﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoloniexWrapper.Data.Requests
{
    public class DalyVolumeRequest: BaseRequest
    {
        public DalyVolumeRequest():base()
        {
            getArgs = new Dictionary<string, string>
            {
                ["command"] = "return24hVolume"
            };

            Url = Make(true).Result;
        }
    }
}
