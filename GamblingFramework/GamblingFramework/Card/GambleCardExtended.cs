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
           
        public static bool IsRed(this StandardCardSuit suit)
        {
            return
                (suit == StandardCardSuit.Diamonds) ||
                (suit == StandardCardSuit.Hearts);
        }
        public static bool IsBlack(this StandardCardSuit suit)
        {
            return
                (suit == StandardCardSuit.Spades) ||
                (suit == StandardCardSuit.Clubs);
        }

        /*
        Instead, keep this within the concrete types (defeats the purpose of interfaces to have this here)
        
        public static StandardCardSuit CalculateStandardCardSuit(this IGambleCard card)
        {
            return CalculateStandardCardSuit(card.Index);
        }
        */
        public static StandardCardSuit ToStandardCardSuit(int suitIdentity){
            try{
                return (StandardCardSuit)(object)(suitIdentity);
            }
            catch(Exception e){
                //Do something with exception;
                return StandardCardSuit.Blank;
            }
        }
        public static int ToStandardCardSuitIdentity(StandardCardSuit suit){
            try{
                return (int)(object)(suitIdentity);
            }
            catch(Exception e){
                //Do something with exception;
                return 0;
            }
        }
        public static StandardCardFace ToStandardCardFace(int faceIdentity){
            return (StandardCardSuit)(object)(faceIdentity);
        }
        public static int ToStandardCardFaceIdentity(StandardCardFace face){
            return (int)(object)(faceIdentity);
        }
        /*
        public static StandardCardSuit CalculateStandardCardSuit(int cardIdentity)
        {
            if (cardIdentity > 51)
            {
                //Convert to 4-based number
                cardIdentity %= 4;
                //Convert to 13-based number
                cardIdentity *= 13;
            }
            cardIdentity /= 13;
            
            return CalculateStandardCardSuit(cardIdentity);
        }

        public static StandardCardFace CalculateGambleCardValue(this IGambleCard card)
        {
            return CalculateGambleCardValue(card.Index);
        }
        public static StandardCardFace CalculateGambleCardValue(int index)
        {
            if (index > 51)
            {
                return StandardCardFace.Joker;
            }
            else
            {
                //Unfortunately, I setup my enums where ace = 1, 
                //so we could convert it by subtracting one, or we can use a switch
                //after some unit-testing, I'll find which is faster (if any)
                //if they are the same, i'll be using int-to-object-to-enum conversion, since that is easier to mantain
                switch (index % 13)
                {
                    case 0:
                        return StandardCardFace.Ace;
                    case 1:
                        return StandardCardFace.Two;
                    case 2:
                        return StandardCardFace.Three;
                    case 3:
                        return StandardCardFace.Four;
                    case 4:
                        return StandardCardFace.Five;
                    case 5:
                        return StandardCardFace.Six;
                    case 6:
                        return StandardCardFace.Seven;
                    case 7:
                        return StandardCardFace.Eight;
                    case 8:
                        return StandardCardFace.Nine;
                    case 9:
                        return StandardCardFace.Ten;
                    case 10:
                        return StandardCardFace.Jack;
                    case 11:
                        return StandardCardFace.Queen;
                    case 12:
                        return StandardCardFace.King;
                }
            }
            return StandardCardFace.Joker;
        }

        public static int CalculateGambleCardIndex(StandardCardSuit suit, StandardCardFace value)
        {
            //To avoid uneccessary calculations with Jokers, we always check them first (since jokers are a worst case scenario)
            if(value == StandardCardFace.Joker){
                    //0-51 leaves an odd last index, 
                    //black is the even joker, 
                    //since the next index would be even, 
                    //the black joker is the next index
                switch (suit)
                {
                    case StandardCardSuit.Spades:
                        return 52;
                    case StandardCardSuit.Hearts:
                        return 53;
                    case StandardCardSuit.Clubs:
                        return 53;
                    case StandardCardSuit.Diamonds:
                        return 54;
                }
            }

            int
                suitId = -1,
                indexId = -1;

            switch (suit)
            {
                case StandardCardSuit.Spades:
                    suitId = 0;
                    break;
                case StandardCardSuit.Hearts:
                    suitId = 1;
                    break;
                case StandardCardSuit.Clubs:
                    suitId = 2;
                    break;
                case StandardCardSuit.Diamonds:
                    suitId = 3;
                    break;
            }
            switch (value)
            {
                case StandardCardFace.Ace:
                    indexId = 0;
                    break;
                case StandardCardFace.Two:
                    indexId = 1;
                    break;
                case StandardCardFace.Three:
                    indexId = 2;
                    break;
                case StandardCardFace.Four:
                    indexId = 3;
                    break;
                case StandardCardFace.Five:
                    indexId = 4;
                    break;
                case StandardCardFace.Six:
                    indexId = 5;
                    break;
                case StandardCardFace.Seven:
                    indexId = 6;
                    break;
                case StandardCardFace.Eight:
                    indexId = 7;
                    break;
                case StandardCardFace.Nine:
                    indexId = 8;
                    break;
                case StandardCardFace.Ten:
                    indexId = 9;
                    break;
                case StandardCardFace.Jack:
                    indexId = 10;
                    break;
                case StandardCardFace.Queen:
                    indexId = 11;
                    break;
                case StandardCardFace.King:
                    indexId = 12;
                    break;
            }

            return (suitId * 13) + indexId;
        }
        */
    }
}
