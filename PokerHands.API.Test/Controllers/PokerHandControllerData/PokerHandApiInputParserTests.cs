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
        [TestCase("S", CardSuit.Spade)]
        [TestCase("H", CardSuit.Heart)]
        [TestCase("C", CardSuit.Club)]
        [TestCase("D", CardSuit.Diamond)]
        public void ParseCardSuit(string test, CardSuit expected) {

            Assert.AreEqual(expected, PokerhandApiParser.ParseCardSuit(test));
        }

        [Test]
        [TestCase("2S", CardRank.Two, CardSuit.Spade)]
        [TestCase("3H", CardRank.Three, CardSuit.Heart)]
        [TestCase("4D", CardRank.Four, CardSuit.Diamond)]
        [TestCase("5C", CardRank.Five, CardSuit.Club)]
        [TestCase("6S", CardRank.Six, CardSuit.Spade)]
        [TestCase("7H", CardRank.Seven, CardSuit.Heart)]
        [TestCase("8D", CardRank.Eight, CardSuit.Diamond)]
        [TestCase("9C", CardRank.Nine, CardSuit.Club)]
        [TestCase("10S", CardRank.Ten, CardSuit.Spade)]
        [TestCase("JH", CardRank.Jack, CardSuit.Heart)]
        [TestCase("QD", CardRank.Queen, CardSuit.Diamond)]
        [TestCase("KC", CardRank.King, CardSuit.Club)]
        [TestCase("AS", CardRank.Ace, CardSuit.Spade)]
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
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Three && x.Suit == CardSuit.Heart));         
            
            // KS
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.King && x.Suit == CardSuit.Spade));    

            // JD
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Jack && x.Suit == CardSuit.Diamond));    
            
            // 4h
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Four && x.Suit == CardSuit.Heart));    

            // 2S
            Assert.IsTrue(hand.Cards.Any((x) => x.Rank == CardRank.Two && x.Suit == CardSuit.Spade));    
        }
    }
}
