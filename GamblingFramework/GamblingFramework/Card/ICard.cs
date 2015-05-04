using System;

namespace GamblingFramework
{
    public interface ICard : IComparable<ICard>, IEquatable<ICard>
    {
        /// <summary>
        /// The Identity of the Card
        /// </summary>
        int Identity
        {
            get;
            set;
        }
       
        /// <summary>
        /// A string representation of the Card
        /// </summary>
        /// <returns>String representation.</returns>
        string ToString();
    }
}
