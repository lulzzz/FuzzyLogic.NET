// -------------------------------------------------------------------------------------------------
// <copyright file="TrapezoidalFunction.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.MembershipFunctions
{
    using System;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="TrapezoidalFunction"/> class.
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
        /// The X coordinate where the membership value starts to rise.
        /// </param>
        /// <param name="x2">
        /// The X coordinate where the membership value reaches the maximum.
        /// </param>
        /// <param name="x3">
        /// The X coordinate where the membership value starts to fall.
        /// </param>
        /// <param name="x4">
        /// The X coordinate where the membership value reaches the minimum.
        /// </param>
        /// <param name="minY">
        /// The min Y.
        /// </param>
        /// <param name="maxY">
        /// The max Y.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws if arguments are invalid.
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
            Validate.NotOutOfRange(x1, nameof(x1));
            Validate.NotOutOfRange(x2, nameof(x2));
            Validate.NotOutOfRange(x3, nameof(x3));
            Validate.NotOutOfRange(x4, nameof(x4));
            Validate.NotOutOfRange(minY, nameof(minY), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(maxY), 0, 1);
            Validate.MinMax(minY, maxY);

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
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class (with a left edge).
        /// </summary>
        /// <param name="x1">
        /// The X coordinate where the membership value starts to fall.
        /// </param>
        /// <param name="x2">
        /// The X coordinate where the membership value reaches the minimum.
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
        /// <exception cref="ArgumentException">
        /// Throws if arguments are invalid.
        /// </exception>
        public static TrapezoidalFunction CreateWithLeftEdge(
            double x1,
            double x2,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1));
            Validate.NotOutOfRange(x2, nameof(x2));
            Validate.NotOutOfRange(minY, nameof(minY), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(maxY), 0, 1);
            Validate.MinMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, maxY),
                                      new FuzzyPoint(x2, minY)
                                  };

            return new TrapezoidalFunction(fuzzyPoints);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrapezoidalFunction"/> class (with a right edge).
        /// </summary>
        /// <param name="x1">
        /// The X coordinate where the membership value starts to rise.
        /// </param>
        /// <param name="x2">
        /// The X coordinate where the membership value reaches the maximum.
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
        /// <exception cref="ArgumentException">
        /// Throws if arguments are invalid.
        /// </exception>
        public static TrapezoidalFunction CreateWithRightEdge(
            double x1,
            double x2,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1));
            Validate.NotOutOfRange(x2, nameof(x2));
            Validate.NotOutOfRange(minY, nameof(minY), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(maxY), 0, 1);
            Validate.MinMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, minY),
                                      new FuzzyPoint(x2, maxY)
                                  };

            return new TrapezoidalFunction(fuzzyPoints);
        }
    }
}