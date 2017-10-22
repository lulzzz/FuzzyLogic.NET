﻿// -------------------------------------------------------------------------------------------------
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
        /// <param name="expected">
        /// The expected.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Evaluate(FuzzyState expected, FuzzyState result);
    }
}