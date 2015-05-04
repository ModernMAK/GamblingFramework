using System;

namespace GamblingFramework
{
    public interface IStandardCard : ICard, IComparable<IStandardCard>, IEquatable<IStandardCard>
    {
        /// <summary>
        /// Gets the Suit of the card
        /// </summary>
        StandardCardSuit Suit
        {
            get;
            //set; << decided to go index based instead.
        }
        /// <summary>
        /// Gets the Face of the card
        /// </summary>
        StandardCardFace Face
        {
            get;
            //set; << decided to go index based instead.
        }
    }
}
