using System;

namespace Data.Cards
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {

        public CardRank Rank { get; private set; }

        public CardSuit Suit { get; private set; }

        public Card(CardRank rank, CardSuit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(Card obj)
        {
            // Protect against null
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            int thisPriority = ConvertRankToPriority(this.Rank);
            int objPriority = ConvertRankToPriority(obj.Rank);

            if (thisPriority == objPriority)
            {
                return 0;
            }
            else if (thisPriority < objPriority)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public bool Equals(Card obj)
        {
            
            if (obj == null)
            {
                return false;
            }
            
            return this.Rank == obj.Rank && this.Suit == obj.Suit;
        }
        
        public override int GetHashCode()
        {
            return 10 * (int) Rank + (int)Suit;
        }

        public static int ConvertRankToPriority(CardRank rank)
        {
            switch (rank)
            {
                case CardRank.Two:
                    return 2;
                case CardRank.Three:
                    return 3;
                case CardRank.Four:
                    return 4;
                case CardRank.Five:
                    return 5;
                case CardRank.Six:
                    return 6;
                case CardRank.Seven:
                    return 7;
                case CardRank.Eight:
                    return 8;
                case CardRank.Nine:
                    return 9;
                case CardRank.Ten:
                    return 10;
                case CardRank.Jack:
                    return 11;
                case CardRank.Queen:
                    return 12;
                case CardRank.King:
                    return 13;
                case CardRank.Ace:
                    return 14;
                default:
                    throw new ArgumentException("Card rank must exist in the CardRank enum.");
            }
        }

    }

}