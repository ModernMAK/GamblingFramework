using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GamblingFramework
{
    public static class GambleCardExtended
    {
        //NOT MY CODE
        //Currently a placeholder until I figure out whether to use System.Random, Cryptology (as mentioned in the article)
        //FROM http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        public static void AdvancedShuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        //NOT MY CODE
        //Currently a placeholder until I figure out whether to use System.Random, Cryptology (as mentioned in the article)
        //FROM http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        public static void SimpleShuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
           
        public static bool IsRed(this GambleCardSuit suit)
        {
            return
                (suit == GambleCardSuit.Diamonds) ||
                (suit == GambleCardSuit.Hearts);
        }
        public static bool IsBlack(this GambleCardSuit suit)
        {
            return
                !suit.IsRed();
        }

        public static GambleCardSuit CalculateGambleCardSuit(this IGambleCard card)
        {
            return CalculateGambleCardSuit(card.Index);
        }
        public static GambleCardSuit CalculateGambleCardSuit(int index)
        {
            if (index > GambleCard.CARD_INDEX_GAMBLE_MAX)
            {
                if (index % 2 == 0)
                {
                    return GambleCardSuit.Spades;
                }
                else
                {
                    return GambleCardSuit.Hearts;
                }
            }
            else
            {
                switch (index / 13)
                {
                    case 0:
                        return GambleCardSuit.Spades;
                    case 1:
                        return GambleCardSuit.Hearts;
                    case 2:
                        return GambleCardSuit.Clubs;
                    case 3:
                        return GambleCardSuit.Diamonds;
                }
            }
            return GambleCardSuit.Spades;
        }

        public static GambleCardFace CalculateGambleCardValue(this IGambleCard card)
        {
            return CalculateGambleCardValue(card.Index);
        }
        public static GambleCardFace CalculateGambleCardValue(int index)
        {
            if (index > GambleCard.CARD_INDEX_GAMBLE_MAX)
            {
                return GambleCardFace.Joker;
            }
            else
            {
                switch (index % 13)
                {
                    case 0:
                        return GambleCardFace.Ace;
                    case 1:
                        return GambleCardFace.Two;
                    case 2:
                        return GambleCardFace.Three;
                    case 3:
                        return GambleCardFace.Four;
                    case 4:
                        return GambleCardFace.Five;
                    case 5:
                        return GambleCardFace.Six;
                    case 6:
                        return GambleCardFace.Seven;
                    case 7:
                        return GambleCardFace.Eight;
                    case 8:
                        return GambleCardFace.Nine;
                    case 9:
                        return GambleCardFace.Ten;
                    case 10:
                        return GambleCardFace.Jack;
                    case 11:
                        return GambleCardFace.Queen;
                    case 12:
                        return GambleCardFace.King;
                }
            }
            return GambleCardFace.Joker;
        }

        public static int CalculateGambleCardIndex(GambleCardSuit suit, GambleCardFace value)
        {
            //To avoid uneccessary calculations with Jokers, we always check them first (since jokers are a worst case scenario)
            if(value == GambleCardFace.Joker){
                if(suit.IsBlack()){
                    //0-51 leaves an odd last index, 
                    //black is the even joker, 
                    //since the next index would be even, 
                    //the black joker is the next index
                    return GambleCard.CARD_INDEX_GAMBLE_MAX+1;
                }
                else{
                    return GambleCard.CARD_INDEX_GAMBLE_MAX+2;
                }
            }

            int
                suitId = -1,
                indexId = -1;

            switch (suit)
            {
                case GambleCardSuit.Spades:
                    suitId = 0;
                    break;
                case GambleCardSuit.Hearts:
                    suitId = 1;
                    break;
                case GambleCardSuit.Clubs:
                    suitId = 2;
                    break;
                case GambleCardSuit.Diamonds:
                    suitId = 3;
                    break;
            }
            switch (value)
            {
                case GambleCardFace.Ace:
                    suitId = 0;
                    break;
                case GambleCardFace.Two:
                    suitId = 1;
                    break;
                case GambleCardFace.Three:
                    suitId = 2;
                    break;
                case GambleCardFace.Four:
                    suitId = 3;
                    break;
                case GambleCardFace.Five:
                    suitId = 4;
                    break;
                case GambleCardFace.Six:
                    suitId = 5;
                    break;
                case GambleCardFace.Seven:
                    suitId = 6;
                    break;
                case GambleCardFace.Eight:
                    suitId = 7;
                    break;
                case GambleCardFace.Nine:
                    suitId = 8;
                    break;
                case GambleCardFace.Ten:
                    suitId = 9;
                    break;
                case GambleCardFace.Jack:
                    suitId = 10;
                    break;
                case GambleCardFace.Queen:
                    suitId = 11;
                    break;
                case GambleCardFace.King:
                    suitId = 12;
                    break;
            }

            return (suitId * 13) + indexId;
        }
    }
}
