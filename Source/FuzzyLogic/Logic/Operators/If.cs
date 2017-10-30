// -------------------------------------------------------------------------------------------------
// <copyright file="If.cs" author="Christopher Sellers">
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
    /// The immutable sealed <see cref="If"/> class. Represents a linguistic string representation
    /// of the 'IF' logic operator.
    /// </summary>
    [Immutable]
    public sealed class If : ValidString<If>, IConnectiveOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="If"/> class.
        /// </summary>
        public If()
            : base(nameof(If).ToUpper())
        {
        }
    }
}