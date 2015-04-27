using GamblingFramework.Generic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GamblingFramework
{
    //This serves more as a wrapper class for Deck-Exclusive methods (Like Shuffle, Reset, DrawCard, etc)
    [Serializable]
    public class BaseDeck : BaseDeck<ICard>
    {
        public BaseDeck()
            : base()
        {
        }
        public BaseDeck(IList<ICard> reference)
            : base(reference)
        {
        }
        public BaseDeck(params ICard[] cards)
            : base(cards)
        {
        }
        public BaseDeck(IDeck<ICard> reference)
            : base(reference)
        {
        }
        /*
        private List<ICard>
            myList;

        /// <summary>
        /// Gets the index of the Item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The index of the item, -1 if it does not exist.</returns>
        public int IndexOf(ICard item)
        {
            return this.myList.IndexOf(item);
        }

        /// <summary>
        /// Inserts the item at the desired index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, ICard item)
        {
            this.myList.Insert(index, item);
        }

        /// <summary>
        /// Removes the item at the desired index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.myList.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The item at the given index.</returns>
        public ICard this[int index]
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

        /// <summary>
        /// Adds an item to the deck.
        /// </summary>
        /// <param name="item"></param>
        public void Add(ICard item)
        {
            this.myList.Add(item);
        }

        /// <summary>
        /// Clears the deck.
        /// </summary>
        public void Clear()
        {
            this.myList.Clear();
        }

        /// <summary>
        /// Finds item in deck, and returns true if found.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item is found, false otherwise.</returns>
        public bool Contains(ICard item)
        {
            return this.myList.Contains(item);
        }

        /// <summary>
        /// Copies the deck to the given array, the deck begins in the array at arrayIndex. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(ICard[] array, int arrayIndex)
        {
            this.myList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The number of cards in the Deck
        /// </summary>
        public int Count
        {
            get
            {
                return this.myList.Count;
            }
        }

        /// <summary>
        /// Whether this deck is read only. This should generally be false.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return ((IList)this.myList).IsReadOnly;
            }
        }

        /// <summary>
        /// Removes the item from the deck.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item was removed, false otherwise.</returns>
        public bool Remove(ICard item)
        {
            return this.myList.Remove(item);
        }

        /// <summary>
        /// Gets a strongly-typed enumerator for the Deck.
        /// </summary>
        /// <returns>Strongly-Typed enumerator.</returns>
        public IEnumerator<ICard> GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }

        /// <summary>
        /// Gets a weakly-typed enumerator for the Deck.
        /// </summary>
        /// <returns>Weakly-Typed enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }

        /// <summary>
        /// Sorts the deck by Card Index.
        /// </summary>
        public virtual void Sort()
        {
            Sort(
                delegate(T x, T y)
                {
                    return x.CompareTo(y);
                }
            );
        }

        /// <summary>
        /// Sorts the deck using the specified comparar.
        /// </summary>
        /// <param name="comparar"></param>
        public void Sort(IComparer<ICard> comparar)
        {
            myList.Sort(comparar);
        }

        /// <summary>
        /// Sorts the deck using the specified comparison.
        /// </summary>
        /// <param name="comparison"></param>
        public void Sort(System.Comparison<ICard> comparison)
        {
            myList.Sort(comparison);
        }

        /// <summary>
        /// Resets the deck (clears it in this case).
        /// </summary>
        public virtual void ResetDeck()
        {
            //We cant reset a deck without knowing the kind
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Draws the topmost card from the deck, and removes the drawn card from the deck.
        /// </summary>
        /// <returns>The drawn (topmost) card.</returns>
        public ICard DrawCard()
        {
            T card = this[0];
            this.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Shuffles the deck using a Simple Shuffle (we don't know the importance of the deck, so we go for the simpler shuffle)
        /// </summary>
        public virtual void Shuffle()
        {
            myList.SimpleShuffle<T>();
        }

        /// <summary>
        /// Gets a string representation of the Deck.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            string toString = this.GetType().ToString() + "{ ";
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == null)
                {
                    toString += "NULL";
                }
                else
                {
                    toString += this[i].ToString();
                }

                if (i != this.Count - 1)
                {
                    toString += ", ";
                }
            }
            toString += " }";
            return toString;
        }
        */
    }
}

