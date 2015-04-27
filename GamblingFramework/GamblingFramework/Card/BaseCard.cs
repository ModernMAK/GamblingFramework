using System;

namespace GamblingFramework
{
    [Serializable]
    public class BaseCard : ICard
    {
        /// <summary>
        /// Creates a card with an Index of 0
        /// </summary>
        public BaseCard()
            : this(0)
        {
        }
        
        /// <summary>
        /// Creates a card with the given index
        /// </summary>
        /// <param name="index"></param>
        public BaseCard(int index)
        {
            this.Index = index;
        }

        /// <summary>
        /// The index of the card, hidden to preven forced-sets
        /// </summary>
        private int
            myIndex;

        /// <summary>
        /// Returns a string representing this Card's Index.
        /// </summary>
        /// <returns>String representation of the card.</returns>
        public override string ToString()
        {
            return string.Format("Card {0}", Index);
        }

        /// <summary>
        /// Gets or Sets the Index, this property is virtual to allow subclasses to modify it's behaviour.
        /// </summary>
        public virtual int Index
        {
            get
            {
                return this.myIndex;
            }
            set
            {
                this.myIndex = value;
            }
        }

        /// <summary>
        /// Compares this card to the "other" card.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>+ if greater than, 0 if equal, - if less than.</returns>
        public int CompareTo(ICard other)
        {
            return this.Index.CompareTo(other.Index);
        }

        /// <summary>
        /// Compares this card to the "other" card for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>True if equal, false otherwise.</returns>
        public bool Equals(ICard other)
        {
            return this.CompareTo(other) == 0;
        }
    }
}
