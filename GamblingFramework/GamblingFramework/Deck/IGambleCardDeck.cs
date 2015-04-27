using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface IGambleCardDeck : IGambleCardDeck<IGambleCard>
    {
    }
}

namespace GamblingFramework.Generic
{
    public interface IGambleCardDeck<T> : IDeck<T> where T : IGambleCard
    {
    }
}
