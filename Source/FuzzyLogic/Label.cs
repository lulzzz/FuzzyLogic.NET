﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Label.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using FuzzyLogic.Annotations;

    /// <summary>
    /// The immutable <see cref="Label"/>.
    /// </summary>
    [Immutable]
    public class Label : ValidString<Label>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private Label(string value) : base(value)
        {
        }

        /// <summary>
        /// Creates a new <see cref="Label"/>.
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <returns>
        /// The <see cref="Label"/>.
        /// </returns>
        public static Label Create(string label)
        {
            return new Label(label);
        }
    }
}