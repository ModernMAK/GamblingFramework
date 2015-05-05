using System;

namespace GamblingFramework
{
    [Serializable]
    public class GambleCard : BaseCard, IStandardCard
    {
        /**
        Seperating Data from Display, if we dont have a valid card, our renderer will notify us, so no clamping.
        
        /// <summary>
        /// The Minimum for a GambleCard is 0 (The Ace of Spades)
        /// </summary>
        public const int
            CARD_IDENTITY_MIN = 0;

        /// <summary>
        /// The Maximum for a GambleCard deck without Jokers is 51 (The King of Diamonds)
        /// </summary>
        public const int
            CARD_IDENTITY_MAX = 51;

        /// <summary>
        /// The Maximum for a GambleCard deck with Jokers is 53 (The Red Joker)
        /// </summary>
        public const int
            CARD_INDEX_STANDARD_MAX = 53;
        **/
        
        /// <summary>
        /// Creates a GambleCard with an Identity of 0 (representing the Ace of Spades)
        /// </summary>
        public GambleCard()
            : this(0)
        {
        }

        /// <summary>
        /// Creates a GambleCard with a given Identity, if no identity is given, it will default to an Identity of 0 (representing the Ace of Spades)
        /// </summary>
        public GambleCard(int identity)
            : base(identity)
        {
        }

       
        /// <summary>
        /// Gets or Sets the GambleCard
        /// </summary>
        public override int Identity
        {
            get
            {
                return base.Identity;
            }
            set
            {
                base.Identity = value;
                this.Suit = CalculateStandardCardSuit(this.Identity);
                this.Face = CalculateStandardCardFace(this.Identity);
            }
        }
        
        public static CalculateStandardCardSuit(int cardIdentity){
            int suitIdentity = (cardIdentity / 13) + 1;
            return GambleCardExtended.ToStandardCardSuit(cardIdentity)
        }
        

        private StandardCardSuit
            mySuit;
        /// <summary>
        /// Gets the Suit for this Identity
        /// </summary>
        public StandardCardSuit Suit
        {
            get
            {
                return this.mySuit;
            }
            private set
            {
                this.mySuit = value;
            }
        }
        
        private StandardCardFace
            myFace;

        /// <summary>
        /// Gets the Face for this Identity
        /// </summary>
        public StandardCardFace Face
        {
            get
            {
                return this.myFace;
            }
            private set
            {
                this.myFace = value;
            }
        }

        public static GambleCardSuit

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
        public int CompareTo(IStandardCard other)
        {
            
            if (this.Face == other.Face)
            {
                /**
                This is a gamble card! Suit should be meaningless!
                
                return this.Suit.CompareTo(other.Suit);
                */
                return 0;
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
        /// <param name="other">Other GambleCard</param>
        /// <returns>Whether other is equal to this.</returns>
        public bool Equals(IStandardCard other)
        {
            return this.CompareTo(other) == 0;
        }
    }
}
