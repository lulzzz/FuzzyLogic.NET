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

    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="TrapezoidalFunction"/> immutable class.
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
            Validate.NotOutOfRange(x1, nameof(x1), 0);
            Validate.NotOutOfRange(x2, nameof(x2), 0);
            Validate.NotOutOfRange(x3, nameof(x3), 0);
            Validate.NotOutOfRange(x4, nameof(x4), 0);
            Validate.NotOutOfRange(minY, nameof(x1), 0, 1);
            Validate.NotOutOfRange(maxY, nameof(x1), 0, 1);

            if (minY > maxY)
            {
                throw new ArgumentException("Minimum Y cannot be greater than Maximum Y.");
            }
        }
    }
}