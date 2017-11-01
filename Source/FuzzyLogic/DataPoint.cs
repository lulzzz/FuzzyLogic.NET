// -------------------------------------------------------------------------------------------------
// <copyright file="DataPoint.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="DataPoint"/> structure.
    /// </summary>
    [Immutable]
    public struct DataPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPoint"/> struct.
        /// </summary>
        /// <param name="variable">
        /// The variable name.
        /// </param>
        /// <param name="value">
        /// The data value.
        /// </param>
        public DataPoint(Label variable, double value)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotOutOfRange(value, nameof(value));

            this.Variable = variable;
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPoint"/> struct.
        /// </summary>
        /// <param name="variable">
        /// The variable name.
        /// </param>
        /// <param name="value">
        /// The data value.
        /// </param>
        public DataPoint(Enum variable, double value)
            : this(Label.Create(variable.ToString()), value)
        {
        }

        /// <summary>
        /// Gets the data variable name.
        /// </summary>
        public Label Variable { get; }

        /// <summary>
        /// Gets the data value.
        /// </summary>
        public double Value { get; }
    }
}