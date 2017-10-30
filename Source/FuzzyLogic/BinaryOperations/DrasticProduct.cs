﻿// -------------------------------------------------------------------------------------------------
// <copyright file="DrasticProduct.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.BinaryOperations
{
    using System;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The sealed <see cref="DrasticProduct"/> class.
    /// </summary>
    public sealed class DrasticProduct : ITriangularNorm
    {
        /// <summary>
        /// Returns the calculated drastic product t-norm of the given membership values.
        /// </summary>
        /// <param name="membershipA">
        /// The membership value A [0, 1].
        /// </param>
        /// <param name="membershipB">
        /// The membership value B [0, 1].
        /// </param>
        /// <returns>
        /// A <see cref="double"/> [0, 1].
        /// </returns>
        public double Evaluate(double membershipA, double membershipB)
        {
            Validate.NotOutOfRange(membershipA, nameof(membershipA), 0, 1);
            Validate.NotOutOfRange(membershipB, nameof(membershipB), 0, 1);

            return Math.Max(membershipA, membershipB).Equals(1) ? Math.Min(membershipA, membershipB) : 0;
        }
    }
}