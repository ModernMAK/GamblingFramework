using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Poker;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;
namespace GamblingFramework.Poker
{
    public static class IGambleHandExtensions
    {
        public static ITexasHoldemPokerHand GetBestPokerHand(this ITexasHoldemPokerHand self)
        {
            ITexasHoldemPokerHand<IGambleCard> temp = ((ITexasHoldemPokerHand<IGambleCard>)self);

            ITexasHoldemPokerHand<IGambleCard> best = temp.GetBestPokerHand();
            return new TexasHoldemPokerHand(best, best.Rank);
        }

        //Get Explicit Amounts
        public static IList<IGambleCard> GetFullHouse(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetFullHouse();
        }
        public static IList<IGambleCard> GetRoyalFlush(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetRoyalFlush();
        }
        public static IList<IGambleCard> GetStraightFlush(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetStraightFlush();
        }
        public static IList<IGambleCard> GetFlush(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetFlush();
        }
        public static IList<IGambleCard> GetStraight(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetStraight();
        }

        public static IList<IGambleCard> GetFourOfAKind(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetFourOfAKind();
        }
        public static IList<IGambleCard> GetThreeOfAKind(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetThreeOfAKind();
        }
        public static IList<IGambleCard> GetTwoPair(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetTwoPair();
        }
        public static IList<IGambleCard> GetPair(this ITexasHoldemPokerHand self)
        {
            return ((ITexasHoldemPokerHand<IGambleCard>)self).GetPair();
        }
    }
}

namespace GamblingFramework.Poker.Generic
{
    public static class IGambleHandExtensions
    {
        public static ITexasHoldemPokerHand<T> GetBestPokerHand<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            ITexasHoldemPokerHand<T>
                tempHand = new TexasHoldemPokerHand<T>(self),
                currentBest = new TexasHoldemPokerHand<T>();
            IList<T>
                tempBest;
            TexasHoldemPokerRank
                currentRank = TexasHoldemPokerRank.HighCard;
            bool hit = false;

            int remaining = (5 - currentBest.Count);

            tempBest = tempHand.GetRoyalFlush();
            if (tempBest.Count > 0 && !hit)
            {
                if (currentRank < TexasHoldemPokerRank.RoyalFlush)
                {
                    currentRank = TexasHoldemPokerRank.RoyalFlush;
                }
                for (int i = 0; i < tempBest.Count; i++)
                {
                    currentBest.Add(tempBest[i]);
                    tempHand.Remove(tempBest[i]);
                }
                remaining = (5 - currentBest.Count);
                hit = true;
            }
            if (!hit)
            {
                tempBest = tempHand.GetStraightFlush();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.StraightFlush)
                    {
                        currentRank = TexasHoldemPokerRank.StraightFlush;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetFourOfAKind();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.FourOfAKind)
                    {
                        currentRank = TexasHoldemPokerRank.FourOfAKind;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetFullHouse();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.FullHouse)
                    {
                        currentRank = TexasHoldemPokerRank.FullHouse;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetFlush();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.Flush)
                    {
                        currentRank = TexasHoldemPokerRank.Flush;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetStraight();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.Straight)
                    {
                        currentRank = TexasHoldemPokerRank.Straight;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetThreeOfAKind();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.ThreeOfAKind)
                    {
                        currentRank = TexasHoldemPokerRank.ThreeOfAKind;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetTwoPair();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.TwoPair)
                    {
                        currentRank = TexasHoldemPokerRank.TwoPair;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }
            if (!hit)
            {
                tempBest = tempHand.GetPair();
                if (tempBest.Count > 0)
                {
                    if (currentRank < TexasHoldemPokerRank.OnePair)
                    {
                        currentRank = TexasHoldemPokerRank.OnePair;
                    }
                    for (int i = 0; i < tempBest.Count; i++)
                    {
                        currentBest.Add(tempBest[i]);
                        tempHand.Remove(tempBest[i]);
                    }
                    remaining = (5 - currentBest.Count);
                    hit = true;
                }
            }

