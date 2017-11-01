// -------------------------------------------------------------------------------------------------
// <copyright file="UnitInterval.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;
    using System.Globalization;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="UnitInterval"/> structure.
    /// Represents a bounded double within the range [0, 1].
    /// </summary>
    /// <remarks>
    ///     In mathematics, the unit interval is the closed interval [0,1], that is,
    ///     the set of all real numbers that are greater than or equal to 0
    ///     and less than or equal to 1.
    /// </remarks>
    [Immutable]
    public struct UnitInterval : IComparable<UnitInterval>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitInterval"/> struct.
        /// </summary>
        /// <param name="value">
        /// The input value.
        /// </param>
        private UnitInterval(double value)
        {
            Validate.NotOutOfRange(value, nameof(value), 0, 1);

            this.Value = value;
        }

        /// <summary>
        /// Gets the value of the <see cref="UnitInterval"/> [0, 1].
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Returns a new <see cref="UnitInterval"/> from the given value.
        /// </summary>
        /// <param name="value">
        /// The input value.
        /// </param>
        /// <returns>
        /// A <see cref="UnitInterval"/>.
        /// </returns>
        public static UnitInterval Create(double value) => new UnitInterval(value);

        /// <summary>
        /// Returns a new <see cref="UnitInterval"/> with a value of zero (0).
        /// </summary>
        /// <returns>
        /// A <see cref="UnitInterval"/>.
        /// </returns>
        public static UnitInterval Zero() => new UnitInterval(0);

        /// <summary>
        /// Returns a new <see cref="UnitInterval"/> with a value of one (1).
        /// </summary>
        /// <returns>
        /// A <see cref="UnitInterval"/>.
        /// </returns>
        public static UnitInterval One() => new UnitInterval(1);

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator +(UnitInterval left, UnitInterval right) => left.Value + right.Value;

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator +(double left, UnitInterval right) => left + right.Value;

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator +(UnitInterval left, double right) => left.Value + right;

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator -(UnitInterval left, UnitInterval right) => left.Value - right.Value;

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator -(double left, UnitInterval right) => left - right.Value;

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator -(UnitInterval left, double right) => left.Value - right;

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator *(UnitInterval left, UnitInterval right) => left.Value * right.Value;

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator *(double left, UnitInterval right) => left * right.Value;

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator *(UnitInterval left, double right) => left.Value * right;

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator /(UnitInterval left, UnitInterval right) => left.Value / right.Value;

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator /(double left, UnitInterval right) => left / right.Value;

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static double operator /(UnitInterval left, double right) => left.Value / right;

        /// <summary>
        /// The &gt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator >(UnitInterval left, UnitInterval right) => left.Value > right.Value;

        /// <summary>
        /// The &gt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator >(double left, UnitInterval right) => left > right.Value;

        /// <summary>
        /// The &gt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator >(UnitInterval left, double right) => left.Value > right;

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator <(UnitInterval left, UnitInterval right) => left.Value < right.Value;

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator <(double left, UnitInterval right) => left < right.Value;

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator <(UnitInterval left, double right) => left.Value < right;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator ==(UnitInterval left, UnitInterval right) => left.Equals(right);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator !=(UnitInterval left, UnitInterval right) => !(left == right);

        /// <summary>
        /// The &gt;= operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator >=(UnitInterval left, UnitInterval right) => left.Value >= right.Value;

        /// <summary>
        /// The &lt;= operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="UnitInterval"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        public static bool operator <=(UnitInterval left, UnitInterval right) => left.Value <= right.Value;

        /// <summary>
        /// Returns a value of -1, 0 or 1 based on the comparison of the <see cref="UnitInterval"/>(s).
        /// </summary>
        /// <param name="other">
        /// The other <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// An <see cref="int"/>.
        /// </returns>
        public int CompareTo(UnitInterval other) => this.Value.CompareTo(other.Value);

        /// <summary>
        /// Returns a value indicating whether this instance and the given <see cref="object"/>
        /// represent the same value.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other) => other is UnitInterval && this.Equals((UnitInterval)other);

        /// <summary>
        /// Returns a value indicating whether this instance and the given <see cref="UnitInterval"/>
        /// represent the same value.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="UnitInterval"/>.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public bool Equals(UnitInterval other) => this.Value.Equals(other.Value);

        /// <summary>
        /// Returns the hash code of the <see cref="UnitInterval"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => this.Value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the <see cref="UnitInterval"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/>.
        /// </returns>
        public override string ToString() => this.Value.ToString(CultureInfo.InvariantCulture);
    }
}