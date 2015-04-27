using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    [Serializable]
    public class GambleCardHand : GambleCardHand<IGambleCard>, IGambleCardHand
    {
        public GambleCardHand()
            : base()
        {
        }
        public GambleCardHand(params IGambleCard[] cards)
            : base(cards)
        {
        }
        public GambleCardHand(IHand<IGambleCard> hand)
            : base(hand)
        {

        }
        public GambleCardHand(IList<IGambleCard> hand)
            : base(hand)
        {
        }
    }
}

namespace GamblingFramework.Generic
{
    [Serializable]
    public class GambleCardHand<T> : BaseHand<T>, IGambleCardHand<T> where T : IGambleCard
    {
        public GambleCardHand()
            : base()
        {
        }
        public GambleCardHand(params T[] cards)
            : base(cards)
        {
        }
        public GambleCardHand(IHand<T> hand)
            : base(new List<T>(hand))
        {

        }
        public GambleCardHand(IList<T> hand)
            : base(new List<T>(hand))
        {

        }
        public new IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
