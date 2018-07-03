using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler_54
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            StreamReader reader = new StreamReader("poker.txt");
            string[] hands = reader.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 1000; i++)
            {
                string[] cards = hands[i].Split(' ');

                Hand hand1 = new Hand(SubArray(cards, 0, 5));
                Hand hand2 = new Hand(SubArray(cards, 5, 5));
            }

            Console.WriteLine($"Dauer: {watch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

    }

    public class Hand
    {
        public Rank Rank { get; set; }
        public List<Card> Cards = new List<Card>();

        public Hand(string[] cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(new Card(card));
            }
            this.Rank = CalculateRank();
        }

        // High Card: Highest value card.
        // One Pair: Two cards of the same value.
        // Two Pairs: Two different pairs.
        // Three of a Kind: Three cards of the same value.
        // Straight: All cards are consecutive values.
        // Flush: All cards of the same suit.
        // Full House: Three of a kind and a pair.
        // Four of a Kind: Four cards of the same value.
        // Straight Flush: All cards are consecutive values of same suit.
        // Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
        private Rank CalculateRank()
        {
            this.Sort();

            if (HandEvaluation.IsRoyalFlush(Cards)) return Rank.RoyalFlush;
            if (HandEvaluation.IsStraightFlush(Cards)) return Rank.StraightFlush;
            if (HandEvaluation.IsFourOfAKind(Cards)) return Rank.FourOfAKind;
            if (HandEvaluation.IsFullHouse(Cards)) return Rank.FullHouse;
            if (HandEvaluation.IsFlush(Cards)) return Rank.Flush;
            if (HandEvaluation.IsStraight(Cards)) return Rank.Straight;
            if (HandEvaluation.IsThreeOfAKind(Cards)) return Rank.ThreeOfAKind;
            if (HandEvaluation.IsTwoPairs(Cards)) return Rank.TwoPairs;
            if (HandEvaluation.IsOnePair(Cards)) return Rank.OnePair;
            if (HandEvaluation.IsHighCard(Cards)) return Rank.HighCard;

            throw new NotImplementedException();
        }

        private void Sort()
        {
            bool sorting = true;

            while (sorting)
            {
                sorting = false;
                for (int i = 0; i < Cards.Count - 1; i++)
                {
                    if (Cards[i] > Cards[i + 1])
                    {
                        // switch
                        var tmp = Cards[i];
                        Cards[i] = Cards[i + 1];
                        Cards[i + 1] = tmp;
                        sorting = true;
                    }
                }
            }
        }
    }


    public static class HandEvaluation
    {
        // Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
        public static bool IsRoyalFlush(List<Card> cards)
        {
            if (cards[0].Value == Value.Ten && cards[1].Value == Value.Jack && cards[2].Value == Value.Queen && cards[3].Value == Value.King && cards[4].Value == Value.Ace &&
                cards[0].Suit.EqualsAllOf(cards[1], cards[2], cards[3], cards[4]))
            {
                return true;
            }
            return false;
        }

        // Straight Flush: All cards are consecutive values of same suit.
        public static bool IsStraightFlush(List<Card> cards)
        {
            if (cards[0].Suit.EqualsAllOf(cards[1], cards[2], cards[3], cards[4]))
            {
                Value num = cards[0].Value;
                if (cards[1].Value == num + 1 && cards[2].Value == num + 2 && cards[3].Value == num + 3 && cards[4].Value == num + 4)
                {
                    return true;
                }
            }
            return false;
        }

        // Four of a Kind: Four cards of the same value.
        public static bool IsFourOfAKind(List<Card> cards)
        {
            if ((cards[0].Value.EqualsAllOf(cards[1], cards[2], cards[3])) || (cards[1].Value.EqualsAllOf(cards[2], cards[3], cards[4])))
            {
                return true;
            }
            return false;
        }

        // Full House: Three of a kind and a pair.
        public static bool IsFullHouse(List<Card> cards)
        {
            return false;
        }

        // Flush: All cards of the same suit.
        public static bool IsFlush(List<Card> cards)
        {
            if (cards[0].Suit.EqualsAllOf(cards[1], cards[2], cards[3], cards[4]))
            {
                return true;
            }
            return false;
        }

        // Straight: All cards are consecutive values.
        public static bool IsStraight(List<Card> cards)
        {
            Value num = cards[0].Value;
            if (cards[1].Value == num + 1 && cards[2].Value == num + 2 && cards[3].Value == num + 3 && cards[4].Value == num + 4)
            {
                return true;
            }
            return false;
        }

        // Three of a Kind: Three cards of the same value.
        public static bool IsThreeOfAKind(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 2; i++)
            {
                if (cards[i].Value == cards[i + 1].Value && cards[i].Value == cards[i + 2].Value)
                {
                    return true;
                }
            }
            return false;
        }

        // Two Pairs: Two different pairs.
        public static bool IsTwoPairs(List<Card> cards)
        {
            return false;
        }

        // One Pair: Two cards of the same value.
        public static bool IsOnePair(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Value == cards[i + 1].Value)
                {
                    return true;
                }
            }
            return false;
        }

        // High Card: Highest value card.
        public static bool IsHighCard(List<Card> cards)
        {
            return false;
        }
    }

    public static class Extensions
    {
        public static bool EqualsAllOf(this Value val, params Card[] cards)
        {
            foreach (var card in cards)
            {
                if (val != card.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool EqualsAllOf(this Suit suit, params Card[] cards)
        {
            foreach (var card in cards)
            {
                if (suit != card.Suit)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Card
    {
        public Value Value { get; set; }
        public Suit Suit { get; set; }

        public Card(string card)
        {
            this.Suit = ParseSuit(card);
            this.Value = ParseValue(card);
        }

        private Value ParseValue(string card)
        {
            char value = card[0];
            switch (value)
            {
                case '2': return Value.Two;
                case '3': return Value.Three;
                case '4': return Value.Four;
                case '5': return Value.Five;
                case '6': return Value.Six;
                case '7': return Value.Seven;
                case '8': return Value.Eight;
                case '9': return Value.Nine;
                case 'T': return Value.Ten;
                case 'J': return Value.Jack;
                case 'Q': return Value.Queen;
                case 'K': return Value.King;
                default: return Value.Ace;
            }
        }

        private Suit ParseSuit(string card)
        {
            //throw new NotImplementedException();
            char suit = card[1];
            switch (suit)
            {
                case 'H': return Suit.Heart;
                case 'D': return Suit.Diamond;
                case 'S': return Suit.Spade;
                default: return Suit.Clubs;
            }
        }

        public static bool operator <(Card left, Card right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Card left, Card right)
        {
            return left.Value > right.Value;
        }

    }

    public enum Suit
    {
        Heart = 0, // Herz
        Diamond = 1, // Karo
        Spade = 2, // Pik
        Clubs = 3 // Kreuz
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public enum Rank
    {
        HighCard = 0,
        OnePair = 1,
        TwoPairs = 2,
        ThreeOfAKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfAKind = 7,
        StraightFlush = 8,
        RoyalFlush = 9
    }


}
