// -------------------------------------------------------------------------------------------------
// <copyright file="DrasticSum.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    using System;
    using FuzzyLogic.Annotations;

    /// <summary>
    /// The sealed <see cref="DrasticSum"/> class.
    /// </summary>
    public sealed class DrasticSum : ITriangularConorm
    {
        /// <summary>
        /// Returns the calculated drastic sum t-conorm of the given membership values.
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
            return Math.Min(membershipA.Value, membershipB.Value).Equals(0)
                ? UnitInterval.Create(Math.Max(membershipA.Value, membershipB.Value))
                : UnitInterval.One();
        }
    }
}