// -------------------------------------------------------------------------------------------------
// <copyright file="IMembershipFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Fuzzification.MembershipFunctions
{
    using FuzzyLogic.Fuzzification;

    /// <summary>
    /// The <see cref="IMembershipFunction"/> interface.
    /// </summary>
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