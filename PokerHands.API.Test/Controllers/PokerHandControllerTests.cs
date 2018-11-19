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
        public void PostTest1()
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
            var response = controller.Post(inputData);

            var responseData = response.Value;

            Assert.AreEqual(n1,responseData[0].Name);
            Assert.AreEqual("StraightFlush",responseData[0].HandType);
            Assert.AreEqual(1,responseData[0].Position);

            Assert.AreEqual(n2,responseData[1].Name);
            Assert.AreEqual("Flush",responseData[1].HandType);
            Assert.AreEqual(2,responseData[1].Position);

            Assert.AreEqual(n0,responseData[2].Name);
            Assert.AreEqual("HighCard",responseData[2].HandType);
            Assert.AreEqual(3,responseData[2].Position);
        }
        
        [Test]
        public void PostTest2() {
            List<PokerhandApiInput> inputData = new List<PokerhandApiInput>();

            // Pair of 9s, King high
            string[] h0 = new string[] { "2S", "9D", "7D", "KC", "9H" };
            string n0 = "Debbie";
            inputData.Add(new PokerhandApiInput {Name = n0, Cards = h0.ToList()});
            
            // Two Pair, Queens, and Sevens
            string[] h1 = new String[] { "7S", "QD", "7C", "QC", "5S" };
            string n1 = "Charles";
            inputData.Add(new PokerhandApiInput {Name = n1, Cards = h1.ToList()});

            // Pair of 4s, Ace high
            string[] h2 = new String[] { "3H", "4D", "4C", "2D", "AS" };
            string n2 = "Henry";
            inputData.Add(new PokerhandApiInput {Name = n2, Cards = h2.ToList()});
         
            PokerHandController controller = new PokerHandController();
            var response = controller.Post(inputData);

            var responseData = response.Value;

            // Charles should be #1
            Assert.AreEqual(n1,responseData[0].Name);
            Assert.AreEqual("TwoPair",responseData[0].HandType);
            Assert.AreEqual(1,responseData[0].Position);

            // Debbie should be #2
            Assert.AreEqual(n0,responseData[1].Name);
            Assert.AreEqual("Pair",responseData[1].HandType);
            Assert.AreEqual(2,responseData[1].Position);

            // Henry Should be #3
            Assert.AreEqual(n2,responseData[2].Name);
            Assert.AreEqual("Pair",responseData[2].HandType);
            Assert.AreEqual(3,responseData[2].Position);
        }

        [Test]
        public void PostTest3() {
            List<PokerhandApiInput> inputData = new List<PokerhandApiInput>();

            // High Card Queen, 10
            string[] h0 = new string[] { "8C", "QC", "10D", "9S", "4D" };
            string n0 = "Debbie";
            inputData.Add(new PokerhandApiInput {Name = n0, Cards = h0.ToList()});
            
            // High Card Queen, Jack
            string[] h1 = new String[] { "QH", "9C", "5C", "JC", "10S" };
            string n1 = "Charles";
            inputData.Add(new PokerhandApiInput {Name = n1, Cards = h1.ToList()});

            // High Card Ace, Nine
            string[] h2 = new String[] { "6S", "9H", "5H", "2D", "Ac" };
            string n2 = "Henry";
            inputData.Add(new PokerhandApiInput {Name = n2, Cards = h2.ToList()});
         
            PokerHandController controller = new PokerHandController();
            var response = controller.Post(inputData);

            var responseData = response.Value;

            // Henry should be #1
            Assert.AreEqual(n2,responseData[0].Name);
            Assert.AreEqual("HighCard",responseData[0].HandType);
            Assert.AreEqual(1,responseData[0].Position);

            // Charles should be #2
            Assert.AreEqual(n1,responseData[1].Name);
            Assert.AreEqual("HighCard",responseData[1].HandType);
            Assert.AreEqual(2,responseData[1].Position);

            // Henry Should be #3
            Assert.AreEqual(n0,responseData[2].Name);
            Assert.AreEqual("HighCard",responseData[2].HandType);
            Assert.AreEqual(3,responseData[2].Position);
        }
    }

    
}