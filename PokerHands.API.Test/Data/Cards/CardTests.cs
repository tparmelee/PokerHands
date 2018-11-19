using NUnit.Framework;
using System;
using System.Collections.Generic;
using PokerHands.API.Data.Cards;

namespace PokerHands.API.Test.Data.Cards
{
    public class CardTests
    {
        [Test]
        [TestCase(CardRank.Two, CardSuit.Spade)]
        [TestCase(CardRank.Three, CardSuit.Heart)]
        [TestCase(CardRank.Four, CardSuit.Club)]
        [TestCase(CardRank.Five, CardSuit.Diamond)]
        [TestCase(CardRank.Six, CardSuit.Spade)]
        [TestCase(CardRank.Seven, CardSuit.Heart)]
        [TestCase(CardRank.Eight, CardSuit.Club)]
        [TestCase(CardRank.Nine, CardSuit.Diamond)]
        [TestCase(CardRank.Ten, CardSuit.Spade)]
        [TestCase(CardRank.Jack, CardSuit.Heart)]
        [TestCase(CardRank.Queen, CardSuit.Club)]
        [TestCase(CardRank.King, CardSuit.Diamond)]
        [TestCase(CardRank.Ace, CardSuit.Spade)]
        public void ConstructorSetsRankTheory(CardRank rank, CardSuit suit)
        {
            Card card = new Card(rank, suit);

            Assert.AreEqual(card.Rank, rank);
        }

        [Test]
        [TestCase(CardRank.Two, CardSuit.Spade)]
        [TestCase(CardRank.Three, CardSuit.Heart)]
        [TestCase(CardRank.Four, CardSuit.Club)]
        [TestCase(CardRank.Five, CardSuit.Diamond)]
        public void ConstructorSetsSuitTheory(CardRank rank, CardSuit suit)
        {
            Card card = new Card(rank, suit);

            Assert.AreEqual(card.Suit, suit);
        }

        [Test]
        [TestCase(CardRank.Two, CardSuit.Spade, CardRank.Two, CardSuit.Spade, true)]
        [TestCase(CardRank.Two, CardSuit.Spade, CardRank.Two, CardSuit.Heart, false)]
        [TestCase(CardRank.Two, CardSuit.Spade, CardRank.Two, CardSuit.Diamond, false)]
        [TestCase(CardRank.Two, CardSuit.Spade, CardRank.Two, CardSuit.Club, false)]
        [TestCase(CardRank.Two, CardSuit.Spade, CardRank.Ace, CardSuit.Spade, false)]
        public void CardsAreEqual(CardRank rank1, CardSuit suit1, CardRank rank2, CardSuit suit2, bool expected)
        {
            Card card1 = new Card(rank1, suit1);
            Card card2 = new Card(rank2, suit2);

            Assert.AreEqual(card1.Equals(card2), expected);
        }

        [Test]
        public void CardsCompareTo()
        {
            // Create a list of all cards in a "random" order. 
            List<Card> cards = new List<Card>();

            cards.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards.Add(new Card(CardRank.Queen, CardSuit.Club));
            cards.Add(new Card(CardRank.Three, CardSuit.Heart));
            cards.Add(new Card(CardRank.Five, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Six, CardSuit.Spade));
            cards.Add(new Card(CardRank.Seven, CardSuit.Heart));
            cards.Add(new Card(CardRank.Eight, CardSuit.Club));
            cards.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Ten, CardSuit.Spade));
            cards.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards.Add(new Card(CardRank.Two, CardSuit.Diamond));
            cards.Add(new Card(CardRank.King, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Four, CardSuit.Club));

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
