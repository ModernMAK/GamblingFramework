using System;

namespace GamblingFramework
{
    [Serializable]
    /// <summary>
    /// Provides basic or example implimentation of ICard. 
    /// This approach assumes each card iis an instance.
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// Creates a card with an identity of 0.
        /// </summary>
        public Card()
            : Card(0)
        {
        }
        
        /// <summary>
        /// Creates a card with the given identity.
        /// </summary>
        /// <param name="identity">The identity of this card.</param>
        public Card(int identity)
        {
            this.Identity = identity;
        }

        /// <summary>
        /// The index of the card, hidden to preven forced-sets
        /// </summary>
        private int
            myIdentity;

        /// <summary>
        /// Returns a string representing this Card's Index.
        /// </summary>
        /// <returns>String representation of the card.</returns>
        public override string ToString()
        {
            return string.Format("Card {0}", Index);
        }

        /// <summary>
        /// Gets or Sets the Identity.
        /// This property is virtual to allow subclasses to modify it's behaviour.
        /// </summary>
        public virtual int Identity
        {
            get
            {
                return this.myIdentity;
            }
            set
            {
                this.myIdentity = value;
            }
        }

        /// <summary>
        /// Compares this card to the "other" card.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>+ if greater than, 0 if equal, - if less than.</returns>
        public int CompareTo(ICard other)
        {
            return this.Identity.CompareTo(other.Index);
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
