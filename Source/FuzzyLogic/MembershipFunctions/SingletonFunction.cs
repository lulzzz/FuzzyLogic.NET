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
    /// <summary>
    /// The singleton function.
    /// </summary>
    public class SingletonFunction : IMembershipFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonFunction"/> class.
        /// </summary>
        /// <param name="support">Support is the only value of x where the membership function is 1.</param>
        public SingletonFunction(double support)
        {
            this.Points = new FuzzyPoint[] { new FuzzyPoint(support, 1) };
        }

        /// <summary>
        /// The lower bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public NonNegativeDouble LowerBound => this.Points[0].X;

        /// <summary>
        /// The upper bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public NonNegativeDouble UpperBound => this.Points[0].X;

        /// <summary>
        /// Gets the points.
        /// </summary>
        public FuzzyPoint[] Points { get; }

        /// <summary>
        /// Returns the <see cref="MembershipValue"/> of a given value to the <see cref="SingletonFunction"/>.
        /// </summary>
        /// <param name="x">Value which membership will to be calculated.</param>
        /// <returns>Degree of membership {0,1} since singletons do not admit memberships different from 0 and 1. </returns>
        public MembershipValue GetMembership(NonNegativeDouble x)
        {
            return MembershipValue.Create(this.Points[0].X == x ? 1 : 0);
        }
    }
}