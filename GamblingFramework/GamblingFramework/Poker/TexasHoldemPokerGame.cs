using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;

namespace GamblingFramework.Poker
{
    public interface ITexasHoldemPokerGame : ITexasHoldemPokerGame<
            ITexasHoldemPokerTable,
            IGambleCardPlayer,
            IGambleCard,
            IGambleCardDeck,
           IGambleCardHand
        >
    {
    }


    public class TexasHoldemPokerGame :
        TexasHoldemPokerGame<
            ITexasHoldemPokerTable,
            IGambleCardPlayer,
            IGambleCard,
            IGambleCardDeck,
            IGambleCardHand
        >, ITexasHoldemPokerGame
    {
        public TexasHoldemPokerGame()
            : this(default(ITexasHoldemPokerTable))
        {
        }
        public TexasHoldemPokerGame(ITexasHoldemPokerTable table)
            : base(table)
        {
        }
        /*
        public TexasHoldemPokerTable()
            : base()
        {
        }
        public TexasHoldemPokerTable(IGambleCardDeck deck, IGambleCardHand table, IGambleCardHand burn, int minDenomination, int players)
            : base(deck, table, burn, minDenomination, players)
        {
        }
        public TexasHoldemPokerTable(IGambleCardDeck deck, IGambleCardHand table, IGambleCardHand burn, int minDenomination, params IGambleCardPlayer[] players)
            : base(deck, table, burn, minDenomination, players)
        {
        }
         */
    }
}
namespace GamblingFramework.Poker.Generic
{

    public interface ITexasHoldemPokerGame<T, U, V, W, X> //: GambleTable<T, U, V>, ITexasHoldemPokerTable<T, U, V, W>
        where T : ITexasHoldemPokerTable<U, V, W, X>
        where U : IGambleCardPlayer<V>
        where V : IGambleCard
        where W : IGambleCardDeck<V>
        where X : IGambleCardHand<V>
    {
        /*
        public TexasHoldemPokerGame()
            : this(default(T))
        {
        }
        public TexasHoldemPokerGame(T table)
        {
            this.Table = table;
        }

        private T
            myTable;
         */
        T Table
        {
            get;
            set;
        }
    }

    public class TexasHoldemPokerGame<T, U, V, W, X> : ITexasHoldemPokerGame<T, U, V, W, X>//: GambleTable<T, U, V>, ITexasHoldemPokerTable<T, U, V, W>
        where T : ITexasHoldemPokerTable<U, V, W, X>
        where U : IGambleCardPlayer<V>
        where V : IGambleCard
        where W : IGambleCardDeck<V>
        where X : IGambleCardHand<V>
    {
        public TexasHoldemPokerGame()
            : this(default(T))
        {
        }
        public TexasHoldemPokerGame(T table)
        {
            this.Table = table;
        }

        private T
            myTable;
        public T Table
        {
            get
            {
                return myTable;
            }
            set
            {
                myTable = value;
            }
        }
    }
}