using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using PokerHands.API.Data.Cards;
using PokerHands.API.Data.Hands;
using PokerHands.API.Controllers;
using PokerHands.API.Controllers.PokerHandControllerData;
using Microsoft.AspNetCore.Mvc;

namespace PokerHands.API.test.Controllers {

    public class PokerHandControllerTests {

        [Test]
        public void GetTest()
        {
            List<PokerhandApiInput> inputData = new List<PokerhandApiInput>();

            // High Card
            string[] h0 = new string[] { "3H", "KS", "JD", "4H", "2S" };
            string n0 = "Debbie";
            inputData.Add(new PokerhandApiInput {Name = n0, Cards = h0.ToList()});

            // Flush Queen High
            string[] h1 = new String[] { "JH", "QH", "10H", "9H", "KH" };
            string n1 = "Charles";
            inputData.Add(new PokerhandApiInput {Name = n1, Cards = h1.ToList()});

            // Flush - Jack High
            string[] h2 = new String[] { "JH", "2H", "10H", "9H", "KH" };
            string n2 = "Henry";
            inputData.Add(new PokerhandApiInput {Name = n2, Cards = h2.ToList()});

            PokerHandController controller = new PokerHandController();
            var response = controller.Get(inputData);

            var responseData = response.Value;

            Assert.AreEqual(n1,responseData[0].Name);
            Assert.AreEqual("StraightFlush",responseData[0].HandType);

            Assert.AreEqual(n2,responseData[1].Name);
            Assert.AreEqual("Flush",responseData[1].HandType);

            Assert.AreEqual(n0,responseData[2].Name);
            Assert.AreEqual("HighCard",responseData[2].HandType);
        }
        
    }

    
}