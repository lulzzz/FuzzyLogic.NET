// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PiecewiseLinearFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    using System;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The piecewise linear function.
    /// </summary>
    public class PiecewiseLinearFunction : IMembershipFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PiecewiseLinearFunction"/> class.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        public PiecewiseLinearFunction(FuzzyPoint[] points)
        {
            Validate.NotNull(points, nameof(points));
            ValidatePointsSequence(points);

            this.Points = points;
        }

        /// <summary>
        /// Returns the lower bound of the <see cref="IMembershipFunction"/>.
        /// </summary>
        public NonNegativeDouble LowerBound => this.Points[0].X;

        /// <summary>
        /// Returns the upper bound of the <see cref="IMembershipFunction"/>.
        /// </summary>
        public NonNegativeDouble UpperBound => this.Points[this.Points.Length - 1].X;

        /// <summary>
        /// Gets the points.
        /// </summary>
        protected FuzzyPoint[] Points { get; }

        /// <summary>
        /// The get membership.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue GetMembership(NonNegativeDouble x)
        {
            if (this.Points.Length == 0)
            {
                return MembershipValue.Zero();
            }

            // if X value is less than the first point, so first point's Y will be returned as membership
            if (x < this.Points[0].X.Value)
            {
                return this.Points[0].Y;
            }

            // looking for the line that contais the X value
            for (int i = 1, n = this.Points.Length; i < n; i++)
            {
                // the line with X value starts in points[i-1].X and ends at points[i].X
                if (x < this.Points[i].X)
                {
                    // points to calculate line's equation
                    var y1 = this.Points[i].Y;
                    var y0 = this.Points[i - 1].Y;
                    var x1 = this.Points[i].X;
                    var x0 = this.Points[i - 1].X;

                    // angular coefficient
                    var m = (y1 - y0) / (x1 - x0);

                    // returning the membership - the Y value for this X
                    return MembershipValue.Create(m * (x - x0) + y0);
                }
            }

            // X value is more than last point, so last point Y will be returned as membership
            return this.Points[this.Points.Length - 1].Y;
        }

        private static void ValidatePointsSequence(FuzzyPoint[] points)
        {
            for (int i = 0, n = points.Length; i < n; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (points[i - 1].X > points[i].X)
                {
                    throw new ArgumentException("Points must be in ascending order on X axis.");
                }
            }
        }
    }
}