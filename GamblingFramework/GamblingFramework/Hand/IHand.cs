using System;
using System.Collections.Generic;
using System.Collections;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface IHand : IHand<ICard>
    {
    }
}


namespace GamblingFramework.Generic
{
    public interface IHand<T> : IList<T> where T : ICard
    {
        void ResetHand();
        void AddCardFromDeckToHand(IDeck<T> deck);
        void Sort();
        void Sort(IComparer<T> comparar);
        void Sort(System.Comparison<T> comparar);
        string ToString();
    }
}
