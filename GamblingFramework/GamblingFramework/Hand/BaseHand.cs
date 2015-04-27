using System;
using System.Collections.Generic;
using System.Collections;
using GamblingFramework.Generic;

namespace GamblingFramework.Generic
{
    public class BaseHand<T> : IHand<T> where T : ICard
    {
        public BaseHand()
            : this((List<T>)null)
        {

        }
        public BaseHand(params T[] cards)
            : this((List<T>)null)
        {
            foreach (T card in cards)
            {
                if (card == null)
                {
                    continue;
                }
                this.Add(card);
            }
        }
        public BaseHand(List<T> hand)
        {
            this.myList = (hand ?? new List<T>());
        }


        private List<T>
            myList;

        #region IHand
        public virtual void ResetHand()
        {
            this.Clear();
        }

        public void AddCardFromDeckToHand(IDeck<T> deck)
        {
            this.Add(
                    deck.DrawCard()
                );
        }

        public virtual void Sort()
        {
            this.Sort(
                    delegate(T x, T y)
                    {
                        return x.Index.CompareTo(y.Index);
                    }
                );
        }

        public void Sort(IComparer<T> comparar)
        {
            this.Sort(comparar);
        }

        public void Sort(System.Comparison<T> comparar)
        {
            this.Sort(comparar);
        }
        #endregion

        #region IList
        public int IndexOf(T item)
        {
            return this.myList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return this.myList[index];
            }
            set
            {
                this.myList[index] = value;
            }
        }

        public void Add(T item)
        {
            this.myList.Add(item);
        }

        public void Clear()
        {
            this.myList.Clear();
        }

        public bool Contains(T item)
        {
            return this.myList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.myList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return this.myList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((IList<T>)myList).IsReadOnly;
            }
        }

        public bool Remove(T item)
        {
            return this.myList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }
        #endregion

        public override string ToString()
        {
            string toString = this.GetType().ToString() + "{ ";
            for (int i = 0; i < this.Count; i++)
            {
                toString += this[i].ToString();
                if (i != this.Count - 1)
                {
                    toString += ", ";
                }
            }
            toString += " }";
            return toString;
        }
    }
}

namespace GamblingFramework
{
    public class BaseHand : BaseHand<ICard>
    {
        public BaseHand()
            : base()
        {
        }
        public BaseHand(params ICard[] cards)
            : base(cards)
        {
        }
        public BaseHand(List<ICard> hand)
            : base(hand)
        {
        }
    }
}