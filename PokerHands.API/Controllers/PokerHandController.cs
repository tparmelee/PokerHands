using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokerHands.API.Controllers.PokerHandControllerData;
using PokerHands.API.Data.Hands;
using PokerHands.API.Data.Cards;

namespace PokerHands.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerHandController : ControllerBase
    {

        // GET api/values/5
        [HttpGet]
        public ActionResult<List<PokerhandApiOutput>> Get(List<PokerhandApiInput> hands)
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
                response = sortedhands.Select((hand) => new PokerhandApiOutput {
                    Name = hand.Key,
                    HandType = Enum.GetName(typeof(HandRank), hand.Value.Rank)
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
