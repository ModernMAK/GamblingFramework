using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;

namespace GamblingFramework.Poker
{
    public interface ITexasHoldemPokerTable :
        ITexasHoldemPokerTable<
            IGambleCardPlayer,
            IGambleCard,
            IGambleCardDeck,
            IGambleCardHand
        >
    {
    }
}
namespace GamblingFramework.Poker.Generic
{
    public interface ITexasHoldemPokerTable<T, U, V, W> : IGambleCardTable<T, U, V>
        where T : IGambleCardPlayer<U>
        where U : IGambleCard
        where V : IGambleCardDeck<U>
        where W : IGambleCardHand<U>
    {
        W TableCards
        {
            get;
            set;
        }
        W BurnCards
        {
            get;
            set;
        }
        //Later perform Pot-Splitting logic properties and stuff
        int Pot
        {
            get;
            set;
        }
        int MinimumDenomination
        {
            get;
            set;
        }
        int LowBlind
        {
            get;
            set;
        }
        int HighBlind
        {
            get;
            set;
        }
        //Later impliment Table Limits, maybe?
    }
}
