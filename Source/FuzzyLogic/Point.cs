// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;

    using CodeEssence.DesignByContract;

    /// <summary>
    /// The point structure.
    /// </summary>
    [Serializable]
    public struct Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x co-ordinate.
        /// </param>
        /// <param name="y">
        /// The y co-ordinate.
        /// </param>
        public Point(double x, double y)
        {
            Contract.Requires(Condition.DoubleNotInvalidNumber(x, nameof(x)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(y, nameof(x)));

            this.X = x;
            this.Y = y;

            Contract.Ensures(Condition.DoubleNotInvalidNumber(this.X, nameof(this.X)));
            Contract.Ensures(Condition.DoubleNotInvalidNumber(this.Y, nameof(this.Y)));
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
        /// The distance to another point.
        /// </summary>
        /// <param name="otherPoint">
        /// The other point.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double DistanceTo(Point otherPoint)
        {
            Contract.Requires(Condition.NotNull(otherPoint, nameof(otherPoint)));

            var dx = this.X - otherPoint.X;
            var dy = this.Y - otherPoint.Y;

            var distance = Math.Sqrt((dx * dx) + (dy * dy));

            Contract.Ensures(Condition.DoubleNotInvalidNumber(distance, nameof(distance)));

            return distance;
        }

        /// <summary>
        /// Returns the squared distance to another point.
        /// </summary>
        /// <param name="otherPoint">
        /// The other point.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double SquaredDistanceTo(Point otherPoint)
        {
            Contract.Requires(Condition.NotNull(otherPoint, nameof(otherPoint)));

            var dx = this.X - otherPoint.X;
            var dy = this.Y - otherPoint.Y;

            var distance = (dx * dx) + (dy * dy);

            Contract.Ensures(Condition.DoubleNotInvalidNumber(distance, nameof(distance)));

            return distance;
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
        /// The <see cref="Point"/>
        /// </returns>
        public static Point operator +(Point point1, Point point2)
        {
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// Returns the sum of two points.
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
        public static Point Add(Point point1, Point point2)
        {
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }



        /// <summary>
        /// The subtract.
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
        public static Point Subtract(Point point1, Point point2)
        {
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

            return new Point(point1.X - point2.X, point1.Y - point2.Y);
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
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="valueToAdd">
        /// The value to add.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point operator +(Point point, double valueToAdd)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(valueToAdd, nameof(valueToAdd)));

            return new Point(point.X + valueToAdd, point.Y + valueToAdd);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="valueToAdd">
        /// The value to add.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point Add(Point point, double valueToAdd)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(valueToAdd, nameof(valueToAdd)));

            return new Point(point.X + valueToAdd, point.Y + valueToAdd);
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="valueToSubtract">
        /// The value to subtract.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point operator -(Point point, double valueToSubtract)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(valueToSubtract, nameof(valueToSubtract)));

            return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
        }

        /// <summary>
        /// The subtract.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="valueToSubtract">
        /// The value to subtract.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        public static Point Subtract(Point point, double valueToSubtract)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(valueToSubtract, nameof(valueToSubtract)));

            return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
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
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(factor, nameof(factor)));

            return new Point(point.X * factor, point.Y * factor);
        }

        /// <summary>
        /// The multiply.
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
        public static Point Multiply(Point point, double factor)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(factor, nameof(factor)));

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
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(factor, nameof(factor)));

            return new Point(point.X / factor, point.Y / factor);
        }

        /// <summary>
        /// The divide.
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
        public static Point Divide(Point point, double factor)
        {
            Contract.Requires(Condition.NotNull(point, nameof(point)));
            Contract.Requires(Condition.DoubleNotInvalidNumber(factor, nameof(factor)));

            return new Point(point.X / factor, point.Y / factor);
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
        /// The <see cref="Point"/>.
        /// </returns>
        public static bool operator ==(Point point1, Point point2)
        {
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

            return (point1.X == point2.X) && (point1.Y == point2.Y);
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
        /// The <see cref="Point"/>.
        /// </returns>
        public static bool operator !=(Point point1, Point point2)
        {
            Contract.Requires(Condition.NotNull(point1, nameof(point1)));
            Contract.Requires(Condition.NotNull(point2, nameof(point2)));

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
            return (obj is Point) ? (this == (Point)obj) : false;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
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

        /// <summary>
        /// The euclidean norm.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double EuclideanNorm()
        {
            return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }
    }
}