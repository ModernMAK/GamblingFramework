using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface IGambleCardTable : IGambleCardTable<IGambleCardPlayer<IGambleCard>, IGambleCard, IGambleCardDeck<IGambleCard>>
    {
    }
}
namespace GamblingFramework.Generic
{
    public interface IGambleCardTable<T, U, V> : ICardTable<T, U>
        where T : IGambleCardPlayer<U>
        where U : IGambleCard
        where V : IGambleCardDeck<U>
    {
        V Deck
        {
            get;
            set;
        }
    }
}