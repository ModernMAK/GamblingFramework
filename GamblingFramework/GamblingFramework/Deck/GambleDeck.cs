using GamblingFramework.Generic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GamblingFramework.Generic
{
    [Serializable]
    public class GambleDeck<T> : BaseDeck<T>, IGambleCardDeck<T> where T : IGambleCard
    {
        /// <summary>
        /// Construct a default deck
        /// </summary>
        public GambleDeck()
            : this((IList<T>)null)
        {
        }

        /// <summary>
        /// Construct a default using the supplied cards
        /// </summary>
        public GambleDeck(IList<T> reference)
            : base(reference)
        {
            if (reference == null)
            {
                ResetDeck();
                //If we had a null deck, create a default one
            }
        }

        /// <summary>
        /// Construct a default using the supplied cards
        /// </summary>
        public GambleDeck(params T[] reference)
            : base(reference)
        {
            if (reference == null)
            {
                ResetDeck();
                //If we had a null deck, create a default one
            }
        }

        /// <summary>
        /// Construct a default using the supplied deck
        /// </summary>
        public GambleDeck(IGambleCardDeck<T> reference)
            : base(reference)
        {
            if (reference == null)
            {
                ResetDeck();
                //If we had a null deck, create a default one
            }
        }

        /// <summary>
        /// Sort the Deck.
        /// </summary>
        public override void Sort()
        {
            this.Sort(
                delegate(T x, T y)
                {
                    return x.CompareTo(y);
                }
            );
        }

        /// <summary>
        /// Shuffles the Deck (Uses Cryptology for a safer Shuffle)
        /// </summary>
        public override void Shuffle()
        {
            this.AdvancedShuffle();
        }

        /// <summary>
        /// Resets the Deck to a full-deck state (Excluding Jokers).
        /// </summary>
        public override void ResetDeck()
        {
            this.Clear();
            for (int i = 0; i <= GambleCard.CARD_INDEX_GAMBLE_MAX; i++)
            {
                this.Add(
                    (T)(IGambleCard)(new GambleCard(i))
                );
            }
        }

        /// <summary>
        /// Gets an enumerator to iterate over the Deck.
        /// </summary>
        /// <returns>A deck enumerator.</returns>
        public new IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
namespace GamblingFramework
{
    [Serializable]
    public class GambleDeck : GambleDeck<IGambleCard>, IGambleCardDeck
    {

        /// <summary>
        /// Construct a default deck
        /// </summary>
        public GambleDeck()
            : this((IList<IGambleCard>)null)
        {
        }

        /// <summary>
        /// Construct a default using the supplied cards
        /// </summary>
        public GambleDeck(IList<IGambleCard> reference)
            : base(reference)
        {
        }

        /// <summary>
        /// Construct a default using the supplied cards
        /// </summary>
        public GambleDeck(params IGambleCard[] reference)
            : base(reference)
        {
        }

        /// <summary>
        /// Construct a default using the supplied deck
        /// </summary>
        public GambleDeck(IGambleCardDeck<IGambleCard> reference)
            : base(reference)
        {
        }
    }
}
