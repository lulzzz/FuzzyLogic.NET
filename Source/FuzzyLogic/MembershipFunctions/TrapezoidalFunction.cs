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
        /// <param name="m1">
        /// The m 1.
        /// </param>
        /// <param name="m2">
        /// The m 2.
        /// </param>
        /// <param name="m3">
        /// The m 3.
        /// </param>
        /// <param name="m4">
        /// The m 4.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        /// <param name="min">
        /// The min.
        /// </param>
        public TrapezoidalFunction(double m1, double m2, double m3, double m4, double max = 1, double min = 0)
            : base(new[]
                       {
                           new FuzzyPoint(m1, min),
                           new FuzzyPoint(m2, max),
                           new FuzzyPoint(m3, max),
                           new FuzzyPoint(m4, min)
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
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="m1">
        /// The m 1.
        /// </param>
        /// <param name="m2">
        /// The m 2.
        /// </param>
        /// <param name="edge">
        /// The edge.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        /// <param name="min">
        /// The min.
        /// </param>
        public static TrapezoidalFunction Create(double m1, double m2, EdgeType edge, double max = 1, double min = 0)
        {
            if (edge == EdgeType.Left)
            {
                var points = new FuzzyPoint[]
                                 {
                                     new FuzzyPoint(m1, min),
                                     new FuzzyPoint(m2, max),
                                 };
                return new TrapezoidalFunction(points);
            }
            else
            {
                var points = new FuzzyPoint[]
                                 {
                                     new FuzzyPoint(m1, max),
                                     new FuzzyPoint(m2, min),
                                 };
                return new TrapezoidalFunction(points);
            }
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
    }
}