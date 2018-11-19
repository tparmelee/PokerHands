using PokerHands.API.Data.Cards;
using PokerHands.API.Data.Hands;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PokerHands.API.Test.Data.Hands
{
    public class HandTests
    {

        [Test]
        public void HandsComparison1() {
            // Pair
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Four, CardSuit.Spade));
            cards1.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards1.Add(new Card(CardRank.Ten, CardSuit.Club));

            Hand hand1 = new Hand(cards1);

            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards2.Add(new Card(CardRank.King, CardSuit.Heart));

            Hand hand2 = new Hand(cards2);

            
            Assert.AreEqual(-1, hand1.CompareTo(hand2));      
        }

        [Test]
        public void HandsComparison2() {
            // Pair
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Four, CardSuit.Spade));
            cards1.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards1.Add(new Card(CardRank.Ten, CardSuit.Club));

            Hand hand1 = new Hand(cards1);

            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards2.Add(new Card(CardRank.King, CardSuit.Heart));

            Hand hand2 = new Hand(cards2);
            
            Assert.AreEqual(1, hand2.CompareTo(hand1));  
        }

        [Test]
        public void HandsComparison3() {
            // High Card - Low
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards1.Add(new Card(CardRank.Jack, CardSuit.Spade));
            cards1.Add(new Card(CardRank.Queen, CardSuit.Club));
            cards1.Add(new Card(CardRank.Two, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Six, CardSuit.Diamond));

            Hand hand1 = new Hand(cards1);

            // High Card - High
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards2.Add(new Card(CardRank.Jack, CardSuit.Spade));
            cards2.Add(new Card(CardRank.Queen, CardSuit.Club));
            cards2.Add(new Card(CardRank.Three, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Six, CardSuit.Diamond));

            Hand hand2 = new Hand(cards2);

            Assert.AreEqual(-1, hand1.CompareTo(hand2));
        }

        [Test]
        public void HandsComparison4() {
            // Straight Flush
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards1.Add(new Card(CardRank.King, CardSuit.Heart));

            Hand hand1 = new Hand(cards1);
            
            // Straight Flush
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Jack, CardSuit.Spade));
            cards2.Add(new Card(CardRank.Queen, CardSuit.Spade));
            cards2.Add(new Card(CardRank.Ten, CardSuit.Spade));
            cards2.Add(new Card(CardRank.Nine, CardSuit.Spade));
            cards2.Add(new Card(CardRank.King, CardSuit.Spade));

            Hand hand2 = new Hand(cards2);
            
            Assert.AreEqual(0, hand1.CompareTo(hand2)); 
        }

         [Test]
        public void HandsComparison5() {
            // Pair Of 9s, King High
            List<Card> cards1 = new List<Card>();
            cards1.Add(new Card(CardRank.Two, CardSuit.Spade));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards1.Add(new Card(CardRank.Seven, CardSuit.Diamond));
            cards1.Add(new Card(CardRank.King, CardSuit.Club));
            cards1.Add(new Card(CardRank.Nine, CardSuit.Heart));

            Hand hand1 = new Hand(cards1);
            
            // Pair of 4s, Ace High
            List<Card> cards2 = new List<Card>();
            cards2.Add(new Card(CardRank.Three, CardSuit.Heart));
            cards2.Add(new Card(CardRank.Four, CardSuit.Diamond));
            cards2.Add(new Card(CardRank.Four, CardSuit.Club));
            cards2.Add(new Card(CardRank.Two, CardSuit.Diamond));
            cards2.Add(new Card(CardRank.Ace, CardSuit.Heart));

            Hand hand2 = new Hand(cards2);
            
            Assert.AreEqual(1, hand1.CompareTo(hand2)); 
        }

        [Test]
        public void HandsRankHighCard()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards.Add(new Card(CardRank.Jack, CardSuit.Spade));
            cards.Add(new Card(CardRank.Queen, CardSuit.Club));
            cards.Add(new Card(CardRank.Two, CardSuit.Heart));
            cards.Add(new Card(CardRank.Six, CardSuit.Diamond));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.HighCard, hand.Rank);
        }

        [Test]
        public void HandsRankPair()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Four, CardSuit.Spade));
            cards.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Ten, CardSuit.Club));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Pair, hand.Rank);
        }

        [Test]
        public void HandsRankTwoPair()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Ten, CardSuit.Club));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.TwoPair, hand.Rank);
        }

        [Test]
        public void HandsRankThreeOfAKind()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Six, CardSuit.Spade));
            cards.Add(new Card(CardRank.Nine, CardSuit.Spade));
            cards.Add(new Card(CardRank.Nine, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Two, CardSuit.Spade));
            cards.Add(new Card(CardRank.Nine, CardSuit.Club));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.ThreeOfAKind, hand.Rank);
        }

        [Test]
        public void HandsRankStraight()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Four, CardSuit.Spade));
            cards.Add(new Card(CardRank.Three, CardSuit.Heart));
            cards.Add(new Card(CardRank.Five, CardSuit.Spade));
            cards.Add(new Card(CardRank.Seven, CardSuit.Spade));
            cards.Add(new Card(CardRank.Six, CardSuit.Spade));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Straight, hand.Rank);
        }

        [Test]
        public void HandsRankFlush()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Two, CardSuit.Heart));
            cards.Add(new Card(CardRank.Four, CardSuit.Heart));
            cards.Add(new Card(CardRank.Eight, CardSuit.Heart));
            cards.Add(new Card(CardRank.Seven, CardSuit.Heart));
            cards.Add(new Card(CardRank.Ace, CardSuit.Heart));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.Flush, hand.Rank);
        }

        [Test]
        public void HandsRankFullHouse()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Two, CardSuit.Spade));
            cards.Add(new Card(CardRank.Two, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Two, CardSuit.Heart));
            cards.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards.Add(new Card(CardRank.Ace, CardSuit.Diamond));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.FullHouse, hand.Rank);
        }

        [Test]
        public void HandsRankFourOfAKind()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Ace, CardSuit.Club));
            cards.Add(new Card(CardRank.Ace, CardSuit.Diamond));
            cards.Add(new Card(CardRank.Ace, CardSuit.Spade));
            cards.Add(new Card(CardRank.Ace, CardSuit.Heart));
            cards.Add(new Card(CardRank.King, CardSuit.Club));

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandRank.FourOfAKind, hand.Rank);
        }


        [Test]
        public void HandsRankStraightFlush()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards.Add(new Card(CardRank.King, CardSuit.Heart));

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
            cards.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards.Add(new Card(CardRank.Nine, CardSuit.Heart));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Hand(cards));
        }

        [Test]
        public void ConstructorThowsIfRepeatCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card(CardRank.Jack, CardSuit.Heart));
            cards.Add(new Card(CardRank.Queen, CardSuit.Heart));
            cards.Add(new Card(CardRank.Ten, CardSuit.Heart));
            cards.Add(new Card(CardRank.Nine, CardSuit.Heart));
            cards.Add(new Card(CardRank.Jack, CardSuit.Heart));

            Assert.Throws<ArgumentException>(() => new Hand(cards));
        }
    }
}
