using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using PokerHands.API.Data.Cards;
using PokerHands.API.Data.Hands;
using PokerHands.API.Controllers.PokerHandControllerData;

namespace PokerHands.API.test.Controllers.PokerHandControllerData
{
    public class PokerhandApiParserTests
    {
        
        

        [Test]
        [TestCase("2", CardRank.Two)]
        [TestCase("3", CardRank.Three)]
        [TestCase("4", CardRank.Four)]
        [TestCase("5", CardRank.Five)]
        [TestCase("6", CardRank.Six)]
        [TestCase("7", CardRank.Seven)]
        [TestCase("8", CardRank.Eight)]
        [TestCase("9", CardRank.Nine)]
        [TestCase("10", CardRank.Ten)]
        [TestCase("J", CardRank.Jack)]
        [TestCase("Q", CardRank.Queen)]
        [TestCase("K", CardRank.King)]
        [TestCase("A", CardRank.Ace)]
        public void ParseCardRank(string test, CardRank expected) {

            Assert.AreEqual(expected, PokerhandApiParser.ParseCardRank(test));
        }

        [Test]
        [TestCase("S", CardSuit.SPADE)]
        [TestCase("H", CardSuit.HEART)]
        [TestCase("C", CardSuit.CLUB)]
        [TestCase("D", CardSuit.DIAMOND)]
        public void ParseCardSuit(string test, CardSuit expected) {

            Assert.AreEqual(expected, PokerhandApiParser.ParseCardSuit(test));
        }

        [Test]
        [TestCase("2S", CardRank.Two, CardSuit.SPADE)]
        [TestCase("3H", CardRank.Three, CardSuit.HEART)]
        [TestCase("4D", CardRank.Four, CardSuit.DIAMOND)]
        [TestCase("5C", CardRank.Five, CardSuit.CLUB)]
        [TestCase("6S", CardRank.Six, CardSuit.SPADE)]
        [TestCase("7H", CardRank.Seven, CardSuit.HEART)]
        [TestCase("8D", CardRank.Eight, CardSuit.DIAMOND)]
        [TestCase("9C", CardRank.Nine, CardSuit.CLUB)]
        [TestCase("10S", CardRank.Ten, CardSuit.SPADE)]
        [TestCase("JH", CardRank.Jack, CardSuit.HEART)]
        [TestCase("QD", CardRank.Queen, CardSuit.DIAMOND)]
        [TestCase("KC", CardRank.King, CardSuit.CLUB)]
        [TestCase("AS", CardRank.Ace, CardSuit.SPADE)]
        public void ParseSingleCard(string test, CardRank expectedRank, CardSuit expectedSuit) {
            Card c = PokerhandApiParser.ParseSingleCard(test);

            Assert.AreEqual(expectedRank, c.Rank);
            Assert.AreEqual(expectedSuit, c.Suit);
        }

        [Test]
        public void ParseHand() {
            List<string> cardStrings = new List<string>(new string[]{"3H", "KS", "JD", "4H", "2S"});

            Hand hand = PokerhandApiParser.ConvertApiInputToPokerHands(cardStrings);

            // 3H
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Three && x.Suit == CardSuit.HEART));         
            
            // KS
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.King && x.Suit == CardSuit.SPADE));    

            // JD
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Jack && x.Suit == CardSuit.DIAMOND));    
            
            // 4h
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Four && x.Suit == CardSuit.HEART));    

            // 2S
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Two && x.Suit == CardSuit.SPADE));    
        }
    }
}
