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

    /// <summary>
    /// The immutable <see cref="FuzzyState"/> structure.
    /// </summary>
    [Immutable]
    public sealed class FuzzyState : ValidString<FuzzyState>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyState"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public FuzzyState(string value) : base(value)
        {
        }
    }
}