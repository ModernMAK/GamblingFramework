using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public static class IGambleCardHandExtensions
    {
        public static Dictionary<GambleCardFace, int> GetValueOccurenceCount(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetValueOccurenceCount();
        }
        public static Dictionary<GambleCardSuit, int> GetSuitOccurenceCount(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetSuitOccurenceCount();
        }
        public static Dictionary<GambleCardFace, IList<IGambleCard>> GetValueOccurenceList(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetValueOccurenceList();
        }
        public static Dictionary<GambleCardSuit, IList<IGambleCard>> GetSuitOccurenceList(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetSuitOccurenceList();
        }

        //Temporary generic explicits 
        public static IList<IList<IGambleCard>> GetXConsecutiveOfSuit(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetXConsecutiveOfSuit();
        }
        public static IList<IList<IGambleCard>> GetXOfSuit(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetXOfSuit();
        }
        public static IList<IList<IGambleCard>> GetXConsecutive<T>(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetXConsecutive();
        }

        /*
        //TODO Recursion is required for this (to have X nested loops), so for now, we brute code GetStraight<T>
        //Unfortunately, in the occurence of a straight or 
        public static IList<IList<T>> GetXConsecutive<T>(this IList<T> self, int x) where T : IGambleCard
        {
            List<List<T>>
                allStraights = new List<List<T>>();
            if (!self.HasXConsecutive(x))
            {
                return new List<IList<T>>();
            }

            Dictionary<GambleCardValue, IList<T>>
                occurences = self.GetValueOccurenceList();

            bool found = true;
            for (int i = 13 - (x-1); i >= 0; i--)
            {
                for (int j = i + (x-1); j >= i ; j--)
                {
                    if (j < 0)
                    {
                        found = false;
                        break;
                    }
                    GambleCardValue current = GambleCardExtended.CalculateGambleCardValue(j);
                    if (occurences[current].Count <= 0)
                    {
                        found = false;
                        break;
                    }
                    else
                    {
                        found = true;
                    }
                }
                if (found)
                {
                }
            }
            //We dont need to sort since we start at ACE, go to King, and then loop back down to ACE
            //(We skip the last ace since we cant start with an Low-Ace, (we can with a High-Ace), because Low-Ace is the lowest card

            //Cant do an implicit conversion, and explicit didn't work last time i checked, but this does :D
            IList<IList<T>> ret = new List<IList<T>>(allStraights);
            return ret;
        }
         */
        //Generic Gets
        public static IGambleCard GetHighCard(this IGambleCardHand self)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetHighCard();
        }
        //We dont return a list of a list?
        //Unlike other Gets, we only care about the best case scenario
        public static IList<IList<IGambleCard>> GetXOfAKind(this IGambleCardHand self, int x)
        {
            return ((IGambleCardHand<IGambleCard>)self).GetXOfAKind(x);
        }
        public static bool HasXConsecutive<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            return ((IGambleCardHand<IGambleCard>)self).HasXConsecutive(x);
        }
        public static bool HasXOfSuit<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            return ((IGambleCardHand<IGambleCard>)self).HasXOfSuit(x);
        }
        public static bool HasXOfAKind<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            return ((IGambleCardHand<IGambleCard>)self).HasXOfAKind(x);
        }
    }
}
namespace GamblingFramework.Generic
{
    public static class IGambleCardHandExtensions
    {
        #region Values
        private static readonly GambleCardSuit[]
            PRIVATE_SUITS = new GambleCardSuit[4] 
            { 
                GambleCardSuit.Clubs, 
                GambleCardSuit.Diamonds, 
                GambleCardSuit.Hearts, 
                GambleCardSuit.Spades 
            };
        public static GambleCardSuit[] SUITS
        {
            get
            {
                return PRIVATE_SUITS;
            }
        }

