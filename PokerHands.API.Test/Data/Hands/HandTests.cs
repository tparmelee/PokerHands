using Data.Cards;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Data.Hands
{
    public class HandTests
    {

        [Test]
        public void HandsComparison1() {
            // Pair
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Four, CardSuit.SPADE));
            cards1.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards1.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards1.Add(new Card(CardRank.Ten, CardSuit.CLUB));

            Hand hand1 = new Hand(cards1);

            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards2.Add(new Card(CardRank.King, CardSuit.HEART));

            Hand hand2 = new Hand(cards2);

            
            Assert.AreEqual(-1, hand1.CompareTo(hand2));      
        }

        [Test]
        public void HandsComparison2() {
            // Pair
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Four, CardSuit.SPADE));
            cards1.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards1.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards1.Add(new Card(CardRank.Ten, CardSuit.CLUB));

            Hand hand1 = new Hand(cards1);

            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards2.Add(new Card(CardRank.King, CardSuit.HEART));

            Hand hand2 = new Hand(cards2);
            
            Assert.AreEqual(1, hand2.CompareTo(hand1));  
        }

        [Test]
        public void HandsComparison3() {
            // High Card - Low
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards1.Add(new Card(CardRank.Jack, CardSuit.SPADE));
            cards1.Add(new Card(CardRank.Queen, CardSuit.CLUB));
            cards1.Add(new Card(CardRank.Two, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Six, CardSuit.DIAMOND));

            Hand hand1 = new Hand(cards1);

            // High Card - High
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.Jack, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.Queen, CardSuit.CLUB));
            cards2.Add(new Card(CardRank.Three, CardSuit.HEART));
            cards2.Add(new Card(CardRank.Six, CardSuit.DIAMOND));

            Hand hand2 = new Hand(cards2);

            Assert.AreEqual(-1, hand1.CompareTo(hand2));
        }

        [Test]
        public void HandsComparison4() {
            // Straight Flush
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards1.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards1.Add(new Card(CardRank.King, CardSuit.HEART));

            Hand hand1 = new Hand(cards1);
            
            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.Queen, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.Ten, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.Nine, CardSuit.SPADE));
            cards2.Add(new Card(CardRank.King, CardSuit.SPADE));

            Hand hand2 = new Hand(cards2);
            
            Assert.AreEqual(0, hand1.CompareTo(hand2)); 
        }

        [Test]
        public void HandsRankHighCard()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Jack, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Queen, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Two, CardSuit.HEART));
            cards.Add(new Card(CardRank.Six, CardSuit.DIAMOND));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.HighCard, hand.Rank);
        }

        [Test]
        public void HandsRankPair()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Four, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Ten, CardSuit.CLUB));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Pair, hand.Rank);
        }

        [Test]
        public void HandsRankTwoPair()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Ten, CardSuit.CLUB));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.TwoPair, hand.Rank);
        }

        [Test]
        public void HandsRankThreeOfAKind()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Six, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Nine, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Nine, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Two, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Nine, CardSuit.CLUB));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.ThreeOfAKind, hand.Rank);
        }

        [Test]
        public void HandsRankStraight()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Four, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Three, CardSuit.HEART));
            cards.Add(new Card(CardRank.Five, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Seven, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Six, CardSuit.SPADE));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Straight, hand.Rank);
        }

        [Test]
        public void HandsRankFlush()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Two, CardSuit.HEART));
            cards.Add(new Card(CardRank.Four, CardSuit.HEART));
            cards.Add(new Card(CardRank.Eight, CardSuit.HEART));
            cards.Add(new Card(CardRank.Seven, CardSuit.HEART));
            cards.Add(new Card(CardRank.Ace, CardSuit.HEART));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Flush, hand.Rank);
        }

        [Test]
        public void HandsRankFullHouse()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Two, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Two, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Two, CardSuit.HEART));
            cards.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Ace, CardSuit.DIAMOND));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.FullHouse, hand.Rank);
        }

        [Test]
        public void HandsRankFourOfAKind()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.CLUB));
            cards.Add(new Card(CardRank.Ace, CardSuit.DIAMOND));
            cards.Add(new Card(CardRank.Ace, CardSuit.SPADE));
            cards.Add(new Card(CardRank.Ace, CardSuit.HEART));
            cards.Add(new Card(CardRank.King, CardSuit.CLUB));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.FourOfAKind, hand.Rank);
        }


        [Test]
        public void HandsRankStraightFlush()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards.Add(new Card(CardRank.King, CardSuit.HEART));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.StraightFlush, hand.Rank);
        }

        [Test]
        public void ConstructorThrowsIfNullCards()
        {
            Assert.Throws<ArgumentNullException>(() => new Hand(null));
        }

        [Test]
        public void ConstructorThowsIfInvalidNumberOfCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards.Add(new Card(CardRank.Nine, CardSuit.HEART));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Hand(cards));
        }

        [Test]
        public void ConstructorThowsIfRepeatCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Jack, CardSuit.HEART));
            cards.Add(new Card(CardRank.Queen, CardSuit.HEART));
            cards.Add(new Card(CardRank.Ten, CardSuit.HEART));
            cards.Add(new Card(CardRank.Nine, CardSuit.HEART));
            cards.Add(new Card(CardRank.Jack, CardSuit.HEART));

            Assert.Throws<ArgumentException>(() => new Hand(cards));
        }
    }
}
