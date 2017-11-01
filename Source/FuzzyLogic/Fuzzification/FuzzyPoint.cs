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
    /// The immutable <see cref="FuzzyPoint"/> structure.
    /// </summary>
    [Immutable]
    [Serializable]
    public struct FuzzyPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyPoint"/> struct.
        /// </summary>
        /// <param name="x">
        /// The X co-ordinate.
        /// </param>
        /// <param name="y">
        /// The Y co-ordinate.
        /// </param>
        public FuzzyPoint(double x, double y)
        {
            Validate.NotOutOfRange(x, nameof(x));
            Validate.NotOutOfRange(y, nameof(y), 0, 1);

            this.X = x;
            this.Y = UnitInterval.Create(y);
        }

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public UnitInterval Y { get; }

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left point.
        /// </param>
        /// <param name="right">
        /// The right point.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator +(FuzzyPoint left, FuzzyPoint right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return new FuzzyPoint(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left point.
        /// </param>
        /// <param name="right">
        /// The right point.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator -(FuzzyPoint left, FuzzyPoint right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return new FuzzyPoint(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// The multiply operator.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator *(FuzzyPoint point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotOutOfRange(factor, nameof(factor));

            return new FuzzyPoint(point.X * factor, point.Y.Value * factor);
        }

        /// <summary>
        /// The divide operator.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyPoint"/>.
        /// </returns>
        public static FuzzyPoint operator /(FuzzyPoint point, double factor)
        {
            Validate.NotNull(point, nameof(point));
            Validate.NotOutOfRange(factor, nameof(factor), 0, double.MaxValue, RangeEndPoints.LowerExclusive);

            return new FuzzyPoint(point.X / factor, point.Y.Value / factor);
        }

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="left">
        /// The left point.
        /// </param>
        /// <param name="point2">
        /// The right point.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator ==(FuzzyPoint left, FuzzyPoint point2)
        {
            return left.X.Equals(point2.X) && left.Y.Equals(point2.Y);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="left">
        /// The left point.
        /// </param>
        /// <param name="point2">
        /// The right point.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator !=(FuzzyPoint left, FuzzyPoint point2)
        {
            return !left.X.Equals(point2.X) || !left.Y.Equals(point2.Y);
        }

        /// <summary>
        /// Adds the given <see cref="FuzzyPoint"/> to this <see cref="FuzzyPoint"/>.
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
        /// Subtracts the given <see cref="FuzzyPoint"/> from this <see cref="FuzzyPoint"/>.
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
        /// Multiplies the <see cref="FuzzyPoint"/> by the given factor.
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

            return new FuzzyPoint(this.X * factor, this.Y.Value * factor);
        }

        /// <summary>
        /// Divides the <see cref="FuzzyPoint"/> by the given divisor.
        /// </summary>
        /// <param name="divisor">
        /// The divisor.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyPoint"/>.
        /// </returns>
        public FuzzyPoint Divide(double divisor)
        {
            Validate.NotOutOfRange(divisor, nameof(divisor));

            return new FuzzyPoint(this.X / divisor, this.Y.Value / divisor);
        }

        /// <summary>
        /// Returns the distance to another point.
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
        /// Returns the euclidean norm of the <see cref="FuzzyPoint"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double EuclideanNorm()
        {
            return Math.Sqrt(this.X + this.Y);
        }

        /// <summary>
        /// The equals override.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is FuzzyPoint point) && (this == point);
        }

        /// <summary>
        /// Returns the hash code of this <see cref="FuzzyPoint"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.X.GetHashCode() + this.Y.GetHashCode()) + 9;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="FuzzyPoint"/>.
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