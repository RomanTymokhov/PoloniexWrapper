using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

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

            Url = Build(get).Result;
        }
    }
}
