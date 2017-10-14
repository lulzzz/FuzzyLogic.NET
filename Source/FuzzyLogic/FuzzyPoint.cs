// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyPoint.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;

    using FuzzyLogic.Mathematics;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="FuzzyPoint"/> immutable class.
    /// </summary>
    [Serializable]
    public class FuzzyPoint : Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyPoint"/> class.
        /// </summary>
        /// <param name="x">
        /// The x co-ordinate.
        /// </param>
        /// <param name="y">
        /// The y co-ordinate.
        /// </param>
        public FuzzyPoint(double x, double y) : base(x, y)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);
            Validate.NotOutOfRange(y, nameof(y), 0, 1);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="point1">
        /// The point 1.
        /// </param>
        /// <param name="point2">
        /// The point 2.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>
        /// </returns>
        public static FuzzyPoint operator +(FuzzyPoint point1, FuzzyPoint point2)
        {
            Validate.NotNull(point1, nameof(point1));
            Validate.NotNull(point2, nameof(point2));

            return new FuzzyPoint(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="point1">
        /// The point 1.
        /// </param>
        /// <param name="point2">
        /// The point 2.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator -(FuzzyPoint point1, FuzzyPoint point2)
        {
            Validate.NotNull(point1, nameof(point1));
            Validate.NotNull(point2, nameof(point2));

            return new FuzzyPoint(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// The product of two points.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator *(FuzzyPoint point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotInvalidNumber(factor, nameof(factor));

            return new FuzzyPoint(point.X * factor, point.Y * factor);
        }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator /(FuzzyPoint point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotOutOfRange(factor, nameof(factor), 0, double.MaxValue, RangeEndPoints.LowerExclusive);

            return new FuzzyPoint(point.X / factor, point.Y / factor);
        }

        /// <summary>
        /// Returns the sum of two points.
        /// </summary>
        /// <param name="other">
        /// The other point to add.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public FuzzyPoint Add(FuzzyPoint other)
        {
            Validate.NotNull(other, nameof(other));

            return new FuzzyPoint(this.X + other.X, this.Y + other.Y);
        }

        /// <summary>
        /// The subtract.
        /// </summary>
        /// <param name="other">
        /// The other point to subtract.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public FuzzyPoint Subtract(FuzzyPoint other)
        {
            Validate.NotNull(other, nameof(other));

            return new FuzzyPoint(this.X - other.X, this.Y - other.Y);
        }
    }
}