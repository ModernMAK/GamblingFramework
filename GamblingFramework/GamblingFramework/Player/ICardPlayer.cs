using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface ICardPlayer : ICardPlayer<ICard>
    {
    }
}
namespace GamblingFramework.Generic
{
    public interface ICardPlayer<T> : IPlayer where T : ICard
    {
        IHand<T> Hand
        {
            get;
            set;
        }
    }
}