using System;
using System.Collections;
using System.Collections.Generic;

namespace GamblingFramework
{
    public class BaseTable<T> : ITable<T> where T : IPlayer
    {
        public BaseTable()
            : this(2)
        {
        }
        public BaseTable(int players)
            : this(new T[players])
        {
        }
        public BaseTable(params T[] players)
        {
            this.myPlayers = players;
        }

        private T[]
            myPlayers;

        public T[] Players
        {
            get
            {
                return myPlayers;
            }
            set
            {
                myPlayers = value;
            }
        }

        public bool AddPlayer(T player)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i] == null)
                {
                    Players[i] = player;
                    return true;
                }
            }
            return false;
        }
        public bool RemovePlayer(T player)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Equals(player))
                {
                    Players[i] = default(T);
                    return true;
                }
            }
            return false;
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
            toString += " }";
            return toString;
        }
    }
}
