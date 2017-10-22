// -------------------------------------------------------------------------------------------------
// <copyright file="Is.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Operators
{
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The is.
    /// </summary>
    public class Is : IEvaluationOperator
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
        public bool Evaluate(
            LinguisticVariable variable,
            FuzzyState state,
            double input)
        {
            return variable.GetFuzzyMembership(input) == state;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => nameof(Is).ToUpper();
    }
}