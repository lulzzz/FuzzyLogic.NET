// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MembershipValue.cs" author="Christopher Sellers">
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
    /// The membership value class. The value is guaranteed to be within the range [0, 1].
    /// </summary>
    [Serializable]
    public class MembershipValue : NumberObject<MembershipValue>, IComparable<NumberObject<MembershipValue>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipValue"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private MembershipValue(double value) : base(value)
        {
            Validate.NotOutOfRange(value, nameof(value), 0, 1);
        }

        /// <summary>
        /// Creates a new <see cref="MembershipValue"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public static MembershipValue Create(double value)
        {
            return new MembershipValue(value);
        }

        /// <summary>
        /// Creates a new <see cref="MembershipValue"/> with a value of 0.
        /// </summary>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public static MembershipValue Zero()
        {
            return new MembershipValue(0);
        }

        /// <summary>
        /// Adds the given <see cref="MembershipValue"/>.
        /// </summary>
        /// <param name="other">
        /// The other value to add.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue Add(MembershipValue other)
        {
            Validate.NotNull(other, nameof(other));

            return new MembershipValue(this.Value + other.Value);
        }

        /// <summary>
        /// Subtracts the given <see cref="MembershipValue"/>.
        /// </summary>
        /// <param name="other">
        /// The other value to add.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue Subtract(MembershipValue other)
        {
            Validate.NotNull(other, nameof(other));

            return new MembershipValue(this.Value - other.Value);
        }

        /// <summary>
        /// Multiplies the <see cref="MembershipValue"/> by the given factor.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue Multiply(double factor)
        {
            Validate.NotInvalidNumber(factor, nameof(factor));

            return new MembershipValue(this.Value * factor);
        }

        /// <summary>
        /// Divides the <see cref="MembershipValue"/> by the given divisor.
        /// </summary>
        /// <param name="divisor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The <see cref="MembershipValue"/>.
        /// </returns>
        public MembershipValue Divide(double divisor)
        {
            Validate.NotOutOfRange(divisor, nameof(divisor), 0, double.MaxValue, RangeEndPoints.LowerExclusive);

            return new MembershipValue(this.Value / divisor);
        }
    }
}