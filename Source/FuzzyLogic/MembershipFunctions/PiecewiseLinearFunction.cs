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
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="PiecewiseLinearFunction"/> function immutable class.
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
            Validate.PointsSequence(points, nameof(points));

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
        public FuzzyPoint[] Points { get; }

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
            Validate.NotNull(x, nameof(x));

            if (this.Points.Length == 0)
            {
                return MembershipValue.Zero();
            }

            // if X value is less than the first point, so first point's Y will be returned as membership
            if (x < this.Points[0].X)
            {
                return this.Points[0].Y;
            }

            // looking for the line that contais the X value
            for (int i = 1, n = this.Points.Length; i < n; i++)
            {
                // the line with X value starts in points[i-1].X and ends at points[i].X
                if (x < this.Points[i].X)
                {
                    var m = this.Points[i].AngularCoefficient(this.Points[i - 1]);

                    return MembershipValue.Create(m * (x - this.Points[i - 1].X) + this.Points[i - 1].Y);
                }
            }

            // X value is more than last point, so last point Y will be returned as membership
            return this.Points[this.Points.Length - 1].Y;
        }
    }
}