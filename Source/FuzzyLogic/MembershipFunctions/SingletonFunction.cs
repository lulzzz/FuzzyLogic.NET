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
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="SingletonFunction"/> immutable class.
    /// </summary>
    public class SingletonFunction : IMembershipFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonFunction"/> class.
        /// </summary>
        /// <param name="x">
        /// The support position on the x axis.
        /// </param>
        public SingletonFunction(double x)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);

            this.Points = new[] { new FuzzyPoint(x, 1) };
        }

        /// <summary>
        /// The minimum y value.
        /// </summary>
        public double MinY => 0;

        /// <summary>
        /// The maximum y value.
        /// </summary>
        public double MaxY => 1;

        /// <summary>
        /// The lower bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public double LowerBound => this.Points[0].X;

        /// <summary>
        /// The upper bound of the <see cref="IMembershipFunction"/>, the same value as the support.
        /// </summary>
        public double UpperBound => this.Points[0].X;

        /// <summary>
        /// Gets the points array.
        /// </summary>
        public FuzzyPoint[] Points { get; }

        /// <summary>
        /// Returns the membership value of a given input to the <see cref="SingletonFunction"/>.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetMembership(double x)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);

            return this.Points[0].X.Equals(x) ? 1 : 0;
        }
    }
}