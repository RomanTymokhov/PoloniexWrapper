using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class DalyVolumeRequest: RequestObject
    {
        public DalyVolumeRequest():base()
        {
            arguments = new Dictionary<string, string>
            {
                ["command"] = "return24hVolume"
            };

            GenerateRequest(get);
        }
    }
}
