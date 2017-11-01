﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Lukasiewicz.cs" author="Christopher Sellers">
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
    /// The sealed <see cref="Lukasiewicz"/> class.
    /// </summary>
    public sealed class Lukasiewicz : ITriangularNorm
    {
        /// <summary>
        /// Returns the calculated Lukasiewicz t-norm (bounded difference) of the given membership values.
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
            return UnitInterval.Create(Math.Max((membershipA + membershipB) - 1, 0));
        }
    }
}