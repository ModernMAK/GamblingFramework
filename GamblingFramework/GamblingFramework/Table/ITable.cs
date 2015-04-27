using System;
using System.Collections;
using System.Collections.Generic;

namespace GamblingFramework
{
    public interface ITable<T> where T : IPlayer
    {
        T[] Players
        {
            get;
            set;
        }
        bool AddPlayer(T player);
        bool RemovePlayer(T player);
        string ToString();
    }
}
