using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;
using GamblingFramework.Poker;

namespace GamblingFramework.Poker.Generic
{
    public class TexasHoldemPokerHand<T> : GambleCardHand<T>, ITexasHoldemPokerHand<T>
        where T : IGambleCard
    {

        public TexasHoldemPokerHand()
            : base() { }
            
        public TexasHoldemPokerHand(ITexasHoldemPokerHand<T> hand)
            : this(hand,hand.Rank)
        {
        }
        public TexasHoldemPokerHand(TexasHoldemPokerRank rank = TexasHoldemPokerRank.HighCard, params T[] cards)
            : base(cards)
        {
            this.Rank = rank;
        }
        public TexasHoldemPokerHand(IHand<T> hand, TexasHoldemPokerRank rank = TexasHoldemPokerRank.HighCard)
            : base(hand)
        {
            this.Rank = rank;

        }
        public new IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private TexasHoldemPokerRank
            myRank;

        public TexasHoldemPokerRank Rank
        {
            get
            {
                return myRank;
            }
            set
            {
                myRank = value;
            }
        }
    }
}
namespace GamblingFramework.Poker
{
    public class TexasHoldemPokerHand : TexasHoldemPokerHand<IGambleCard>, ITexasHoldemPokerHand
    {

        public TexasHoldemPokerHand()
            : base()
        {
            this.Rank = TexasHoldemPokerRank.HighCard;
        }
        public TexasHoldemPokerHand(ITexasHoldemPokerHand hand)
            : base(hand)
        {
        }
        public TexasHoldemPokerHand(TexasHoldemPokerRank rank = TexasHoldemPokerRank.HighCard, params IGambleCard[] cards)
            : base(rank, cards)
        {
            this.Rank = rank;
        }
        public TexasHoldemPokerHand(IHand<IGambleCard> hand, TexasHoldemPokerRank rank = TexasHoldemPokerRank.HighCard)
            : base(hand, rank)
        {
            this.Rank = rank;

        }
    }
}
