using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerHands.API.Controllers.PokerHandControllerData;
using PokerHands.API.Data.Hands;
using PokerHands.API.Data.Cards;
using Newtonsoft.Json;

namespace PokerHands.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerHandController : ControllerBase
    {
        
        // This is a health check for the AWS deployment
        [HttpGet]
        public ActionResult<int> Get()
        {
            return 1;
        }

        // GET api/PokerHand
        [HttpPost]
        public ActionResult<List<PokerhandApiOutput>> Post([FromBody] List<PokerhandApiInput> hands)
        {
            
            // Null Check
            if (hands == null)
            {
                return new BadRequestObjectResult("Null request.");
            }
            
            try
            {
                Dictionary<string, Hand> pokerHands = new Dictionary<string, Hand>();

                foreach (PokerhandApiInput hand in hands)
                {
                    pokerHands.Add(hand.Name, PokerhandApiParser.ConvertApiInputToPokerHands(hand.Cards));
                }

                List<KeyValuePair<string, Hand>> sortedhands = pokerHands.ToList();
                sortedhands.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                
                List<PokerhandApiOutput> response;
                response = sortedhands.Select((hand, index) => new PokerhandApiOutput {
                    Name = hand.Key,
                    HandType = Enum.GetName(typeof(HandRank), hand.Value.Rank),
                    Position = index + 1
                }).ToList();
               
                return response;    
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
