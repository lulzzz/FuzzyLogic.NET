// -------------------------------------------------------------------------------------------------
// <copyright file="TrapezoidalFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Fuzzification.MembershipFunctions
{
    using System;

    using FuzzyLogic.Annotations;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="TrapezoidalFunction"/> class.
    /// </summary>
    [Immutable]
    public class TrapezoidalFunction : PiecewiseLinearFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        private TrapezoidalFunction(FuzzyPoint[] points)
            : base(points)
        {
            Validate.NotNull(points, nameof(points));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class.
        /// </summary>
        /// <param name="x1">
        /// The x1.
        /// </param>
        /// <param name="x2">
        /// The x2.
        /// </param>
        /// <param name="x3">
        /// The x3.
        /// </param>
        /// <param name="x4">
        /// The x4.
        /// </param>
        /// <param name="minY">
        /// The min y.
        /// </param>
        /// <param name="maxY">
        /// The max y.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if minimum y is greater than maximum y.
        /// </exception>
        /// <returns>
        /// The <see cref="TrapezoidalFunction"/>.
        /// </returns>
        public static TrapezoidalFunction Create(
            double x1,
            double x2,
            double x3,
            double x4,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1), 0);
            Validate.NotOutOfRange(x2, nameof(x2), 0);
            Validate.NotOutOfRange(x3, nameof(x3), 0);
            Validate.NotOutOfRange(x4, nameof(x4), 0);
            Validate.NotOutOfRange(minY, nameof(x1), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(x1), 0, 1);
            ValidateMinLessThanMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, minY),
                                      new FuzzyPoint(x2, maxY),
                                      new FuzzyPoint(x3, maxY),
                                      new FuzzyPoint(x4, minY)
                                  };

            return new TrapezoidalFunction(fuzzyPoints);
        }

        /// <summary>
        /// The create with left edge.
        /// </summary>
        /// <param name="x1">
        /// The x 1.
        /// </param>
        /// <param name="x2">
        /// The x 2.
        /// </param>
        /// <param name="minY">
        /// The min y.
        /// </param>
        /// <param name="maxY">
        /// The max y.
        /// </param>
        /// <returns>
        /// The <see cref="TrapezoidalFunction"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if minimum y is greater than maximum y.
        /// </exception>
        public static TrapezoidalFunction CreateWithLeftEdge(
            double x1,
            double x2,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1), 0);
            Validate.NotOutOfRange(x2, nameof(x2), 0);
            Validate.NotOutOfRange(minY, nameof(x1), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(x1), 0, 1);
            ValidateMinLessThanMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, minY),
                                      new FuzzyPoint(x2, maxY)
                                  };

            return new TrapezoidalFunction(fuzzyPoints);
        }

        /// <summary>
        /// The create with right edge.
        /// </summary>
        /// <param name="x1">
        /// The x 1.
        /// </param>
        /// <param name="x2">
        /// The x 2.
        /// </param>
        /// <param name="minY">
        /// The min y.
        /// </param>
        /// <param name="maxY">
        /// The max y.
        /// </param>
        /// <returns>
        /// The <see cref="TrapezoidalFunction"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if minimum y is greater than maximum y.
        /// </exception>
        public static TrapezoidalFunction CreateWithRightEdge(
            double x1,
            double x2,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1), 0);
            Validate.NotOutOfRange(x2, nameof(x2), 0);
            Validate.NotOutOfRange(minY, nameof(x1), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(x1), 0, 1);
            ValidateMinLessThanMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, maxY),
                                      new FuzzyPoint(x2, minY)
                                  };

            return new TrapezoidalFunction(fuzzyPoints);
        }

        private static void ValidateMinLessThanMax(double minY, double maxY)
        {
            if (minY > maxY)
            {
                throw new ArgumentException("Minimum Y cannot be greater than Maximum Y.");
            }
        }
    }
}