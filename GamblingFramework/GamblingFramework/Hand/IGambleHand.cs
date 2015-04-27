using GamblingFramework.Generic;

namespace GamblingFramework
{
    public interface IGambleCardHand : IGambleCardHand<IGambleCard> 
    {
    }
}
namespace GamblingFramework.Generic
{
    public interface IGambleCardHand<T> : IHand<T> where T : IGambleCard
    {
    }
}
