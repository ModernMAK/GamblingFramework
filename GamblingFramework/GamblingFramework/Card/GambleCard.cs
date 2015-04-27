using System;

namespace GamblingFramework
{
    [Serializable]
    public class GambleCard : BaseCard, IGambleCard
    {
        /// <summary>
        /// The Minimum for a GambleCard is 0 (The Ace of Spades)
        /// </summary>
        public const int
            CARD_INDEX_MIN = 0;

        /// <summary>
        /// The Maximum for a GambleCard deck without Jokers is 51 (The King of Diamonds)
        /// </summary>
        public const int
            CARD_INDEX_GAMBLE_MAX = 51;

        /// <summary>
        /// The Maximum for a GambleCard deck with Jokers is 53 (The Red Joker)
        /// </summary>
        public const int
            CARD_INDEX_STANDARD_MAX = 53;

        /// <summary>
        /// Creates a GambleCard with an Index of 0 (representing the Ace of Spades)
        /// </summary>
        public GambleCard()
            : this(0)
        {
        }

        /// <summary>
        /// Creates a GambleCard with a given Index, if no index is given, it will default to an Index of 0 (representing the Ace of Spades)
        /// </summary>
        public GambleCard(int index = CARD_INDEX_MIN)
            : base(index)
        {
        }

        /// <summary>
        /// Gets or Sets the GambleCard
        /// When set, the Index will be bounded to 0 and 53 (Ace of Spades and the Red Joker)
        /// </summary>
        public override int Index
        {
            get
            {
                return base.Index;
            }
            set
            {
                base.Index =
                    Math.Clamp(
                        value,
                        CARD_INDEX_MIN,
                        CARD_INDEX_STANDARD_MAX
                    );
            }
        }

        /// <summary>
        /// Gets the Suit for this Index
        /// </summary>
        public GambleCardSuit Suit
        {
            get
            {
                return this.CalculateGambleCardSuit();
            }
        }

        /// <summary>
        /// Gets the Face for this Index
        /// </summary>
        public GambleCardFace Face
        {
            get
            {
                return this.CalculateGambleCardValue();
            }
        }

        /// <summary>
        /// Gets a string representation of this card.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            if (this.Face == GambleCardFace.Joker)
            {
                return
                    string.Format("{0} {1}", (this.Suit.IsRed() ? "Red" : "Black"), this.Face.ToString());
            }
            else
            {
                return
                    string.Format("{0} of {1}", this.Face.ToString(), this.Suit.ToString());
            }
        }

        /// <summary>
        /// Compares this to the "other" card.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>+ if greater, 0 if equal, - if less than.</returns>
        public int CompareTo(IGambleCard other)
        {
            if (this.Face == other.Face)
            {
                return this.Suit.CompareTo(other.Suit);
            }
            else
            {
                if (this.Face == GambleCardFace.Ace || other.Face == GambleCardFace.Joker)
                {
                    //CompareTo always manages to confuse me, 
                    //but I do know that I want the opposite value if we get an ace, or they have a joker
                    //so we swap this and other for this comparison
                    return other.Face.CompareTo(this.Face);
                }
                else if (other.Face == GambleCardFace.Ace || this.Face == GambleCardFace.Joker)
                {
                    //CompareTo always manages to confuse me, 
                    //but I do know that I want our value if they get an ace, or we have a joker
                    //So it stays normal, but we isolate it for clarity's sake
                    return this.Face.CompareTo(other.Face);
                }
                else
                {
                    //If neither are aces or of any other-same value, 
                    return this.Face.CompareTo(other.Face);
                }
            }
        }

        /// <summary>
        /// Compares this to the "other" card for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Whether other is equal to this.</returns>
        public bool Equals(IGambleCard other)
        {
            return this.CompareTo(other) == 0;
        }
    }
}
