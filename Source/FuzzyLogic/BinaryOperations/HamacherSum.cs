// -------------------------------------------------------------------------------------------------
// <copyright file="HamacherSum.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    using FuzzyLogic.Annotations;

    /// <summary>
    /// The sealed <see cref="HamacherSum"/> class.
    /// </summary>
    public sealed class HamacherSum : ITriangularConorm
    {
        /// <summary>
        /// Returns the <see cref="HamacherSum"/> t-conorm of the given membership values.
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
        [Pure]
        public UnitInterval Evaluate(UnitInterval membershipA, UnitInterval membershipB)
        {
            return 1 - (membershipA * membershipB) > 0
                ? UnitInterval.Create(
                ((membershipA + membershipB) - (2 * (membershipA * membershipB)))
          / (1 - (membershipA * membershipB)))
                : UnitInterval.One();
        }
    }
}