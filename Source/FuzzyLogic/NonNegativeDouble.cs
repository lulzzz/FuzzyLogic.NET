// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NonNegativeDouble.cs" author="Christopher Sellers">
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
    /// The non negative double class. The value is guaranteed to be within the range of [0, double.Max].
    /// </summary>
    [Serializable]
    public class NonNegativeDouble : NumberObject<NonNegativeDouble>, IComparable<NumberObject<NonNegativeDouble>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonNegativeDouble"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private NonNegativeDouble(double value) : base(value)
        {
            Validate.NotOutOfRange(value, nameof(value), 0, double.MaxValue);
        }

        /// <summary>
        /// Creates a new <see cref="NonNegativeDouble"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public static NonNegativeDouble Create(double value)
        {
            return new NonNegativeDouble(value);
        }

        /// <summary>
        /// Creates a new <see cref="NonNegativeDouble"/> with a value of 0.
        /// </summary>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public static NonNegativeDouble Zero()
        {
            return new NonNegativeDouble(0);
        }

        /// <summary>
        /// Adds the given <see cref="NonNegativeDouble"/>.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="NonNegativeDouble"/> to add.
        /// </param>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public NonNegativeDouble Add(NonNegativeDouble other)
        {
            Validate.NotNull(other, nameof(other));

            return new NonNegativeDouble(this.Value + other.Value);
        }

        /// <summary>
        /// Subtracts the given <see cref="NonNegativeDouble"/>.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="NonNegativeDouble"/> to subtract.
        /// </param>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public NonNegativeDouble Subtract(NonNegativeDouble other)
        {
            Validate.NotNull(other, nameof(other));

            return new NonNegativeDouble(this.Value - other.Value);
        }

        /// <summary>
        /// Multiplies the <see cref="NonNegativeDouble"/> by the given factor.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public NonNegativeDouble Multiply(double factor)
        {
            Validate.NotInvalidNumber(factor, nameof(factor));

            return new NonNegativeDouble(this.Value * factor);
        }

        /// <summary>
        /// Divides the <see cref="NonNegativeDouble"/> by the given divisor.
        /// </summary>
        /// <param name="divisor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="NonNegativeDouble"/>.
        /// </returns>
        public NonNegativeDouble Divide(double divisor)
        {
            Validate.NotOutOfRange(divisor, nameof(divisor), 0, double.MaxValue, RangeEndPoints.LowerExclusive);

            return new NonNegativeDouble(this.Value / divisor);
        }
    }
}