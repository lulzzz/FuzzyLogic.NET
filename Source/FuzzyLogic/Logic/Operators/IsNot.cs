// -------------------------------------------------------------------------------------------------
// <copyright file="IsNot.cs" author="Christopher Sellers">
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
    public class IsNot : IEvaluationOperator
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
        public bool Evaluate(FuzzyState expected, FuzzyState result) => expected != result;

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => nameof(IsNot).ToUpper();
    }
}