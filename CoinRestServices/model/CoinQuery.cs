using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinRestServices.model
{
    public class CoinQuery
    {
        private int _maxBid;
        private int _minBid;

        public CoinQuery()
        {
            
        }
        public CoinQuery(int minBid, int maxBid)
        {
            MinBid = minBid;
            MaxBid = maxBid;
        }

        public int MaxBid { get => _maxBid; set => _maxBid = value; }
        public int MinBid { get => _minBid; set => _minBid = value; }

        public override string ToString()
        {
            return $"{nameof(MaxBid)}: {MaxBid}, {nameof(MinBid)}: {MinBid}";
        }
    }
}
