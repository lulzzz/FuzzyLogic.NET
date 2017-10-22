// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyState.cs" author="Christopher Sellers">
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
    /// The immutable <see cref="FuzzyState"/> structure.
    /// </summary>
    [Immutable]
    public struct FuzzyState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyState"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public FuzzyState(string value)
        {
            Validate.NotNull(value, nameof(value));

            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

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
        /// A boolean.
        /// </returns>
        public static bool operator ==(FuzzyState left, FuzzyState right) => left.Equals(right);

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
        /// A boolean.
        /// </returns>
        public static bool operator !=(FuzzyState left, FuzzyState right) => !(left == right);

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
            if (!(other is FuzzyState))
            {
                return false;
            }

            return this.Equals((FuzzyState)other);
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
        public bool Equals(FuzzyState other) => this.Value == other.Value;

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => this.Value.GetHashCode();

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => this.Value;
    }
}