using static PoloniexWrapper.Helper.Enums.RequestType;

namespace PoloniexWrapper.Data.Requests
{
    public class DalyVolumeRequest: RequestObject
    {
        public DalyVolumeRequest():base()
        {
            arguments["command"] = "return24hVolume";           

            GenerateRequest(GET);
        }
    }
}
