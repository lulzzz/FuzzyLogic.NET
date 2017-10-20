// -------------------------------------------------------------------------------------------------
// <copyright file="AlgebraicOperations.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Mathematics
{
    using System;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The algebraic operations.
    /// </summary>
    public static class AlgebraicOperations
    {
        /// <summary>
        /// Returns the square of a double.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double Square(this double input)
        {
            Validate.NotOutOfRange(input, nameof(input));

            return input * input;
        }

        /// <summary>
        /// Returns the square root of a double.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double SquareRoot(this double input)
        {
            Validate.NotOutOfRange(input, nameof(input));

            return Math.Sqrt(input);
        }
    }
}