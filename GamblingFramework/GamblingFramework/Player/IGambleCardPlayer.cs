using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface IGambleCardPlayer : IGambleCardPlayer<IGambleCard>
    {
    }
}
namespace GamblingFramework.Generic
{
    public interface IGambleCardPlayer<T> : ICardPlayer<T> where T : IGambleCard
    {
        int Chips
        {
            get;
            set;
        }
    }
}
