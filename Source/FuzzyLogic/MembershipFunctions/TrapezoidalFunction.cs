// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrapezoidalFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    /// <summary>
    /// The trapezoidal function.
    /// </summary>
    public class TrapezoidalFunction : PiecewiseLinearFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="x1">
        /// The m 1.
        /// </param>
        /// <param name="x2">
        /// The m 2.
        /// </param>
        /// <param name="x3">
        /// The m 3.
        /// </param>
        /// <param name="x4">
        /// The m 4.
        /// </param>
        /// <param name="minY">
        /// The min.
        /// </param>
        /// <param name="maxY">
        /// The max.
        /// </param>
        public TrapezoidalFunction(
            double x1,
            double x2,
            double x3,
            double x4,
            double minY = 0,
            double maxY = 1)
            : base(new[]
                       {
                           new FuzzyPoint(x1, minY),
                           new FuzzyPoint(x2, maxY),
                           new FuzzyPoint(x3, maxY),
                           new FuzzyPoint(x4, minY)
                       })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        private TrapezoidalFunction(FuzzyPoint[] points)
            : base(points)
        {
        }

        /// <summary>
        /// The edge type.
        /// </summary>
        public enum EdgeType
        {
            /// <summary>
            /// The fuzzy side of the trapezoid is at the left side.
            /// </summary>
            Left,

            /// <summary>
            /// The fuzzy side of the trapezoid is at the right side.
            /// </summary>
            Right
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="x1">
        /// The m 1.
        /// </param>
        /// <param name="x2">
        /// The m 2.
        /// </param>
        /// <param name="x3">
        /// The x 3.
        /// </param>
        /// <param name="edge">
        /// The edge.
        /// </param>
        /// <param name="minY">
        /// The min Y.
        /// </param>
        /// <param name="maxY">
        /// The max Y.
        /// </param>
        /// <returns>
        /// The <see cref="TrapezoidalFunction"/>.
        /// </returns>
        public static TrapezoidalFunction Create(
            double x1,
            double x2,
            double x3,
            EdgeType edge,
            double minY = 0,
            double maxY = 1)
        {
            if (edge == EdgeType.Left)
            {
                var points = new FuzzyPoint[]
                                 {
                                     new FuzzyPoint(x1, minY),
                                     new FuzzyPoint(x2, maxY),
                                     new FuzzyPoint(x3, maxY)
                                 };
                return new TrapezoidalFunction(points);
            }
            else
            {
                var points = new FuzzyPoint[]
                                 {
                                     new FuzzyPoint(x1, maxY),
                                     new FuzzyPoint(x2, maxY),
                                     new FuzzyPoint(x3, minY)
                                 };
                return new TrapezoidalFunction(points);
            }
        }
    }
}