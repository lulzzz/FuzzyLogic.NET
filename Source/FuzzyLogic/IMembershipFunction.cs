// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMembershipFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    /// <summary>
    /// All membership functions must implement this interface, which is used by the
    /// <see cref="FuzzySet"/> class to calculate the values membership to a particular fuzzy set.
    /// </summary>
    /// <remarks>
    /// A membership function is a curve that defines how each point in the input space is mapped to a membership value
    /// (or degree of membership) between 0 and 1. The input space is sometimes referred to as the universe of discourse
    /// </remarks>
    public interface IMembershipFunction
    {
        /// <summary>
        /// Gets the leftmost x value of the membership function.
        /// </summary>
        double LeftLimit { get; }

        /// <summary>
        /// Gets the rightmost x value of the membership function.
        /// </summary>
        double RightLimit { get; }

        /// <summary>
        /// Calculate membership of a given value to the fuzzy set.
        /// </summary>
        /// <param name="x">Value which membership will to be calculated.</param>
        /// <returns>Degree of membership [0..1] of the value to the fuzzy set.</returns>
        double GetMembership(double x);
    }
}