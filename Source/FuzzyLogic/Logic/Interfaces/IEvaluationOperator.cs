// -------------------------------------------------------------------------------------------------
// <copyright file="IEvaluationOperator.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Interfaces
{
    /// <summary>
    /// The <see cref="IEvaluationOperator"/> interface.
    /// </summary>
    public interface IEvaluationOperator : ILogicOperator
    {
        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Evaluate(LinguisticVariable variable, FuzzyState state, double input);
    }
}