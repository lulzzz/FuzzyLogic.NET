// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMembershipFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    /// <summary>
    /// Interface which specifies set of methods required to be implemented by all membership
    /// functions.
    /// </summary>
    /// <remarks><para>All membership functions must implement this interface, which is used by
    /// <see cref="FuzzySet"/> class to calculate value's membership to a particular fuzzy set.
    /// </para></remarks>
    /// 
    public interface IMembershipFunction
    {
        /// <summary>
        /// Gets the leftmost x value of the membership function.
        /// </summary>
        NonNegativeDouble LowerBound { get; }

        /// <summary>
        /// Gets the rightmost x value of the membership function.
        /// </summary>
        NonNegativeDouble UpperBound { get; }

        /// <summary>
        /// Returns the membership of a given value to the fuzzy set.
        /// </summary>
        /// <param name="x">Value which membership will to be calculated.</param>
        /// <returns>Degree of membership [0..1] of the value to the fuzzy set.</returns>
        MembershipValue GetMembership(NonNegativeDouble x);
    }
}