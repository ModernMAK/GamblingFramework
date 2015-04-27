using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public class GambleTable : GambleTable<IGambleCardPlayer<IGambleCard>, IGambleCard, IGambleCardDeck<IGambleCard>>
    {
        public GambleTable()
            : base()
        {
        }
        public GambleTable(IGambleCardDeck<IGambleCard> deck, int players = 2)
            : base(deck, players)
        {
        }
        public GambleTable(IGambleCardDeck<IGambleCard> deck, params IGambleCardPlayer<IGambleCard>[] players)
            : base(deck, players)
        {
        }
    }
}
namespace GamblingFramework.Generic
{
    public class GambleTable<T, U, V> : BaseTable<T>, IGambleCardTable<T, U, V>
        where T : IGambleCardPlayer<U>
        where U : IGambleCard
        where V : IGambleCardDeck<U>
    {
        public GambleTable()
            : this(default(V))
        {
        }
        public GambleTable(V deck, int players = 2)
            : this(deck, new T[players])
        {
        }
        public GambleTable(params T[] players)
            : this(default(V), players)
        {
        }
        public GambleTable(V deck, params T[] players)
            : base(players)
        {
            this.myDeck = deck;
        }

        private V
            myDeck;

        public V Deck
        {
            get
            {
                return myDeck;
            }
            set
            {
                myDeck = value;
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
            toString += Deck.ToString();
            toString += " }";
            return toString;
        }
    }
}
