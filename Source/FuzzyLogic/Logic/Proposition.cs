// -------------------------------------------------------------------------------------------------
// <copyright file="Proposition.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using System;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="Proposition"/> class.
    /// </summary>
    [Immutable]
    public class Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Proposition"/> class.
        /// </summary>
        /// <param name="variable">
        /// The linguistic variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluation logic operator.
        /// </param>
        /// <param name="state">
        /// The fuzzy state.
        /// </param>
        public Proposition(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            FuzzyState state)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Variable = variable;
            this.Evaluator = evaluator;
            this.State = state;

            this.ValidateProposition();
        }

        /// <summary>
        /// Gets the linguistic variable of the <see cref="Proposition"/>.
        /// </summary>
        public LinguisticVariable Variable { get; }

        /// <summary>
        /// Gets the evaluation logic operator of the <see cref="Proposition"/>.
        /// </summary>
        public IEvaluationOperator Evaluator { get; }

        /// <summary>
        /// Gets the fuzzy state of the <see cref="Proposition"/>.
        /// </summary>
        public FuzzyState State { get; }

        private void ValidateProposition()
        {
            if (!this.Variable.IsMember(this.State))
            {
                throw new InvalidOperationException(
                    $"Invalid Proposition (the state '{this.State}' is not a member of the linguistic variable '{this.Variable.Subject}').");
            }
        }
    }
}