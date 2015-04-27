using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;
namespace GamblingFramework
{
    public class CardPlayer : CardPlayer<ICard>
    {
        public CardPlayer()
            : base()
        {
        }
        public CardPlayer(string name)
            : base(name)
        {
        }
        public CardPlayer(IPlayer player)
            : base(player)
        {
        }
        public CardPlayer(ICardPlayer<ICard> player)
            : base(player)
        {
        }
        public CardPlayer(string name, IHand<ICard> hand)
            : base(name, hand)
        {
        }

    }
}
namespace GamblingFramework.Generic
{
    public class CardPlayer<T> : BasePlayer, ICardPlayer<T> where T : ICard
    {
        public CardPlayer()
            : this("???")
        {
        }
        public CardPlayer(string name)
            : this(name, null)
        {
        }
        public CardPlayer(IPlayer player)
            : this(player.Name)
        {
        }
        public CardPlayer(ICardPlayer<T> player)
            : this(player.Name, player.Hand)
        {
        }
        public CardPlayer(string name, IHand<T> hand)
        {
            this.Name = name;
            this.Hand = hand;
        }

        private IHand<T>
            myHand;
        public IHand<T> Hand
        {
            get
            {
                return myHand;
            }
            set
            {
                myHand = value;
            }
        }
    }
}
