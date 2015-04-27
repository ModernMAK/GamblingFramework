using System;

namespace GamblingFramework
{
    public interface ICard : IComparable<ICard>, IEquatable<ICard>
    {
        /// <summary>
        /// The Index of the Card
        /// </summary>
        int Index
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