using System;

namespace bezpieczniejsi
{
    public interface IRiskAssessment
    {
        /// <summary>
        /// For list of row - return row index on the list 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// When positive: return index on list
        /// When negative: not on the list
        /// </returns>
        /// <exception cref="ArgumentException">Throws when argument is invalid</exception>
        /// <exception cref="ArgumentNullException">Throws when argument is null</exception>
        int GetChildID(object obj);
    }
}