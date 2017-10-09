// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueObject.cs" author="Christopher Sellers">
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
    /// The value object base class.
    /// </summary>
    /// <typeparam name="T">
    /// Type of value object.
    /// </typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>, IComparable<ValueObject<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObject{T}"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        protected ValueObject(double value)
        {
            Validate.NotInvalidNumber(value, nameof(value));

            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator +(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left.Value + right.Value;
        }

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator +(double left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left + right.Value;
        }

        /// <summary>
        /// The +.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator +(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value + right;
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator -(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left - right;
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator -(double left, ValueObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left - right;
        }

        /// <summary>
        /// The -.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator -(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left - right;
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator *(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left * right;
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator *(double left, ValueObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left * right;
        }

        /// <summary>
        /// The *.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator *(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left * right;
        }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator /(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left / right;
        }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator /(double left, ValueObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left / right;
        }

        /// <summary>
        /// The /.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static double operator /(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotInvalidNumber(right, nameof(right));

            return left / right;
        }

        /// <summary>
        /// The &gt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator >(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left.Value > right.Value;
        }

        /// <summary>
        /// The &gt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator >(double left, ValueObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left > right.Value;
        }

        /// <summary>
        /// The &gt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator >(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value > right;
        }

        /// <summary>
        /// The &lt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator <(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotNull(right, nameof(right));

            return left.Value < right.Value;
        }

        /// <summary>
        /// The &lt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator <(double left, ValueObject<T> right)
        {
            Validate.NotInvalidNumber(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return left < right.Value;
        }

        /// <summary>
        /// The &lt;.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator <(ValueObject<T> left, double right)
        {
            Validate.NotNull(left, nameof(right));
            Validate.NotInvalidNumber(right, nameof(right));

            return left.Value < right;
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return Equals(left, right);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            Validate.NotNull(left, nameof(left));
            Validate.NotNull(right, nameof(right));

            return !(left == right);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            return (other is ValueObject<T> otherValue) && (otherValue.Value == this.Value);
        }

        /// <summary>
        /// The compare to implementation.
        /// </summary>
        /// <param name="other">
        /// The other fuzzy value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CompareTo(ValueObject<T> other)
        {
            Validate.NotNull(other, nameof(other));

            return this.Value.CompareTo(other.Value);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode() + 42;
        }
    }
}