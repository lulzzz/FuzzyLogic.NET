// -------------------------------------------------------------------------------------------------
// <copyright file="TriangularFunction.cs" author="Christopher Sellers">
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
    /// The immutable <see cref="TriangularFunction" /> class.
    /// </summary>
    [Immutable]
    public class TriangularFunction : PiecewiseLinearFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TriangularFunction"/> class.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        private TriangularFunction(FuzzyPoint[] points)
            : base(points)
        {
            Validate.NotNull(points, nameof(points));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangularFunction"/> class.
        /// </summary>
        /// <param name="x1">
        /// The X coordinate where the membership value starts to rise.
        /// </param>
        /// <param name="x2">
        /// The X coordinate where the membership value reaches maximum (point of triangle).
        /// </param>
        /// <param name="x3">
        /// The X coordinate where the membership value returns to the minimum.
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
        /// The <see cref="TriangularFunction"/>.
        /// </returns>
        public static TriangularFunction Create(
            double x1,
            double x2,
            double x3,
            double minY = 0,
            double maxY = 1)
        {
            Validate.NotOutOfRange(x1, nameof(x1));
            Validate.NotOutOfRange(x2, nameof(x2));
            Validate.NotOutOfRange(x3, nameof(x3));
            Validate.NotOutOfRange(minY, nameof(x1), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(x1), 0, 1);
            Validate.MinMax(minY, maxY);

            var fuzzyPoints = new[]
                                  {
                                      new FuzzyPoint(x1, minY),
                                      new FuzzyPoint(x2, maxY),
                                      new FuzzyPoint(x3, minY),
                                  };

            return new TriangularFunction(fuzzyPoints);
        }
    }
}