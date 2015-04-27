using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;

namespace GamblingFramework.Poker
{
    public interface ITexasHoldemPokerHand : ITexasHoldemPokerHand<IGambleCard>
    {
    }
}

namespace GamblingFramework.Poker.Generic
{
    public interface ITexasHoldemPokerHand<T> : IGambleCardHand<T> 
        where T : IGambleCard
    {

        TexasHoldemPokerRank Rank
        {
            get;
            set;
        }
    }
}
