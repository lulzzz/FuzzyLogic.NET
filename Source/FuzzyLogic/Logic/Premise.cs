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
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="Premise"/> class.
    /// </summary>
    [Immutable]
    public class Premise : Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Premise"/> class.
        /// </summary>
        /// <param name="connective">
        /// The connective logic operator.
        /// </param>
        /// <param name="variable">
        /// The linguistic variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluation logic operator.
        /// </param>
        /// <param name="state">
        /// The fuzzy state.
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
            this.Subject = variable.Subject;
        }

        /// <summary>
        /// Gets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        public Label Subject { get; }

        /// <summary>
        /// Returns the <see cref="Evaluation"/> of the <see cref="Premise"/>.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public Evaluation Evaluate(DataPoint input)
        {
            Validate.NotNull(input, nameof(input));

            return new Evaluation(this.Connective, this.Variable.GetMembership(this.State, input.Value));
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => $"{this.Connective} {this.Variable.Subject} {this.Evaluator} {this.State}";
    }
}