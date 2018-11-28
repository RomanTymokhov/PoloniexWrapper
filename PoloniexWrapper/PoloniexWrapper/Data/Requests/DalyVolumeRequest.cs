using System.Collections.Generic;

using static PoloniexWrapper.Helper.Enums.ReqType;

namespace PoloniexWrapper.Data.Requests
{
    public class DalyVolumeRequest: BaseRequest
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
