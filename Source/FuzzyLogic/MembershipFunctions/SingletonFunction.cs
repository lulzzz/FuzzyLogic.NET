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
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable sealed <see cref="SingletonFunction"/> class.
    /// </summary>
    [Immutable]
    public sealed class SingletonFunction : IMembershipFunction
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
        /// The minimum Y value.
        /// </summary>
        public UnitInterval MinY => UnitInterval.Zero();

        /// <summary>
        /// The maximum Y value.
        /// </summary>
        public UnitInterval MaxY => UnitInterval.One();

        /// <summary>
        /// The lower bound of the <see cref="IMembershipFunction"/> (the same value as the support).
        /// </summary>
        public double LowerBound => this.Points[0].X;

        /// <summary>
        /// The upper bound of the <see cref="IMembershipFunction"/> (the same value as the support).
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
        /// The support position on the X axis.
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
        /// The input double.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public UnitInterval GetMembership(double x)
        {
            Validate.NotOutOfRange(x, nameof(x));

            return this.Points[0].X.Equals(x) ? this.MaxY : this.MinY;
        }
    }
}