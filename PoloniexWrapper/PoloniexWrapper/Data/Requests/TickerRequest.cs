<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
=======
﻿using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;
>>>>>>> dev/tohoff82

namespace PoloniexWrapper.Data.Requests
{
    public class TickerRequest: BaseRequest
    {
        public TickerRequest() :base()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            requestArgs = new Dictionary<string, string>
            {
                ["command"] = "returnTicker"
            };
=======
            getArgs = new Dictionary<string, string>
=======
            arguments = new Dictionary<string, string>
>>>>>>> dev/tohoff82
            {
                ["command"] = "returnTicker"
            };

<<<<<<< HEAD
            Url = Build(get).Result;
>>>>>>> dev/tohoff82
=======
            GenerateRequest(pub);
>>>>>>> dev/tohoff82
        }
    }
}
