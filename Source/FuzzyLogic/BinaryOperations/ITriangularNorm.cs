// -------------------------------------------------------------------------------------------------
// <copyright file="ITriangularNorm.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    /// <summary>
    /// The <see cref="ITriangularNorm"/> interface. Represents a type of t-conorm.
    /// </summary>
    public interface ITriangularNorm
    {
        /// <summary>
        /// Returns the binary operation of the given membership values.
        /// </summary>
        /// <param name="membershipA">
        /// The membership value A [0, 1].
        /// </param>
        /// <param name="membershipB">
        /// The membership value B [0, 1].
        /// </param>
        /// <returns>
        /// A <see cref="UnitInterval"/> [0, 1].
        /// </returns>
        UnitInterval Evaluate(UnitInterval membershipA, UnitInterval membershipB);
    }
}