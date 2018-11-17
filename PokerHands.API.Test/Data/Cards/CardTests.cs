using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Data.Cards
{
    public class CardTests
    {

        [TestCase(CardRank.Two, CardSuit.SPADE)]
        [TestCase(CardRank.Three, CardSuit.HEART)]
        [TestCase(CardRank.Four, CardSuit.CLUB)]
        [TestCase(CardRank.Five, CardSuit.DIAMOND)]
        [TestCase(CardRank.Six, CardSuit.SPADE)]
        [TestCase(CardRank.Seven, CardSuit.HEART)]
        [TestCase(CardRank.Eight, CardSuit.CLUB)]
        [TestCase(CardRank.Nine, CardSuit.DIAMOND)]
        [TestCase(CardRank.Ten, CardSuit.SPADE)]
        [TestCase(CardRank.Jack, CardSuit.HEART)]
        [TestCase(CardRank.Queen, CardSuit.CLUB)]
        [TestCase(CardRank.King, CardSuit.DIAMOND)]
        [TestCase(CardRank.Ace, CardSuit.SPADE)]
        public void ConstructorSetsRankTheory(CardRank rank, CardSuit suit) {
            Card card = new Card(rank, suit);

            Assert.AreEqual(card.Rank, rank);
        }

        [TestCase(CardRank.Two, CardSuit.SPADE)]
        [TestCase(CardRank.Three, CardSuit.HEART)]
        [TestCase(CardRank.Four, CardSuit.CLUB)]
        [TestCase(CardRank.Five, CardSuit.DIAMOND)]
        public void ConstructorSetsSuitTheory(CardRank rank, CardSuit suit) {
            Card card = new Card(rank, suit);

            Assert.AreEqual(card.Suit, suit);
        }

        [TestCase(CardRank.Two, CardSuit.SPADE, CardRank.Two, CardSuit.SPADE, true)]
        [TestCase(CardRank.Two, CardSuit.SPADE, CardRank.Two, CardSuit.HEART, false)]
        [TestCase(CardRank.Two, CardSuit.SPADE, CardRank.Two, CardSuit.DIAMOND, false)]
        [TestCase(CardRank.Two, CardSuit.SPADE, CardRank.Two, CardSuit.CLUB, false)]
        [TestCase(CardRank.Two, CardSuit.SPADE, CardRank.Ace, CardSuit.SPADE, false)]
        public void CardsAreEqual(CardRank rank1, CardSuit suit1, CardRank rank2, CardSuit suit2, bool expected) {
            Card card1 = new Card(rank1, suit1);
            Card card2 = new Card(rank2, suit2);

            Assert.AreEqual(card1.Equals(card2), expected);
        }

        [Test]
        public void CardsCompareTo() {
            // Create a list of all cards in a "random" order. 
            List<Card> cards = new List<Card>();

            cards.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Queen, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Three, CardSuit.HEART));
            cards.Add(new Card(CardRank.Five, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Six, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Seven, CardSuit.HEART));
            cards.Add(new Card(CardRank.Eight, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Ten, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards.Add(new Card(CardRank.Two, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.King, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Four, CardSuit.CLUB));

            cards.Sort();

            Assert.AreEqual(cards.Count, 13);
            Assert.AreEqual(cards[0].Rank, CardRank.Two);
            Assert.AreEqual(cards[1].Rank, CardRank.Three);
            Assert.AreEqual(cards[2].Rank, CardRank.Four);
            Assert.AreEqual(cards[3].Rank, CardRank.Five);
            Assert.AreEqual(cards[4].Rank, CardRank.Six);
            Assert.AreEqual(cards[5].Rank, CardRank.Seven);
            Assert.AreEqual(cards[6].Rank, CardRank.Eight);
            Assert.AreEqual(cards[7].Rank, CardRank.Nine);            
            Assert.AreEqual(cards[8].Rank, CardRank.Ten);
            Assert.AreEqual(cards[9].Rank, CardRank.Jack);
            Assert.AreEqual(cards[10].Rank, CardRank.Queen);
            Assert.AreEqual(cards[11].Rank, CardRank.King);
            Assert.AreEqual(cards[12].Rank, CardRank.Ace);
        }
    }
}
