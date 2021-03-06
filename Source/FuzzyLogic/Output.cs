﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Output.cs" author="Christopher Sellers">
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
    /// The immutable <see cref="Output"/> structure.
    /// </summary>
    [Immutable]
    public struct Output
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> struct.
        /// </summary>
        /// <param name="subject">
        /// The subject name.
        /// </param>
        /// <param name="value">
        /// The output value.
        /// </param>
        public Output(Label subject, double value)
        {
            Validate.NotNull(subject, nameof(subject));
            Validate.NotOutOfRange(value, nameof(value));

            this.Subject = subject;
            this.Value = value;
        }

        /// <summary>
        /// Gets the output subject name.
        /// </summary>
        public Label Subject { get; }

        /// <summary>
        /// Gets the output value.
        /// </summary>
        public double Value { get; }
    }
}