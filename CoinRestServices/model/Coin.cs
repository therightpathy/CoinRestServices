using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinRestServices.model
{
    public class Coin
    {
        private int id_;
        private string _type;
        private int _bid;
        private string _name;

        public Coin()
        {
            
        }

        public Coin(int id_, string type, int bid, string name)
        {
            this.Id_ = id_;
            Type = type;
            Bid = bid;
            Name = name;
        }

        public int Id_ { get => id_; set => id_ = value; }
        public string Type { get => _type; set => _type = value; }
        public int Bid { get => _bid; set => _bid = value; }
        public string Name { get => _name; set => _name = value; }


        public override string ToString()
        {
            return $"{nameof(Id_)}: {Id_}, {nameof(Type)}: {Type}, {nameof(Bid)}: {Bid}, {nameof(Name)}: {Name}";
        }
    }

}
