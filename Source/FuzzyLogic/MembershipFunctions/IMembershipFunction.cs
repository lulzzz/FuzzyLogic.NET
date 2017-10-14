// -------------------------------------------------------------------------------------------------
// <copyright file="IMembershipFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    /// <summary>
    /// All membership functions must implement this interface, which is used by the
    /// <see cref="FuzzySet"/> class to calculate the values membership to a particular fuzzy set.
    /// </summary>
    /// <remarks>
    /// A membership function is a curve that defines how each point in the input space is mapped
    /// to a membership value (or degree of membership) between 0 and 1.
    /// The input space is sometimes referred to as the universe of discourse
    /// </remarks>
    public interface IMembershipFunction
    {
        /// <summary>
        /// Gets the min y value.
        /// </summary>
        double MinY { get; }

        /// <summary>
        /// Gets the max y value.
        /// </summary>
        double MaxY { get; }

        /// <summary>
        /// Gets the leftmost x value of the <see cref="IMembershipFunction"/>.
        /// </summary>
        double LowerBound { get; }

        /// <summary>
        /// Gets the rightmost x value of the <see cref="IMembershipFunction"/>.
        /// </summary>
        double UpperBound { get; }

        /// <summary>
        /// Gets the points.
        /// </summary>
        FuzzyPoint[] Points { get; }

        /// <summary>
        /// Returns the value of the membership from the given input.
        /// </summary>
        /// <param name="x">
        /// The input.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        double GetMembership(double x);
    }
}