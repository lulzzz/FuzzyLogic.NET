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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="SingletonFunction"/> immutable class.
    /// </summary>
    [Immutable]
    public class SingletonFunction : IMembershipFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonFunction"/> class.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        private SingletonFunction(FuzzyPoint point)
        {
            Validate.NotNull(point, nameof(point));

            this.Points = new FuzzyPoint[] { point };
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
        /// Initializes a new instance of the <see cref="SingletonFunction"/> class.
        /// </summary>
        /// <param name="x">
        /// The support position on the x axis.
        /// </param>
        /// <returns>
        /// The <see cref="SingletonFunction"/>.
        /// </returns>
        public static SingletonFunction Create(double x)
        {
            Validate.NotOutOfRange(x, nameof(x));

            return new SingletonFunction(new FuzzyPoint(x, 1));
        }

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
            Validate.NotOutOfRange(x, nameof(x));

            return this.Points[0].X.Equals(x) ? 1 : 0;
        }
    }
}