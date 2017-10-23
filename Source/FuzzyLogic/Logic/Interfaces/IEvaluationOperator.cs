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
        /// Returns a <see cref="bool"/> indicating the result of the evaluation.
        /// </summary>
        /// <param name="expected">
        /// The expected fuzzy state.
        /// </param>
        /// <param name="result">
        /// The actual fuzzy state.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        bool Evaluate(FuzzyState expected, FuzzyState result);
    }
}