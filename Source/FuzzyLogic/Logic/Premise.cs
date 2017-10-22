// -------------------------------------------------------------------------------------------------
// <copyright file="Premise.cs" author="Christopher Sellers">
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
    using FuzzyLogic.Utility;

    /// <summary>
    /// The premise.
    /// </summary>
    [Immutable]
    public class Premise : Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Premise"/> class.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <param name="state">
        /// The query.
        /// </param>
        public Premise(
            IConnectiveOperator connective,
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            FuzzyState state)
            : base(variable, evaluator, state)
        {
            Validate.NotNull(connective, nameof(connective));
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(state, nameof(state));

            this.Connective = connective;
            this.Subject = variable.Label;
        }

        /// <summary>
        /// Gets the connective.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        public Label Subject { get; }

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public Evaluation Evaluate(double input)
        {
            Validate.NotOutOfRange(input, nameof(input));

            return new Evaluation(this.Connective, this.Evaluator.Evaluate(this.State, this.Variable.GetState(input)));
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => $"{this.Connective} {this.Variable.Label} {this.Evaluator} {this.State}";
    }
}