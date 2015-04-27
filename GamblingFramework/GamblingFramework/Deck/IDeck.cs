using System.Collections.Generic;

namespace GamblingFramework
{
    /// <summary>
    /// Creates a Deck which accepts any type of Card.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDeck : IList<ICard>
    {
    }
}
namespace GamblingFramework.Generic
{
    /// <summary>
    /// Creates a Deck which accepts any type of Card.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDeck<T> : IList<T> where T : ICard
    {
        /// <summary>
        /// Reconstruct the deck with new cards.
        /// </summary>
        void ResetDeck();

        /// <summary>
        /// Draw a card, and remove the drawn card from the deck.
        /// </summary>
        /// <returns>The drawn card.</returns>
        T DrawCard();

        /// <summary>
        /// Sort the Deck by a default comparison (for whatever reason, it's still a good idea)
        /// </summary>
        void Sort();

        /// <summary>
        /// Sort the Deck using the suplied comparar (for whatever reason, it's still a good idea)
        /// </summary>
        /// <param name="comparar"></param>
        void Sort(IComparer<T> comparar);

        /// <summary>
        /// Sort the Deck using the supplied comparison (for whatever reason, it's still a good idea)
        /// </summary>
        /// <param name="comparison"></param>
        void Sort(System.Comparison<T> comparison);

        /// <summary>
        /// Shuffle the Deck
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Display the Deck as a string.
        /// </summary>
        /// <returns>The Deck as a string.</returns>
        string ToString();
    }
}
