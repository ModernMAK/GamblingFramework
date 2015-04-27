using System;
using System.Collections;
using System.Collections.Generic;
using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface ICardTable : ICardTable<ICardPlayer<ICard>, ICard>
    {
    }
}
namespace GamblingFramework.Generic
{
    public interface ICardTable<T, U> : ITable<T>
        where T : ICardPlayer<U>
        where U : ICard
    {
    }
}
