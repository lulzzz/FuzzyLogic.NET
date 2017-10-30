// -------------------------------------------------------------------------------------------------
// <copyright file="ValidString.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="ValidString{T}"/> class.
    /// </summary>
    /// <typeparam name="T">
    /// The type.
    /// </typeparam>
    [Immutable]
    public abstract class ValidString<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidString{T}"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        protected ValidString(string value)
        {
            Validate.NotNull(value, nameof(value));
            Validate.NotOutOfRange(value.Length, nameof(value.Length), 0, 50);

            this.Value = value.RemoveAllWhitespace();
        }

        /// <summary>
        /// Gets the <see cref="string"/> value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="ValidString{T}"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="ValidString{T}"/>.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator ==(ValidString<T> left, ValidString<T> right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="left">
        /// The left <see cref="ValidString{T}"/>.
        /// </param>
        /// <param name="right">
        /// The right <see cref="ValidString{T}"/>.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public static bool operator !=(ValidString<T> left, ValidString<T> right) => !(left == right);

        /// <summary>
        /// The equals override.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other) => this.Equals(other as ValidString<T>);

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the input <see cref="ValidString{T}"/> equals this.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="ValidString{T}"/>.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(ValidString<T> other) => other != null && this.Value == other.Value;

        /// <summary>
        /// Returns the hash code for this <see cref="ValidString{T}"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => this.Value.GetHashCode();

        /// <summary>
        /// Returns a <see cref="string"/> representation of this <see cref="ValidString{T}"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => this.Value;
    }
}