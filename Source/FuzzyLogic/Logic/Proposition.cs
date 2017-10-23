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
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy rule proposition.
    /// </summary>
    [Immutable]
    public abstract class Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Proposition"/> class.
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
        protected Proposition(
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
        /// Gets the variable.
        /// </summary>
        protected LinguisticVariable Variable { get; }

        /// <summary>
        /// Gets the evaluator.
        /// </summary>
        protected IEvaluationOperator Evaluator { get; }

        /// <summary>
        /// Gets the lingualExpression.
        /// </summary>
        protected FuzzyState State { get; }

        private void ValidateProposition()
        {
            if (!this.Variable.IsMember(Label.Create(this.State.Value)))
            {
                throw new ArgumentException($"Invalid Proposition (the state '{this.State}' is not a member of the linguistic variable '{this.Variable.Label}').");
            }
        }
    }
}