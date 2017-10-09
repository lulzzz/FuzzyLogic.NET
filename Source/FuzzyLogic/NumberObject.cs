// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberObject.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The number object base class.
    /// </summary>
    /// <typeparam name="T">
    /// Type of number object.
    /// </typeparam>
    public abstract class NumberObject<T> where T : NumberObject<T>, IComparable<NumberObject<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberObject{T}"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        protected NumberObject(double value)
        {
            Validate.NotInvalidNumber(value, nameof(value));

            this.Value = value;
        }

        /// <summary>
        /// Gets the value of the <see cref="NumberObject{T}"/>.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator +(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left.Value + right.Value;
        }

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator +(double left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left + right.Value;
        }

        /// <summary>
        /// The + operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator +(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value + right;
        }

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator -(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left.Value - right.Value;
        }

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator -(double left, NumberObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left - right.Value;
        }

        /// <summary>
        /// The - operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator -(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value - right;
        }

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator *(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left.Value * right.Value;
        }

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator *(double left, NumberObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left * right.Value;
        }

        /// <summary>
        /// The * operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator *(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value * right;
        }

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator /(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left.Value / right.Value;
        }

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator /(double left, NumberObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left / right.Value;
        }

        /// <summary>
        /// The / operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static double operator /(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value / right;
        }

        /// <summary>
        /// The > operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator >(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left.Value > right.Value;
        }

        /// <summary>
        /// The > operator;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator >(double left, NumberObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left > right.Value;
        }

        /// <summary>
        /// The > operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator >(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value > right;
        }

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator <(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left.Value < right.Value;
        }

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator <(double left, NumberObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left < right.Value;
        }

        /// <summary>
        /// The &lt; operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator <(NumberObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value < right;
        }

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// A double.
        /// </returns>
        public static bool operator ==(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return Equals(left, right);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(NumberObject<T> left, NumberObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return !(left == right);
        }

        /// <summary>
        /// The equals method.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            return (other is NumberObject<T> otherValue) && (otherValue.Value == this.Value);
        }

        /// <summary>
        /// The compare to method.
        /// </summary>
        /// <param name="other">
        /// The other fuzzy value.
        /// </param>
        /// <returns>
        /// An <see cref="int"/>.
        /// </returns>
        public int CompareTo(NumberObject<T> other)
        {
            Validate.NotNull(other, nameof(other));

            return this.Value.CompareTo(other.Value);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// An <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() + 42;
        }
    }
}