        private static readonly GambleCardFace[]
            PRIVATE_VALUES = new GambleCardFace[14] { 
                GambleCardFace.Ace,
                
                GambleCardFace.Two,
                GambleCardFace.Three,
                GambleCardFace.Four,
                GambleCardFace.Five,
                GambleCardFace.Six,
                GambleCardFace.Seven,
                GambleCardFace.Eight,
                GambleCardFace.Nine,
                GambleCardFace.Ten,
                
                GambleCardFace.Jack,
                GambleCardFace.Queen,
                GambleCardFace.King,

                GambleCardFace.Joker
            };
        public static GambleCardFace[] VALUES
        {
            get
            {
                return PRIVATE_VALUES;
            }
        }
        #endregion
        //
        public static Dictionary<GambleCardFace, int> GetValueOccurenceCount<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            Dictionary<GambleCardFace, int>
                occurences = new Dictionary<GambleCardFace, int>();
            foreach (GambleCardFace value in VALUES)
            {
                occurences.Add(value, 0);
            }

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i] == null || self[i].Face == GambleCardFace.Joker)
                {
                    continue;
                }
                occurences[self[i].Face]++;
            }

            return occurences;
        }
        public static Dictionary<GambleCardSuit, int> GetSuitOccurenceCount<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            Dictionary<GambleCardSuit, int>
                occurences = new Dictionary<GambleCardSuit, int>();
            foreach (GambleCardSuit suit in SUITS)
            {
                occurences.Add(suit, 0);
            }

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i] == null || self[i].Face == GambleCardFace.Joker)
                {
                    continue;
                }
                occurences[self[i].Suit]++;
            }

            return occurences;
        }
        public static Dictionary<GambleCardFace, IList<T>> GetValueOccurenceList<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            Dictionary<GambleCardFace, IList<T>>
                occurences = new Dictionary<GambleCardFace, IList<T>>();
            foreach (GambleCardFace value in VALUES)
            {
                occurences.Add(value, new List<T>());
            }

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i] == null || self[i].Face == GambleCardFace.Joker)
                {
                    continue;
                }
                occurences[self[i].Face].Add(self[i]);
            }

            return occurences;
        }
        public static Dictionary<GambleCardSuit, IList<T>> GetSuitOccurenceList<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            Dictionary<GambleCardSuit, IList<T>>
                occurences = new Dictionary<GambleCardSuit, IList<T>>();
            foreach (GambleCardSuit suit in SUITS)
            {
                occurences.Add(suit, new List<T>());
            }

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i] == null || self[i].Face == GambleCardFace.Joker)
                {
                    continue;
                }
                occurences[self[i].Suit].Add(self[i]);
            }

            return occurences;
        }

        //Temporary generic explicits 
        public static IList<IList<T>> GetXConsecutiveOfSuit<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            IList<IList<T>>
                    allStraights = self.GetXConsecutive();

            for (int i = allStraights.Count - 1; i >= 0; i--)
            {
                IGambleCardHand<T>
                    tempHand = new GambleCardHand<T>(allStraights[i]);
                IList<IList<T>>
                    flushs = tempHand.GetXOfSuit();
                if (flushs.Count <= 0)
                {
                    allStraights.RemoveAt(i);
                }
            }
            List<IList<T>> sort = new List<IList<T>>(allStraights);
            sort.Sort(
                delegate(IList<T> x, IList<T> y)
                {
                    int ret = 0;
                    for (int i = 0; i < x.Count && i < y.Count; i++)
                    {
                        ret = -x[i].CompareTo(y[i]);
                        if (ret != 0)
                        {
                            return ret;
                        }
                    }
                    return -x.Count.CompareTo(y.Count);
                }
            );

            return sort;


        }
        public static IList<IList<T>> GetXOfSuit<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            int x = 5;
            List<IList<T>>
                allFlushs = new List<IList<T>>();
            if (!self.HasXOfSuit(x))
            {
                return new List<IList<T>>();
            }

            Dictionary<GambleCardSuit, IList<T>>
                occurences = self.GetSuitOccurenceList();

            foreach (GambleCardSuit suit in SUITS)
            {
                int count = occurences[suit].Count;
                if (count < x)
                {
                    continue;
                }
                for (int i = 0; i < count; i++)
                {
                    for (int j = i + 1; j < count; j++)
                    {
                        for (int k = j + 1; k < count; k++)
                        {
                            for (int l = k + 1; l < count; l++)
                            {
                                for (int m = l + 1; m < count; m++)
                                {
                                    List<T> temp = new List<T>();

                                    temp.Add(occurences[suit][i]);
                                    temp.Add(occurences[suit][j]);
                                    temp.Add(occurences[suit][k]);
                                    temp.Add(occurences[suit][l]);
                                    temp.Add(occurences[suit][m]);

                                    temp.Sort(
                                            delegate(T xCard, T yCard)
                                            {
                                                return -xCard.CompareTo(yCard);
                                            }
                                        );

                                    allFlushs.Add(temp);
                                }
                            }
                        }
                    }
                }
            }
            //We dont need to sort since we start at ACE, go to King, and then loop back down to ACE
            //(We skip the last ace since we cant start with an Low-Ace, (we can with a High-Ace), because Low-Ace is the lowest card

            //Cant do an implicit conversion, and explicit didn't work last time i checked, but this does :D


            IList<IList<T>> ret = new List<IList<T>>(allFlushs);
            return ret;

        }
        public static IList<IList<T>> GetXConsecutive<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            int x = 5;
            List<IList<T>>
                allStraights = new List<IList<T>>();
            if (!self.HasXConsecutive(x))
            {
                return new List<IList<T>>();
            }

            Dictionary<GambleCardFace, IList<T>>
                occurences = self.GetValueOccurenceList();

            bool found = true;
            for (int i = 13 - (x - 1); i >= 0; i--)
            {
                for (int j = i + (x - 1); j >= i; j--)
                {
                    if (j < 0)
                    {
                        found = false;
                        break;
                    }
                    GambleCardFace current = GambleCardExtended.CalculateGambleCardValue(j);
                    if (occurences[current].Count <= 0)
                    {
                        found = false;
                        break;
                    }
                    else
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    GambleCardFace
                        aVal = GambleCardExtended.CalculateGambleCardValue(i + (x - 1) - 0),
                        bVal = GambleCardExtended.CalculateGambleCardValue(i + (x - 1) - 1),
                        cVal = GambleCardExtended.CalculateGambleCardValue(i + (x - 1) - 2),
                        dVal = GambleCardExtended.CalculateGambleCardValue(i + (x - 1) - 3),
                        eVal = GambleCardExtended.CalculateGambleCardValue(i + (x - 1) - 4);

                    for (int a = 0; a < occurences[aVal].Count; a++)
                    {
                        for (int b = 0; b < occurences[bVal].Count; b++)
                        {
                            for (int c = 0; c < occurences[cVal].Count; c++)
                            {
                                for (int d = 0; d < occurences[dVal].Count; d++)
                                {
                                    for (int e = 0; e < occurences[eVal].Count; e++)
                                    {
                                        List<T> temp = new List<T>();

                                        temp.Add(occurences[aVal][a]);
                                        temp.Add(occurences[bVal][b]);
                                        temp.Add(occurences[cVal][c]);
                                        temp.Add(occurences[dVal][d]);
                                        temp.Add(occurences[eVal][e]);

                                        allStraights.Add(temp);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //We dont need to sort since we start at ACE, go to King, and then loop back down to ACE
            //(We skip the last ace since we cant start with an Low-Ace, (we can with a High-Ace), because Low-Ace is the lowest card

            //Cant do an implicit conversion, and explicit didn't work last time i checked, but this does :D
            IList<IList<T>> ret = (IList<IList<T>>)(allStraights);
            return ret;
        }

        /*
        //TODO Recursion is required for this (to have X nested loops), so for now, we brute code GetStraight<T>
        //Unfortunately, in the occurence of a straight or 
        public static IList<IList<T>> GetXConsecutive<T>(this IList<T> self, int x) where T : IGambleCard
        {
            List<List<T>>
                allStraights = new List<List<T>>();
            if (!self.HasXConsecutive(x))
            {
                return new List<IList<T>>();
            }

            Dictionary<GambleCardValue, IList<T>>
                occurences = self.GetValueOccurenceList();

            bool found = true;
            for (int i = 13 - (x-1); i >= 0; i--)
            {
                for (int j = i + (x-1); j >= i ; j--)
                {
                    if (j < 0)
                    {
                        found = false;
                        break;
                    }
                    GambleCardValue current = GambleCardExtended.CalculateGambleCardValue(j);
                    if (occurences[current].Count <= 0)
                    {
                        found = false;
                        break;
                    }
                    else
                    {
                        found = true;
                    }
                }
                if (found)
                {
                }
            }
            //We dont need to sort since we start at ACE, go to King, and then loop back down to ACE
            //(We skip the last ace since we cant start with an Low-Ace, (we can with a High-Ace), because Low-Ace is the lowest card

            //Cant do an implicit conversion, and explicit didn't work last time i checked, but this does :D
            IList<IList<T>> ret = new List<IList<T>>(allStraights);
            return ret;
        }
         */
        //Generic Gets
        public static T GetHighCard<T>(this IGambleCardHand<T> self) where T : IGambleCard
        {
            if (self.Count <= 0)
            {
                return default(T);
            }
            Dictionary<GambleCardFace, IList<T>> occurences = self.GetValueOccurenceList();
            for (int i = 13; i > 0; i--)
            {
                GambleCardFace val = GambleCardExtended.CalculateGambleCardValue(i);
                if (occurences[val].Count > 0)
                {
                    return occurences[val][0];
                }
            }
            return default(T);
        }
        //We dont return a list of a list?
        //Unlike other Gets, we only care about the best case scenario
        public static IList<IList<T>> GetXOfAKind<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            Dictionary<GambleCardFace, IList<T>>
                myOccurences = self.GetValueOccurenceList();
            List<IList<T>>
                myListOfKinds = new List<IList<T>>();
            if (!self.HasXOfAKind(x))
            {
                return new List<IList<T>>();
            }

            for (int i = 13; i > 0; i--)
            {
                GambleCardFace val = GambleCardExtended.CalculateGambleCardValue(i);
                IList<T>
                    tempOccurenceList = myOccurences[val];
                int occurences = tempOccurenceList.Count;
                if (occurences >= x)
                {
                    for (int j = 0; j < occurences; j++)
                    {
                        List<T>
                            myList = new List<T>();
                        for (int k = j; k < x + j && k < occurences; k++)
                        {
                            myList.Add(tempOccurenceList[k]);
                        }
                        if (myList.Count >= x)
                        {
                            myList.Sort(
                                delegate(T a, T b)
                                {
                                    return a.CompareTo(b);
                                }
                            );
                            myListOfKinds.Add(myList);
                        }
                    }
                }
            }
            if (myListOfKinds.Count <= 0)
            {
                return new List<IList<T>>();
            }
            myListOfKinds.Sort(
                delegate(IList<T> a, IList<T> b)
                {
                    int ret = 0;
                    for (int i = 0; i < a.Count && i < b.Count; i++)
                    {
                        ret = -a[i].CompareTo(b[i]);
                        if (ret != 0)
                        {
                            return ret;
                        }
                    }
                    return -a.Count.CompareTo(b.Count);

                }
            );
            IList<IList<T>> returnList = (IList<IList<T>>)(myListOfKinds);
            return returnList;
        }
        public static bool HasXConsecutive<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            if (x < 2)
            {
                //if x <= 1, then this is useless to call, still we return false
                return false;
            }
            Dictionary<GambleCardFace, int> occurences = self.GetValueOccurenceCount();
            bool found = true;
            for (int i = 0; i <= 13 - (x - 1); i++)
            {
                for (int j = i; j < i + x; j++)
                {
                    if (j > 13)
                    {
                        found = false;
                        break;
                    }
                    GambleCardFace current = GambleCardExtended.CalculateGambleCardValue(j);
                    if (occurences[current] <= 0)
                    {
                        found = false;
                        break;
                    }
                    else
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    return true;
                }
            }
            return found;
        }
        public static bool HasXOfSuit<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            if (x < 1)
            {
                //if x < 0, then this is useless to call, still we return false
                return false;
            }
            Dictionary<GambleCardSuit, int> occurences = self.GetSuitOccurenceCount();
            foreach (GambleCardSuit suit in SUITS)
            {
                if (occurences[suit] < x)
                {
                    continue;
                }
                return true;
            }
            return false;
        }
        public static bool HasXOfAKind<T>(this IGambleCardHand<T> self, int x) where T : IGambleCard
        {
            if (x < 1)
            {
                //if x <= 0, then this is useless to call, still we return false
                return false;
            }
            Dictionary<GambleCardFace, int> occurences = self.GetValueOccurenceCount();
            foreach (GambleCardFace key in occurences.Keys)
            {
                if (occurences[key] >= x)
                {
                    return true;
                }
            }
            return false;
        }
    }
    /*
     import java.util.*;
    /**
     * GambleMethods allows us to modify GambleCards lists/arrays and retrieve data neccecarry for Poker
     * 
     * @author Marcus Kertesz
     * @period 4
     * /
    public class GambleMethods
    {
    
        /**
         * Protected due to acting as a Static Class
         * /
        protected GambleMethods(){
            //Nothing to Construct;
        }
        /**
         * Removes all null objects in a copy of the Array of GambleCards 
         * @param GambleCard[] hand
         * @return A copy of hand with all nulls removed
         * @post hand is not modified
         * /
        public static GambleCard[] removeNulls(GambleCard[] hand){
            if(hand == null){
                return new GambleCard[0];
            }
            int nulls = 0;
            for(GambleCard card : hand){
                if(card == null){
                    nulls++;
                }
            }
            GambleCard[] ret = new GambleCard[hand.length-nulls];
            int added = 0;
            if(ret.length > 0){//no point in searching if the entire array is null
                for(GambleCard card : hand){
                    if(card != null && added < ret.length){
                        ret[added] = card;
                        added++;
                    }
                }
            }
            return ret;
        }
        /**
         * Removes all null objects in a copy of the List of GambleCards 
         * @param ArrayList<GambleCard> hand
         * @return A copy of hand with all nulls removed
         * @post hand is not modified
         * /
        public static ArrayList<GambleCard> removeNulls(ArrayList<GambleCard> hand){
            ArrayList<GambleCard> ret = new ArrayList<GambleCard>();
            if(hand == null){
                return ret;
            }
            for(GambleCard card : hand){
                if(card != null){
                    ret.add(card);
                }
            }
            return ret;
        }
        /**
         * Gets best possible PokerRankedHandData from hand and table cards
         * @param GambleCard[] hand
         * @param GambleCard[] table
         * @return best PokerRankedHandData from hand and table
         * /
        public static PokerRankedHandData  getBestPokerHand(GambleCard[] hand, GambleCard[] table){
            return getBestPokerHand(sort(mergeCards(hand,table)));
        }
        /**
         * Gets best possible PokerRankedHandData from tmpHand
         * @param GambleCard[] tmpHand
         * @return best PokerRankedHandData from tmpHand
         * /
        public static PokerRankedHandData  getBestPokerHand(GambleCard tmpHand[]){
            return getBestPokerHand(toList(tmpHand));
        }
        /**
         * Gets best possible PokerRankedHandData from tmpHandListRef
         * @param ArrayList<GambleCard> tmpHandListRef
         * @return best PokerRankedHandData from tmpHandListRef
         * /
        public static PokerRankedHandData  getBestPokerHand(ArrayList<GambleCard> tmpHandListRef){
            ArrayList<GambleCard> tmpHandList = removeNulls(tmpHandListRef);
            GambleCard[] tmpHand = toArray(tmpHandList);
            GambleCard[] tmpBest = null;
            ArrayList<GambleCard> tmpBestList = new ArrayList<GambleCard>();
            int rank = -1;
            //Straight Flush
            if(tmpBest == null){
                tmpBest = getStraightFlush(tmpHand);
                rank = 8;
            }
            //4King
            if(tmpBest == null){
                tmpBest = getFourKind(tmpHand);
                rank = 7;
            }
            //Full House
            if(tmpBest == null){
                tmpBest = getFullHouse(tmpHand);
                rank = 6;
            }
            //Flush
            if(tmpBest == null){
                tmpBest = getFlush(tmpHand);
                rank = 5;
            }
            //Straight
            if(tmpBest == null){
                tmpBest = getStraight(tmpHand);
                rank = 4;
            }
            //3King
            if(tmpBest == null){
                tmpBest = getThreeKind(tmpHand);
               rank = 3;
            }
            //2Pair
            if(tmpBest == null){
                tmpBest = getTwoPair(tmpHand);
                rank = 2;
            }
            //2Kind
            if(tmpBest == null){
                tmpBest = getTwoKind(tmpHand);
                rank = 1;
            }
            //1Kind
            if(tmpBest == null){
                rank = 0;
                tmpBestList = new ArrayList<GambleCard>();
            }
            else {
                tmpBestList = toList(tmpBest);
                for(GambleCard card : tmpBest){
                    tmpHandList.remove(card);
                }
            }
            while (tmpBestList.size() < 5 && tmpHandList.size() > 0){
                GambleCard tmp = getHighCard(toArray(tmpHandList));
                tmpHandList.remove(tmp);
                tmpBestList.add(tmp);
            }
            return new PokerRankedHandData (toArray(tmpBestList),rank);
        }
        /**
         * Gets the winners from the list of playerHands
         * @param ArrayList<PokerRankedHandData> playerHands
         * @return ArrayList<Integer> of winning hands (where an integer represent a position in the playerHands list)
         * /
        public static ArrayList<Integer> getWinningPokerHand(ArrayList<PokerRankedHandData> playerHands){
            ArrayList<Integer> winners = new ArrayList<Integer>();
            if(playerHands == null || playerHands.size() <= 0){
                return winners;
            }
            PokerRankedHandData  best = playerHands.get(0);
            int count = 0;
            for(PokerRankedHandData  hand : playerHands){
                int dif = hand.compareTo(best);
                if(dif >= 0){
                    if(dif > 0){
                        best = hand;
                        winners.clear();
                    }
                    winners.add(new Integer(count));
                }
                count ++;
            }
            return winners;
        }
        /**
         * Creates an Array from an ArrayList of GambleCards
         * @param ArrayList<GambleCard> cards
         * @return GambleCard[] copy of cards
         * @post cards is not modified
         * /
        protected static GambleCard[] toArray(ArrayList<GambleCard> cards){
            GambleCard[] ret = new GambleCard[cards.size()];
            if(cards != null){
                for(int i = 0; i < ret.length; i ++){
                    ret[i] = cards.get(i);
                }
            }
            return ret;
        }
        /**
         * Creates an ArrayList from an Array [] of GambleCards
         * @param GambleCard[] cards
         * @return ArrayList<GambleCard> copy of cards
         * @post cards is not modified
         * /
        protected static ArrayList<GambleCard> toList(GambleCard[] cards){
            ArrayList<GambleCard> ret = new ArrayList<GambleCard> ();
            if(cards != null){
                for(GambleCard card : cards){
                    ret.add(card);
                }
            }
            return ret;
        }
        /**
         * Gets a Straight Flush
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of StraightFlush 
         * @post usable is not modified
         * /
        protected static GambleCard[] getStraightFlush(GambleCard[] usable){
            GambleCard[] ret = null;
            ret = getStraight(usable);
            if(ret != null){
                ret = getFlush(ret);
            }
            return ret;
        }
        /**
         * Gets a Straight
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of Straight
         * @post usable is not modified
         * /
        protected static GambleCard[] getStraight(GambleCard[] usable){
            GambleCard[] ret = null;
            int added = 0;
            int[] hasCard = hasCardFaces(usable);
            int i = 0;
            for(i = 13; i >= 0; i--){
                int j = 0;
                while((((i-j)%13) > 0) && hasCard[((i-j)%13)] > 0){
                    j++;
                    if(j == 5){
                        ret = new GambleCard[5];
                        for( int k = j - 1; k >= 0; k--){
                            for(GambleCard card : usable){
                                if(EnumMethods.toInt( card.getFace()) == ((i-k) % 13)){
                                    ret[k] = card;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            return ret;
        }
        /**
         * Gets a Flush
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of Flush 
         * @post usable is not modified
         * /
        protected static GambleCard[] getFlush(GambleCard[] usable){
            return getSuitKind(usable,5);
        }
        /**
         * Gets a Four-Of-A-Kind
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of a Four-Of-A-Kind
         * @post usable is not modified
         * /
        protected static GambleCard[] getFourKind(GambleCard[] usable){
            return getFaceKind(usable,4);
        }
        /**
         * Gets a Three-Of-A-Kind
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of a Three-Of-A-Kind
         * @post usable is not modified
         * /
        protected static GambleCard[] getThreeKind(GambleCard[] usable){
            return getFaceKind(usable,3);
        }
        /**
         * Gets a Two-Of-A-Kind
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of a Two-Of-A-Kind
         * @post usable is not modified
         * /
        protected static GambleCard[] getTwoKind(GambleCard[] usable){
            return getFaceKind(usable,2);
        }
        /**
         * Gets a HighCard
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard of the Highest Card possible
         * @post usable is not modified
         * /
        protected static GambleCard getHighCard(GambleCard[] usable){
            try{
                return getFaceKind(usable,1)[0];
            }
            catch(Exception myEx){
                System.out.println("GambleMethods -> getHighCard() : " + myEx.getMessage());
                String ret = new String("\t" + "Usable : " + "\n" );
                for(GambleCard c : usable){
                    if(c != null){
                        ret += "\t" + "\t" + c.toString() + "\n";
                    }
                    else{
                        ret += "\t" + "\t" + "null" + "\n";
                    }
                }
                System.out.println(ret);
                GambleCard[] arr = getFaceKind(usable,1); 
                ret = new String("\t" + "GetFaceKindArr : ");
                if(arr == null){
                    ret += "null" + "\n";
                }
                else{
                    ret += "\n";
                    for(GambleCard c : arr){
                        if(c != null){
                            ret += "\t" + "\t" + c.toString() + "\n";
                        }
                        else{
                            ret += "\t" + "\t" + "null" + "\n";
                        }
                    }
                }
                System.out.println(ret);
                return null;
            }
        }
        /**
         * Gets a Full House
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of a Full House
         * @post usable is not modified
         * /
        protected static GambleCard[] getFullHouse(GambleCard[] usable){
            GambleCard[] tmp = getFaceKind(usable,3);
            if(tmp == null){
                return tmp;
            }
            else{
                GambleCard tmp2[] = getFaceKindAvoid(usable,2,EnumMethods.toInt( tmp[0].getFace()));
                if(tmp2 == null){
                    return tmp2;
                }
                else{
                    return mergeCards(tmp,tmp2);
                }
            }
        }
        /**
         * Gets a Two-Pair
         * @param GambleCard[] usable
         * @return null if not found, otherwise, GambleCard[] array of a Two-Pair
         * @post usable is not modified
         * /
        protected static GambleCard[] getTwoPair(GambleCard[] usable){
            GambleCard[] tmp = getFaceKind(usable,2);
            if(tmp == null){
                return tmp;
            }
            else{
                GambleCard tmp2[] = getFaceKindAvoid(usable,2,EnumMethods.toInt( tmp[0].getFace()));
                if(tmp2 == null){
                    return tmp2;
                }
                else{
                    return mergeCards(tmp,tmp2);
                }
            }
        }
        /**
         * Merges two GambleCard[] arrays together
         * @param GambleCard[] a
         * @param GambleCard[] b
         * @return merged array of GambleCard[]
         * @post a and b are not modified
         * /
        protected static GambleCard[] mergeCards(GambleCard[] a, GambleCard[] b){
            GambleCard[] merged = new GambleCard[a.length+b.length];
            for(int i = 0; i < a.length; i++){
                merged[i] = a[i];
            }
            for(int i = 0; i < b.length; i++){
                merged[i+a.length] = b[i];
            }
            return merged;
        }
        /**
         * Merges a GambleCard[] array and a GambleCard together
         * @param GambleCard[] a
         * @param GambleCard b
         * @return merged array of GambleCard[]
         * @post a and b are not modified
         * /
        protected static GambleCard[] mergeCards(GambleCard[] a, GambleCard b){
            return mergeCards(toCardArr(b),a);
        }
        /**
         * Merges a GambleCard[] array and a GambleCard together
         * @param GambleCard a
         * @param GambleCard[] b
         * @return merged array of GambleCard[]
         * @post a and b are not modified
         * /
        protected static GambleCard[] mergeCards(GambleCard a, GambleCard b[]){
            return mergeCards(toCardArr(a),b);
        }
        /**
         * Creates an array from a GambleCard
         * @param GambleCard a
         * @return new array of GambleCard[]
         * @post a is not modified
         * /
        protected static GambleCard[] toCardArr(GambleCard a){
            GambleCard[] b = { a };
            return b;
        }
        /**
         * Gets X amount of GambleCards of the same suit from usable
         * @param GambleCard[] usable
         * @param int X
         * @return null if X amount of cards with the same suit is not avaliable
         * @post usable is not modified
         * /
        protected static GambleCard[] getSuitKind(GambleCard[] usable, int X){
            GambleCard[] ret = null;
            int added = 0;
            int[] hasCard = hasCardSuits(usable);
            for(int i = 0; i < 4; i++){
                if(hasCard[i] >= X){
                    ret = new GambleCard[X];
                    for(GambleCard card : usable){
                        if(EnumMethods.toInt( card.getSuit()) == i && added < ret.length){
                            ret[added] = card;
                            added++;
                        }
                    }
                    break;
                }
            }
            return ret;
        }
        /**
         * Gets X amount of GambleCards of the same face value from usable
         * @param GambleCard[] usable
         * @param int X
         * @return null if X amount of cards with the same face value is not avaliable
         * @post usable is not modified
         * /
        protected static GambleCard[] getFaceKind(GambleCard[] usable, int X){
            return getFaceKindAvoid(usable,X,-1);//use -1 to not avoid anythign
        }
        /**
         * Gets X amount of GambleCards of the same face value that is not avoid from usable
         * @param GambleCard[] usable
         * @param int X
         * @param int avoid
         * @return null if X amount of cards with the same face value that are not avoid is not avaliable
         * @post usable is not modified
         * /
        protected static GambleCard[] getFaceKindAvoid(GambleCard[] usable, int X, int avoid){
            GambleCard[] ret = null;
            int added = 0;
            int[] hasCard = hasCardFaces(usable);
            for(int i = 12; i >= 0; i--){
                //System.out.println("Checking " + EnumMethods.toFace(i).toString() + "s");
                if(hasCard[i] >= X  && i != avoid){//Aces are highest
                    //System.out.println(X + " " + EnumMethods.toFace(i).toString() + "s" + " found");
                    ret = new GambleCard[X];
                    for(GambleCard card : usable){
                    
                        if(card != null && EnumMethods.toInt( card.getFace()) == i && added < ret.length){
                            //System.out.println(card.toString() + " added");
                            ret[added] = card;
                            added++;
                        }
                    }
                    break;
                }
            }
            return ret;
        }
        /**
         * Gets an array representing the number of cards (by face) in cardsToCheck
         * @param GambleCard[] cardsToCheck
         * @return int[] array of card faces in cardsToCheck
         * /
        protected static int[] hasCardFaces(GambleCard[] cardsToCheck){
            int[] tmp = new int[13]; 
            for(GambleCard card : cardsToCheck){
                if(card != null){
                    tmp[EnumMethods.toInt( card.getFace())]++;
                }
            }
            return tmp;
        }
        /**
         * Gets an array representing the number of cards (by suit) in cardsToCheck
         * @param GambleCard[] cardsToCheck
         * @return int[] array of card suits in cardsToCheck
         * /
        protected static int[] hasCardSuits(GambleCard[] cardsToCheck){
            int[] tmp = new int[4]; //0 is Spaces, 1 is Hearts, 2 is Clubs, 3 is Diamonds
            for(GambleCard card : cardsToCheck){
                if(card != null){
                    tmp[EnumMethods.toInt( card.getSuit())]++;
                }
            }
            return tmp;   
        }
        /**
         * Sorts the GambleCard[] array from highest to lowest face, with highest to lowest suits besting ties
         * @param GambleCard[] cardsToSort
         * @return sorted cardsToSort
         * @post cardsToSort is modified
         * /
        protected static GambleCard[] sort(GambleCard[] cardsToSort){
            if(cardsToSort == null){
                return null;
            }
            quickSort(cardsToSort,0,cardsToSort.length-1);
            return cardsToSort;
        }
        /**
         * Sorts the GambleCard[] array from highest to lowest face, with highest to lowest suits besting ties
         * @param GambleCard[] cardsToSort
         * @param int low
         * @param int high
         * @post cardsToSort is modified
         * /
        protected static void quickSort(GambleCard[] cardsToSort, int low, int high){
            if(low > high || cardsToSort == null){
                return;
            }
            int i = low, j = high;
            GambleCard pivot = cardsToSort[low + (high-low) / 2];
            while (i <= j){
                while(i <= high && (cardsToSort[i] == null || pivot == null || cardsToSort[i].compareToCard(pivot) > 0)){
                    i++;
                }
                while(j >= low && (cardsToSort[j] == null || pivot == null  || cardsToSort[j].compareToCard(pivot) < 0)){
                    j--;
                }
                if(i <= j){
                    GambleCard temp = cardsToSort[i];
                    cardsToSort[i] = cardsToSort[j];
                    cardsToSort[j] = temp;
                    i++;
                    j--;
                }
            }        
            if(low < j){
                quickSort(cardsToSort,low,j);
            }
            if(high > i){
                quickSort(cardsToSort,i,high);
            }
        }
    }

     */
}
