using System;

namespace GamblingFramework
{
    public interface IGambleCard : ICard, IComparable<IGambleCard>, IEquatable<IGambleCard>
    {
        /// <summary>
        /// Gets the Suit of the card
        /// </summary>
        GambleCardSuit Suit
        {
            get;
            //set; << decided to go index based instead.
        }
        /// <summary>
        /// Gets the Face of the card
        /// </summary>
        GambleCardFace Face
        {
            get;
            //set; << decided to go index based instead.
        }
    }
}
