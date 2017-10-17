// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyPoint.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Fuzzification
{
    using System;

    using FuzzyLogic.Annotations;
    using FuzzyLogic.Mathematics;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="FuzzyPoint"/> class.
    /// </summary>
    [Immutable]
    [Serializable]
    public struct FuzzyPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyPoint"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x co-ordinate.
        /// </param>
        /// <param name="y">
        /// The y co-ordinate.
        /// </param>
        public FuzzyPoint(double x, double y)
        {
            Validate.NotOutOfRange(x, nameof(x), 0);
            Validate.NotOutOfRange(y, nameof(y), 0, 1);

            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public double Y { get; }

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
        /// The ==.
        /// </summary>
        /// <param name="point1">
        /// The point 1.
        /// </param>
        /// <param name="point2">
        /// The point 2.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator ==(FuzzyPoint point1, FuzzyPoint point2)
        {
            return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="point1">
        /// The point 1.
        /// </param>
        /// <param name="point2">
        /// The point 2.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator !=(FuzzyPoint point1, FuzzyPoint point2)
        {
            return !point1.X.Equals(point2.X) || !point1.Y.Equals(point2.Y);
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

        /// <summary>
        /// The multiply.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public FuzzyPoint Multiply(double factor)
        {
            Validate.NotOutOfRange(factor, nameof(factor));

            return new FuzzyPoint(this.X * factor, this.Y * factor);
        }

        /// <summary>
        /// The divide.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public FuzzyPoint Divide(double factor)
        {
            Validate.NotOutOfRange(factor, nameof(factor));

            return new FuzzyPoint(this.X / factor, this.Y / factor);
        }

        /// <summary>
        /// The distance to another point.
        /// </summary>
        /// <param name="other">
        /// The other point.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double DistanceTo(FuzzyPoint other)
        {
            Validate.NotNull(other, nameof(other));

            var dx = this.X - other.X;
            var dy = this.Y - other.Y;

            var distance = Math.Sqrt(dx.Square() + dy.Square());

            return distance;
        }

        /// <summary>
        /// Returns the angular coefficient of the two points.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="FuzzyPoint"/>.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double AngularCoefficient(FuzzyPoint other)
        {
            return (this.Y - other.Y) / Math.Abs(this.X - other.X);
        }

        /// <summary>
        /// Returns the squared distance to another point.
        /// </summary>
        /// <param name="other">
        /// The other point.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double SquaredDistanceTo(FuzzyPoint other)
        {
            Validate.NotNull(other, nameof(other));

            var dx = this.X - other.X;
            var dy = this.Y - other.Y;

            var distance = dx.Square() + dy.Square();


            return distance;
        }

        /// <summary>
        /// The euclidean norm.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double EuclideanNorm()
        {
            return Math.Sqrt(this.X + this.Y);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is FuzzyPoint point) && (this == point);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode() + 9;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, $"{nameof(FuzzyPoint)}: {this.X}, {this.Y}");
        }
    }
}