            while (remaining >= 1)
            {
                T card = tempHand.GetHighCard();

                if (card != null)
                {
                    currentBest.Add(card);
                    tempHand.Remove(card);

                    remaining = (5 - currentBest.Count);
                }
                else
                {
                    break;
                }
            }
            //Console.WriteLine(currentRank.ToString());
            currentBest.Rank = currentRank;

            return currentBest;
        }

        //Get Explicit Amounts
        public static IList<T> GetFullHouse<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            ITexasHoldemPokerHand<T>
                tempHand = new TexasHoldemPokerHand<T>(self);
            IList<T>
                fullHouse = new List<T>(),
                tempKind = tempHand.GetThreeOfAKind();
            if (tempKind.Count > 0)
            {
                for (int i = 0; i < tempKind.Count; i++)
                {
                    tempHand.Remove(tempKind[i]);
                    fullHouse.Add(tempKind[i]);
                }
                tempKind = tempHand.GetPair();
                if (tempKind.Count > 0)
                {
                    for (int i = 0; i < tempKind.Count; i++)
                    {
                        //We dont carea bout removing, so just add
                        fullHouse.Add(tempKind[i]);
                    }
                }
                else
                {
                    fullHouse.Clear();
                }
            }
            return fullHouse;

        }
        public static IList<T> GetRoyalFlush<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            IList<T> straightFlush = self.GetStraightFlush();
            if (straightFlush.Count <= 0 || straightFlush[0].Face != GambleCardFace.Ace)
            {
                return new List<T>();
            }
            return straightFlush;

        }
        public static IList<T> GetStraightFlush<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            List<IList<T>> allStraightFlushs = new List<IList<T>>(self.GetXConsecutiveOfSuit());
            if (allStraightFlushs.Count <= 0)
            {
                return new List<T>();
            }
            allStraightFlushs.Sort(
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

            return allStraightFlushs[0];
        }
        public static IList<T> GetFlush<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            IList<IList<T>> flushs = self.GetXOfSuit();
            if (flushs.Count <= 0)
            {
                return new List<T>();
            }

            List<IList<T>> sort = new List<IList<T>>(flushs);
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
            return sort[0];
        }
        public static IList<T> GetStraight<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            IList<IList<T>> straights = self.GetXConsecutive();
            if (straights.Count <= 0)
            {
                return new List<T>();
            }

            List<IList<T>> sort = new List<IList<T>>(straights);
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
            return sort[0];
        }

        public static IList<T> GetFourOfAKind<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            List<IList<T>>
                quads = new List<IList<T>>(self.GetXOfAKind(4));
            if (quads.Count <= 0)
            {
                return new List<T>();
            }

            quads.Sort(
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
            return quads[0];
        }
        public static IList<T> GetThreeOfAKind<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            List<IList<T>>
                triplets = new List<IList<T>>(self.GetXOfAKind(3));
            if (triplets.Count <= 0)
            {
                return new List<T>();
            }

            triplets.Sort(
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
            return triplets[0];
        }
        public static IList<T> GetTwoPair<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            ITexasHoldemPokerHand<T>
                tempHand = new TexasHoldemPokerHand<T>(self);
            IList<T>
                pair = new List<T>(),
                tempPair = tempHand.GetPair();
            if (tempPair.Count > 0)
            {
                for (int i = 0; i < tempPair.Count; i++)
                {
                    tempHand.Remove(tempPair[i]);
                    pair.Add(tempPair[i]);
                }
                tempPair = tempHand.GetPair();
                if (tempPair.Count > 0)
                {
                    for (int i = 0; i < tempPair.Count; i++)
                    {
                        //We dont carea bout removing, so just add
                        pair.Add(tempPair[i]);
                    }
                }
                else
                {
                    pair.Clear();
                }
            }
            return pair;
        }
        public static IList<T> GetPair<T>(this ITexasHoldemPokerHand<T> self) where T : IGambleCard
        {
            List<IList<T>>
                pairs = new List<IList<T>>(self.GetXOfAKind(2));
            if (pairs.Count <= 0)
            {
                return new List<T>();
            }

            pairs.Sort(
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
            return pairs[0];
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
