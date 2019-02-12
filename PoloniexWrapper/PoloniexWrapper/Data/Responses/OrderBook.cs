using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace PoloniexWrapper.Data.Responses
{
    public class OrderBook
    {
        public List<BookItem> Asks = new List<BookItem>();
        public List<BookItem> Bids = new List<BookItem>();

        [JsonProperty("asks")]
        private List<List<string>> ComingAsks
        {
            set
            {
                foreach (var item in value)
                {
                    if(item != null) Asks.Add(new BookItem(item));
                }
            }
        }

        [JsonProperty("bids")]
        private List<List<string>> ComingBids
        {
            set
            {
                foreach (var item in value)
                {
                    if (item != null) Bids.Add(new BookItem(item));
                }
            }
        }

        [JsonProperty("isFrozen")]
        public byte IsFrozen { get; private set; }

        [JsonProperty("seq")]
        public ulong SequenceId { get; private set; } //for use with the Push API
    }

    public class BookItem
    {
        public readonly decimal rate;
        public readonly decimal amount;

        public BookItem(List<string> lst)
        {
            decimal.TryParse(lst.First(), Any, InvariantCulture, out rate);
            decimal.TryParse(lst.Last(), Any, InvariantCulture, out amount);
        }
    }
}
