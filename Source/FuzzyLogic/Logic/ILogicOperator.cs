// -------------------------------------------------------------------------------------------------
// <copyright file="ILogicOperator.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    /// <summary>
    /// The logic operator.
    /// </summary>
    public interface ILogicOperator
    {
        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Evaluate(LinguisticVariable variable, string condition);
    }
}