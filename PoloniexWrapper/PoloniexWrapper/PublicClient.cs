using PoloniexWrapper.Data.Requests;
using PoloniexWrapper.Data.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoloniexWrapper
{
    public class PublicClient : PoloClient
    {
        public PublicClient() : base() { }


        public async Task<Dictionary<string, Ticker>> ReturnTickerAsync() =>
               await HttpGetAsync<Dictionary<string, Ticker>>(new TickerRequest());

        public async Task<DalyVolumes> ReturnDalyVolumesAsync() =>
                await HttpGetAsync<DalyVolumes>(new DalyVolumeRequest());
    }
}
