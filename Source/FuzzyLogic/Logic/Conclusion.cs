// -------------------------------------------------------------------------------------------------
// <copyright file="Conclusion.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The conclusion.
    /// </summary>
    [Immutable]
    public class Conclusion : Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Conclusion"/> class.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public Conclusion(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            FuzzyState state)
            : base(variable, evaluator, state)
        {
        }
    }
}