namespace GamblingFramework.Generic
{
    //This serves more as a wrapper class for Deck-Exclusive methods (Like Shuffle, Reset, DrawCard, etc)
    [Serializable]
    public class BaseDeck<T> : IDeck<T> where T : ICard
    {
        public BaseDeck()
            : this((IList<T>)null)
        {
        }

        public BaseDeck(IList<T> reference)
        {
            if (reference == null)
            {
                myList = new List<T>();
            }
            else
            {
                myList = new List<T>(reference);
            }
        }
        public BaseDeck(params T[] cards)
        {
            if (cards == null)
            {
                myList = new List<T>();
            }
            else
            {
                myList = new List<T>(cards);
            }
        }
        public BaseDeck(IDeck<T> reference)
            : this((IList<T>)reference)
        {
        }

        private List<T>
            myList;

        /// <summary>
        /// Gets the index of the Item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The index of the item, -1 if it does not exist.</returns>
        public int IndexOf(T item)
        {
            return this.myList.IndexOf(item);
        }

        /// <summary>
        /// Inserts the item at the desired index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            this.myList.Insert(index, item);
        }

        /// <summary>
        /// Removes the item at the desired index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.myList.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the item at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The item at the given index.</returns>
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

        /// <summary>
        /// Adds an item to the deck.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            this.myList.Add(item);
        }

        /// <summary>
        /// Clears the deck.
        /// </summary>
        public void Clear()
        {
            this.myList.Clear();
        }

        /// <summary>
        /// Finds item in deck, and returns true if found.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item is found, false otherwise.</returns>
        public bool Contains(T item)
        {
            return this.myList.Contains(item);
        }

        /// <summary>
        /// Copies the deck to the given array, the deck begins in the array at arrayIndex. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.myList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The number of cards in the Deck
        /// </summary>
        public int Count
        {
            get
            {
                return this.myList.Count;
            }
        }

        /// <summary>
        /// Whether this deck is read only. This should generally be false.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return ((IList)this.myList).IsReadOnly;
            }
        }

        /// <summary>
        /// Removes the item from the deck.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item was removed, false otherwise.</returns>
        public bool Remove(T item)
        {
            return this.myList.Remove(item);
        }

        /// <summary>
        /// Gets a strongly-typed enumerator for the Deck.
        /// </summary>
        /// <returns>Strongly-Typed enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }

        /// <summary>
        /// Gets a weakly-typed enumerator for the Deck.
        /// </summary>
        /// <returns>Weakly-Typed enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.myList.GetEnumerator();
        }

        /// <summary>
        /// Sorts the deck by Card Index.
        /// </summary>
        public virtual void Sort()
        {
            Sort(
                delegate(T x, T y)
                {
                    return x.CompareTo(y);
                }
            );
        }

        /// <summary>
        /// Sorts the deck using the specified comparar.
        /// </summary>
        /// <param name="comparar"></param>
        public void Sort(IComparer<T> comparar)
        {
            myList.Sort(comparar);
        }

        /// <summary>
        /// Sorts the deck using the specified comparison.
        /// </summary>
        /// <param name="comparison"></param>
        public void Sort(System.Comparison<T> comparison)
        {
            myList.Sort(comparison);
        }

        /// <summary>
        /// Resets the deck (clears it in this case).
        /// </summary>
        public virtual void ResetDeck()
        {
            //We cant reset a deck without knowing the kind
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Draws the topmost card from the deck, and removes the drawn card from the deck.
        /// </summary>
        /// <returns>The drawn (topmost) card.</returns>
        public T DrawCard()
        {
            T card = this[0];
            this.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Shuffles the deck using a Simple Shuffle (we don't know the importance of the deck, so we go for the simpler shuffle)
        /// </summary>
        public virtual void Shuffle()
        {
            myList.SimpleShuffle<T>();
        }

        /// <summary>
        /// Gets a string representation of the Deck.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            string toString = this.GetType().ToString() + "{ ";
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == null)
                {
                    toString += "NULL";
                }
                else
                {
                    toString += this[i].ToString();
                }

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