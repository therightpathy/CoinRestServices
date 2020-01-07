using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinRestServices.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoinRestServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoinController : ControllerBase
    {
        private static List<Coin> coins = new List<Coin>()
        {
            new Coin(1, "Gold DK 1640", 2500, "Mike"),
            new Coin(2, "Gold NL 1764", 5000, "Anbo"),
            new Coin(3, "Gold FR 1644", 35000, "Hammer"),
            new Coin(4, "Gold FR 1644", 0, "Auction"),
            new Coin(5, "Silver GR 333", 2500, "Mike")
        };
        
        // GET: GetCoins
        [HttpGet]
        [Route("/GetCoins")]
        public IEnumerable<Coin> Get()
        {
            return coins;
        }

        // GET: GetCoinById/1
        [HttpGet]
        [Route("/GetCoinById/{id}")]
        public Coin Get(int id)
        {
            return coins.Find(i => i.Id_== id);
        }

        // POST: api/Coin
        [HttpPost]
        [Route("/AddCoin")]
        public void Post([FromBody] Coin value)
        {
            coins.Add(value);
        }

        // PUT: UpdateCoin
        [HttpPut]
        [Route("/UpdateCoin/{id}")]
        public void Put(int id, [FromBody] Coin value)
        {
            int i = coins.FindIndex(c => c.Id_ == id);
            coins[i].Type = value.Type;
            coins[i].Bid = value.Bid;
            coins[i].Name = value.Name;
        }

        // DELETE: RemoveCoin
        [HttpDelete]
        [Route("/RemoveCoin/{id}")]
        public void Delete(int id)
        {
            coins.Remove(coins.Find(i => i.Id_ == id));
        }

        [HttpGet]
        [Route("/GetCustomerBids/{name}")]
        public IEnumerable<Coin> Get(string name)
        {
            return coins.Where(c => c.Name == name);
        }

        // GET: GetCoinsByBid?minbid=1500&maxbid=2500
        [HttpGet]
        [Route("/GetCoinsByBid")]
        public List<Coin> GetCoinsByBid([FromQuery] CoinQuery QCoin)
        {
            List<Coin> List = new List<Coin>();

            foreach (var c in coins)
            {
                if (QCoin.MinBid <= c.Bid && QCoin.MaxBid >= c.Bid)
                {
                    List.Add(c);
                }
            }

            return List;
        }
    }
}
