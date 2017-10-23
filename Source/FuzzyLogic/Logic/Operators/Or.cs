﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Or.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Operators
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The immutable <see cref="Or"/> class.
    /// </summary>
    [Immutable]
    public sealed class Or : IConnectiveOperator
    {
        /// <summary>
        /// Returns a linguistic string representation of the logic operator.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/>.
        /// </returns>
        public override string ToString() => nameof(Or).ToUpper();
    }
}