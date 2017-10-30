// -------------------------------------------------------------------------------------------------
// <copyright file="And.cs" author="Christopher Sellers">
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
    /// The immutable sealed <see cref="And"/> class. Represents a linguistic string representation
    /// of the 'AND' logic operator.
    /// </summary>
    [Immutable]
    public sealed class And : ValidString<And>, IConnectiveOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="And"/> class.
        /// </summary>
        public And()
            : base(nameof(And).ToUpper())
        {
        }
    }
}