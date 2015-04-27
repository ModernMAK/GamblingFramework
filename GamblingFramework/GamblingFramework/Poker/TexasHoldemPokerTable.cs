using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;

namespace GamblingFramework.Poker
{
    public class TexasHoldemPokerTable : TexasHoldemPokerTable<IGambleCardPlayer, IGambleCard, IGambleCardDeck, IGambleCardHand>, ITexasHoldemPokerTable
    {
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
    }
}
namespace GamblingFramework.Poker.Generic
{
    public class TexasHoldemPokerTable<T, U, V, W> : GambleTable<T, U, V>, ITexasHoldemPokerTable<T, U, V, W>
        where T : IGambleCardPlayer<U>
        where U : IGambleCard
        where V : IGambleCardDeck<U>
        where W : IGambleCardHand<U>
    {
        public TexasHoldemPokerTable()
            : this(default(V), default(W), default(W))
        {
        }
        public TexasHoldemPokerTable(V deck, W table, W burn, int minDenomination = 1, int players = 2)
            : this(deck, table, burn, minDenomination, new T[players])
        {
        }
        public TexasHoldemPokerTable(V deck, W table, W burn, int minDenomination = 1, params T[] players)
            : base(deck, players)
        {
            TableCards = table;
            BurnCards = burn;

            MinimumDenomination = minDenomination;
            LowBlind = MinimumDenomination;
        }

        private W
            myTableCards,
            myBurnCards;

        private int
            myMinDenomination,
            myBlind,
            myPot;

        public W TableCards
        {
            get
            {
                return myTableCards;
            }
            set
            {
                myTableCards = value;
            }
        }

        public W BurnCards
        {
            get
            {
                return myBurnCards;
            }
            set
            {
                myBurnCards = value;
            }
        }

        public int Pot
        {
            get
            {
                return myPot;
            }
            set
            {
                myPot = value;
            }
        }

        public int MinimumDenomination
        {
            get
            {
                return myMinDenomination;
            }
            set
            {
                myMinDenomination = value;
            }
        }

        public int LowBlind
        {
            get
            {
                return myBlind;
            }
            set
            {
                myBlind = value;
            }
        }

        public int HighBlind
        {
            get
            {
                return myBlind * 2;
            }
            set
            {
                myBlind = value / 2;
            }
        }

        public override string ToString()
        {
            string toString = this.GetType().ToString() + "{ ";
            #region Players
            toString += "Players{ ";
            for (int i = 0; i < this.Players.Length; i++)
            {
                toString +=
                    ((this.Players[i] == null) ?
                        "EMPTY" :
                        this.Players[i].Name);
                if (i != this.Players.Length - 1)
                {
                    toString += ", ";
                }
            }
            toString += " }";
            #endregion

            toString +=
                Deck.ToString() +
                TableCards.ToString() +
                BurnCards.ToString() +
                "Pot{ " + Pot.ToString() + " }" +
                "Minimum Denomination{ " + MinimumDenomination.ToString() + "  }" +
                "Low Blind{ " + LowBlind.ToString() + "  }" +
                "High Blind{ " + HighBlind.ToString() + " }";

            toString += " }";
            return toString;
        }
    }
}