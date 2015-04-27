using System;
using System.Collections;
using System.Collections.Generic;

namespace GamblingFramework
{
    public class BasePlayer : IPlayer
    {
        public BasePlayer()
            : this("???")
        {
        }
        public BasePlayer(string name)
        {
            Name = name;
        }
        public BasePlayer(IPlayer player)
            : this(player.Name)
        {

        }

        private string
            myName;

        public virtual string Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }
    }
}
