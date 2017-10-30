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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The immutable sealed <see cref="Is"/> class. Represents a linguistic string representation
    /// of the 'IS' logic operator.
    /// </summary>
    [Immutable]
    public sealed class Is : ValidString<Is>, IEvaluationOperator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Is"/> class.
        /// </summary>
        public Is() : base(nameof(Is).ToUpper())
        {
        }

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
        public bool Evaluate(FuzzyState expected, FuzzyState result) => expected == result;
    }
}