using PokerHands.API.Data.Cards;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PokerHands.API.Data.Hands
{
    public class Hand : IComparable<Hand>
    {
        public List<Card> Cards { get; private set; }
        public HandRank Rank {get; private set;}

        public Hand(List<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }

            if (cards.Count != 5)
            {
                throw new ArgumentOutOfRangeException("Must have exactly 5 cards.", "cards");
            }

            if (cards.Distinct().ToList().Count != cards.Count) {
                throw new ArgumentException("All cards must be unique.");
            }
            
            Cards = cards;

            Dictionary<CardRank, int> cardRankSummary = CalculateCardRankOccurencesInHand(Cards);
            Dictionary<CardSuit, int> cardSuitSummary = CalculateCardSuitOccurencesInHand(Cards);

            Rank = CalculateHandType(cardRankSummary, cardSuitSummary);
        }

        public int CompareTo(Hand obj)
        {
            // Protect against null
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            int thisCardRankPriority = (int)Rank;
            int objCardRankPriority = (int)obj.Rank;           

            if (thisCardRankPriority == objCardRankPriority)
            {
                // Calculate Occurances of card information - used to simplify calculation of hand
                Dictionary<CardRank, int> thisCardRankSummary = CalculateCardRankOccurencesInHand(Cards);
                Dictionary<CardRank, int> objCardRankSummary = CalculateCardRankOccurencesInHand(obj.Cards);
                
                List<int> thisCardPrioritySummary = SortRankOccuranceSummaryByFrequencyThenPriority(thisCardRankSummary);
                List<int> objCardPrioritySummary = SortRankOccuranceSummaryByFrequencyThenPriority(objCardRankSummary);

                int index = 0;
                while (index < thisCardPrioritySummary.Count && index < objCardPrioritySummary.Count) {
                    if (thisCardPrioritySummary[index] > objCardPrioritySummary[index]) {
                        return 1;
                    } else if (thisCardPrioritySummary[index] < objCardPrioritySummary[index]) {
                        return -1;
                    } else {
                        // keep progressing through priority list to find first difference between cards
                    }
                    index++;
                }

                // Hands are found to be exactly equal
                return 0;
            }
            else if (thisCardRankPriority < objCardRankPriority)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        // This method is a handy utility to get an sorted ranks by frequency (higher occurence is better),
        // then a tie-breaker by priority of the rank 
        private static List<int> SortRankOccuranceSummaryByFrequencyThenPriority(Dictionary<CardRank, int> summary) {
            return summary.Select(x =>
                                new KeyValuePair<int, int>(Card.ConvertRankToPriority(x.Key), x.Value))
                                .OrderByDescending(x => x.Value)
                                .ThenByDescending(x => x.Key)
                                .Select(x => x.Key)
                                .ToList();
        }

        private static Dictionary<CardRank, int> CalculateCardRankOccurencesInHand(List<Card> cards)
        {
            Dictionary<CardRank, int> summary = new Dictionary<CardRank, int>();

            foreach (Card card in cards)
            {
                if (summary.ContainsKey(card.Rank))
                {
                    summary[card.Rank]++;
                }
                else
                {
                    summary.Add(card.Rank, 1);
                }
            }

            return summary;
        }
        private static Dictionary<CardSuit, int> CalculateCardSuitOccurencesInHand(List<Card> cards)
        {
            Dictionary<CardSuit, int> summary = new Dictionary<CardSuit, int>();

            foreach (Card card in cards)
            {
                if (summary.ContainsKey(card.Suit))
                {
                    summary[card.Suit]++;
                }
                else
                {
                    summary.Add(card.Suit, 1);
                }
            }

            return summary;
        }

        private static HandRank CalculateHandType(Dictionary<CardRank, int> rankSummary, Dictionary<CardSuit, int> suitSummary)
        {
            if (IsPair(rankSummary))
            {
                return HandRank.Pair;
            }
            else if (IsTwoPair(rankSummary))
            {
                return HandRank.TwoPair;
            }
            else if (IsThreeOfAKind(rankSummary))
            {
                return HandRank.ThreeOfAKind;
            }
            else if (IsStraight(rankSummary, suitSummary))
            {
                return HandRank.Straight;
            }
            else if (IsFlush(rankSummary, suitSummary))
            {
                return HandRank.Flush;
            }
            else if (IsFullHouse(rankSummary))
            {
                return HandRank.FullHouse;
            }
            else if (IsFourOfAKind(rankSummary))
            {
                return HandRank.FourOfAKind;
            }
            else if (IsStraightFlush(rankSummary, suitSummary))
            {
                return HandRank.StraightFlush;
            }
            else
            {
                // Default if no other hand was found
                return HandRank.HighCard;
            }
        }


        private static bool IsPair(Dictionary<CardRank, int> rankSummary)
        {
            // If there is one pair then there will only be 4 different ranks
            // One must be repeated
            return (rankSummary.Count == 4);
        }

        private static bool IsTwoPair(Dictionary<CardRank, int> rankSummary)
        {
            // If there are two pairs then there will only be 3 different ranks
            // Additionally, if the most number of times a card is repeated is
            // two then another card must be repeated to have only 3 unique ranks 
            return (rankSummary.Values.Max() == 2 && rankSummary.Count == 3);
        }

        private static bool IsThreeOfAKind(Dictionary<CardRank, int> rankSummary)
        {
            // is three of a kind if any rank occurs three times
            // also the count of ranks must be greater than 2. Otherwise
            // it would be a full house - Three of a Kind and Two of a Kind.
            return (rankSummary.Values.Max() == 3 && rankSummary.Count > 2);
        }

        private static bool IsStraight(Dictionary<CardRank, int> rankSummary, Dictionary<CardSuit, int> suitSummary)
        {
            // Is a normal straight if there are more than 1 suits in the hand
            // and all cards are rank order with no gaps
            return (suitSummary.Count != 1 && IsStraightIgnoreSuit(rankSummary));
        }

        private static bool IsFlush(Dictionary<CardRank, int> rankSummary, Dictionary<CardSuit, int> suitSummary)
        {
            // If there is only one suit then it is a flush
            // also can't be a straight or it would be a straight flush
            return (suitSummary.Count == 1 && !IsStraightIgnoreSuit(rankSummary));
        }

        private static bool IsFullHouse(Dictionary<CardRank, int> rankSummary)
        {
            // Is full house if there is a three of a kind,
            // and total rank count is 2 - means that the other two must be a pair.
            return (rankSummary.Count == 2 && rankSummary.Values.Max() == 3);
        }

        private static bool IsFourOfAKind(Dictionary<CardRank, int> rankSummary)
        {
            // is four of a kind if any rank occurs 4 times
            return (rankSummary.Values.Max() == 4);
        }

        private static bool IsStraightFlush(Dictionary<CardRank, int> rankSummary, Dictionary<CardSuit, int> suitSummary)
        {
            // Is a straight flush if there is only 1 suit in the hand
            // and all cards are rank order with no gaps
            return (suitSummary.Count == 1 && IsStraightIgnoreSuit(rankSummary));
        }

        private static bool IsStraightIgnoreSuit(Dictionary<CardRank, int> rankSummary)
        {
            if (rankSummary.Count == 5)
            {
                List<CardRank> ranks = rankSummary.Keys.ToList();

                List<int> rankPriorities = ranks.Select(rank => Card.ConvertRankToPriority(rank)).ToList();

                rankPriorities.Sort();

                int minPriority = rankPriorities[0];

                // If it is a straight, the ordered priorities with the minPriority
                // subtracted should match their index.
                for (int i = 0; i < rankPriorities.Count; i++) {
                    if (rankPriorities[i] - minPriority != i) {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                // Can't have repeated ranks in straight
                return false;
            }
        }

    }
}