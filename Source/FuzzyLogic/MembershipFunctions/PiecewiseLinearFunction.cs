// -------------------------------------------------------------------------------------------------
// <copyright file="PiecewiseLinearFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable sealed <see cref="PiecewiseLinearFunction"/> class.
    /// </summary>
    [Immutable]
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
            Validate.FuzzyPointArray(points, nameof(points));

            this.Points = points;
        }

        /// <summary>
        /// Returns the minimum Y value.
        /// </summary>
        public double MinY => this.Points.Select(p => p.Y).Min();

        /// <summary>
        /// Returns the maximum Y value.
        /// </summary>
        public double MaxY => this.Points.Select(p => p.Y).Max();

        /// <summary>
        /// Returns the lower bound of the <see cref="IMembershipFunction"/>.
        /// </summary>
        public double LowerBound => this.Points[0].X;

        /// <summary>
        /// Returns the upper bound of the <see cref="IMembershipFunction"/>.
        /// </summary>
        public double UpperBound => this.Points[this.Points.Length - 1].X;

        /// <summary>
        /// Gets the points.
        /// </summary>
        public FuzzyPoint[] Points { get; }

        /// <summary>
        /// Returns the membership value of a given input to the membership function.
        /// </summary>
        /// <param name="x">
        /// The given input.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public double GetMembership(double x)
        {
            Validate.NotOutOfRange(x, nameof(x));

            if (x < this.Points[0].X)
            {
                return this.Points[0].Y;
            }

            for (int i = 1; i < this.Points.Length; i++)
            {
                if (x < this.Points[i].X)
                {
                    var m = this.Points[i].AngularCoefficient(this.Points[i - 1]);

                    return m * (x - this.Points[i - 1].X) + this.Points[i - 1].Y;
                }
            }

            return this.Points[this.Points.Length - 1].Y;
        }
    }
}