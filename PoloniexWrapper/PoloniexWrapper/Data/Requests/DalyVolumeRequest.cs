using System.Collections.Generic;

using static PoloniexWrapper.Data.Requests.ReqType;

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

            GenerateRequest(pub);
        }
    }
}
