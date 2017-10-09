// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingletonFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    using FuzzyLogic.Utility;

    /// <summary>
    /// The singleton function.
    /// </summary>
    public class SingletonFunction : IMembershipFunction
    {
        private readonly MembershipValue support;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonFunction"/> class.
        /// </summary>
        /// <param name="support">Support is the only value of x where the membership function is 1.</param>
        public SingletonFunction(MembershipValue support)
        {
            Validate.NotNull(support, nameof(support));

            this.support = support;
        }

        /// <summary>
        /// The leftmost x value of the membership function, the same value of the support.
        /// </summary>
        public NonNegativeDouble LowerBound => NonNegativeDouble.Create(this.support.Value);

        /// <summary>
        /// The rightmost x value of the membership function, the same value of the support.
        /// </summary>
        public NonNegativeDouble UpperBound => NonNegativeDouble.Create(this.support.Value);

        /// <summary>
        /// Calculate membership of a given value to the singleton function.
        /// </summary>
        /// <param name="x">Value which membership will to be calculated.</param>
        /// <returns>Degree of membership {0,1} since singletons do not admit memberships different from 0 and 1. </returns>
        public MembershipValue GetMembership(NonNegativeDouble x)
        {
            return MembershipValue.Create(this.support.Value == x.Value ? 1 : 0);
        }
    }
}