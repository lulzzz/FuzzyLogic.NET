// -------------------------------------------------------------------------------------------------
// <copyright file="Point.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Mathematics
{
    using System;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="Point"/> immutable class.
    /// </summary>
    [Serializable]
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">
        /// The x co-ordinate.
        /// </param>
        /// <param name="y">
        /// The y co-ordinate.
        /// </param>
        public Point(double x, double y)
        {
            Validate.NotOutOfRange(x, nameof(x));
            Validate.NotOutOfRange(y, nameof(y));

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
        /// The <see cref="Point"/>
        /// </returns>
        public static Point operator +(Point point1, Point point2)
        {
            Validate.NotNull(point1, nameof(point1));
            Validate.NotNull(point2, nameof(point2));

            return new Point(point1.X + point2.X, point1.Y + point2.Y);
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
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point operator -(Point point1, Point point2)
        {
            Validate.NotNull(point1, nameof(point1));
            Validate.NotNull(point2, nameof(point2));

            return new Point(point1.X - point2.X, point1.Y - point2.Y);
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
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point operator *(Point point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotInvalidNumber(factor, nameof(factor));

            return new Point(point.X * factor, point.Y * factor);
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
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point operator /(Point point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotOutOfRange(factor, nameof(factor), 0, double.MaxValue, RangeEndPoints.LowerExclusive);

            return new Point(point.X / factor, point.Y / factor);
        }

        /// <summary>
        /// Returns the sum of two points.
        /// </summary>
        /// <param name="other">
        /// The other point to add.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public Point Add(Point other)
        {
            Validate.NotNull(other, nameof(other));

            return new Point(this.X + other.X, this.Y + other.Y);
        }

        /// <summary>
        /// The subtract.
        /// </summary>
        /// <param name="other">
        /// The other point to subtract.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public Point Subtract(Point other)
        {
            Validate.NotNull(other, nameof(other));

            return new Point(this.X - other.X, this.Y - other.Y);
        }

        /// <summary>
        /// The multiply.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public Point Multiply(double factor)
        {
            Validate.NotOutOfRange(factor, nameof(factor));

            return new Point(this.X * factor, this.Y * factor);
        }

        /// <summary>
        /// The divide.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public Point Divide(double factor)
        {
            Validate.NotOutOfRange(factor, nameof(factor));

            return new Point(this.X / factor, this.Y / factor);
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
        public double DistanceTo(Point other)
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
        /// The other <see cref="Point"/>.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double AngularCoefficient(Point other)
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
        public double SquaredDistanceTo(Point other)
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
            return Math.Sqrt(this.X.Square() + this.Y.Square());
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
        public static bool operator ==(Point point1, Point point2)
        {

            return point1.X == point2.X && point1.Y == point2.Y;
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
        public static bool operator !=(Point point1, Point point2)
        {

            return (point1.X != point2.X) || (point1.Y != point2.Y);
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
            return (obj is Point point) && (this == point);
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
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, $"{nameof(Point)}: {this.X}, {this.Y}");
        }
    }
}