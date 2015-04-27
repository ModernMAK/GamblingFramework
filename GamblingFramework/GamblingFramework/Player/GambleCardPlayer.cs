using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;
namespace GamblingFramework
{
    public class GambleCardPlayer : GambleCardPlayer<IGambleCard>, IGambleCardPlayer
    {
        public GambleCardPlayer()
            : base()
        {
        }
        public GambleCardPlayer(string name = "", int chips = 0)
            : base(name, chips)
        {
        }
        public GambleCardPlayer(IPlayer player, int chips = 0)
            : base(player, chips)
        {
        }
        public GambleCardPlayer(IGambleCardPlayer player, int chips = 0)
            : base(player, chips)
        {

        }
        public GambleCardPlayer(ICardPlayer player, int chips = 0)
            : base(player,chips)
        {
        }
        public GambleCardPlayer(string name, IHand hand, int chips = 0)
            : base(name, (IGambleCardHand)hand, chips)
        {
        }
    }
}
namespace GamblingFramework.Generic
{
    public class GambleCardPlayer<T> : CardPlayer<T>, IGambleCardPlayer<T> where T : IGambleCard
    {
        public GambleCardPlayer()
            : this("")
        {
        }
        public GambleCardPlayer(string name = "", int chips = 0)
            : this(name,new BaseHand<T>(),chips)
        {
        }
        public GambleCardPlayer(IPlayer player, int chips = 0)
            : this(player.Name,new BaseHand<T>(),chips)
        {
        }
        public GambleCardPlayer(IGambleCardPlayer<T> player, int chips = 0)
            : this(player.Name,player.Hand,chips)
        {
            
        }
        public GambleCardPlayer(ICardPlayer<T> player, int chips = 0)
            : this(player.Name,player.Hand,chips)
        {
        }
        public GambleCardPlayer(string name, IHand<T> hand, int chips = 0)
            : base(name, hand)
        {
            Chips = chips;
        }
        private int
            myChips;

        public int Chips
        {
            get
            {
                return myChips;
            }
            set
            {
                myChips = value;
            }
        }
    }
}
