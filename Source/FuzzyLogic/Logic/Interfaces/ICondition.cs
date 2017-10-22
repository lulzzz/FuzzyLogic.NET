// -------------------------------------------------------------------------------------------------
// <copyright file="ICondition.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Interfaces
{
    /// <summary>
    /// The Condition interface.
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Evaluate();
    }
}