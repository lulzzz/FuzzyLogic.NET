// -------------------------------------------------------------------------------------------------
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
    /// The immutable sealed <see cref="Or"/> class. Represents a linguistic string representation
    /// of the 'OR' logic operator.
    /// </summary>
    [Immutable]
    public sealed class Or : ValidString<Or>, IConnectiveOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Or"/> class.
        /// </summary>
        public Or() : base(nameof(Or).ToUpper())
        {
        }
    }
}