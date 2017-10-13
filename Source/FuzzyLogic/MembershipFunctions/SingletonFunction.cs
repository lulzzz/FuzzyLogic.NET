// -------------------------------------------------------------------------------------------------
// <copyright file="SingletonFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

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
        /// <param name="support">
        /// The support.
        /// </param>
        public SingletonFunction(double support)
        {
            this.Points = new[] { new FuzzyPoint(support, 1) };
        }

        /// <summary>
        /// The minimum y value.
        /// </summary>
        public MembershipValue MinY => MembershipValue.Zero();

        /// <summary>
        /// The maximum y value.
        /// </summary>
        public MembershipValue MaxY => MembershipValue.Create(1);

        /// <summary>
        /// The lower bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public NonNegativeDouble LowerBound => this.Points[0].X;

        /// <summary>
        /// The upper bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public NonNegativeDouble UpperBound => this.Points[0].X;

        /// <summary>
        /// Gets the points array.
        /// </summary>
        public FuzzyPoint[] Points { get; }

        /// <summary>
        /// Returns the <see cref="MembershipValue"/> of a given input to the <see cref="SingletonFunction"/>.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue GetMembership(NonNegativeDouble x)
        {
            return MembershipValue.Create(this.Points[0].X == x ? 1 : 0);
        }
    }
}