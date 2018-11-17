using System;
using System.Collections.Generic;
using System.Linq;
using PokerHands.API.Data.Hands;
using PokerHands.API.Data.Cards;

namespace PokerHands.API.Controllers.PokerHandControllerData
{   
    public static class PokerhandApiParser {

        public static Hand ConvertApiInputToPokerHands(List<string> input) {
            if (input == null) {
                throw new ArgumentNullException();
            }

            if (input.Count != 5) {
                throw new ArgumentOutOfRangeException("Card count must be exactly 5");
            }

            List<Card> cards = new List<Card>();
            cards = input.Select((x) => ParseSingleCard(x)).ToList();
            
            return new Hand(cards);
        }

        public static Card ParseSingleCard(string input) {
            if (input.Length < 2 || input.Length > 3) {
                throw new ArgumentOutOfRangeException("Each card must be be eitehr 2 or three characters.");
            }

            string rawRank = input.Substring(0, input.Length - 1);
            string rawSuit = input.Substring(input.Length - 1);

            return new Card(ParseCardRank(rawRank), ParseCardSuit(rawSuit));
        }

        public static CardRank ParseCardRank(string rawRank) {
            switch (rawRank.ToUpper()) {
                case ("2"):
                    return CardRank.Two;
                case ("3"):
                    return CardRank.Three;
                case ("4"):
                    return CardRank.Four;
                case ("5"):
                    return CardRank.Five;
                case ("6"):
                    return CardRank.Six;
                case ("7"):
                    return CardRank.Seven;
                case ("8"):
                    return CardRank.Eight;
                case ("9"):
                    return CardRank.Nine;
                case ("10"):
                    return CardRank.Ten;
                case ("J"):
                    return CardRank.Jack;
                case ("Q"):
                    return CardRank.Queen;
                case ("K"):
                    return CardRank.King;
                case ("A"):
                    return CardRank.Ace;
                default:
                    throw new ArgumentOutOfRangeException("Suit string must be either 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, or A.");
            }
        }

        public static CardSuit ParseCardSuit(string rawSuit) {
            switch (rawSuit.ToUpper()) {
                case ("S"):
                    return CardSuit.SPADE;
                case ("H"):
                    return CardSuit.HEART;
                case ("C"):
                    return CardSuit.CLUB;
                case ("D"):
                    return CardSuit.DIAMOND;
                default:
                    throw new ArgumentOutOfRangeException("Rank string must be either S, H, C, or D.");
            }
        }
        
    }   
}