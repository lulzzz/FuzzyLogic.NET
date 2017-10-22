// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyQuery.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy query.
    /// </summary>
    public class FuzzyQuery
    {
        private readonly LinguisticVariable subject;
        private readonly IEvaluationOperator evaluator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyQuery"/> class.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <param name="queriedState">
        /// The expected State.
        /// </param>
        /// <param name="inputValue">
        /// The inputValue.
        /// </param>
        public FuzzyQuery(
            LinguisticVariable subject,
            IEvaluationOperator evaluator,
            FuzzyState queriedState,
            double inputValue = 0)
        {
            Validate.NotNull(subject, nameof(subject));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(queriedState, nameof(queriedState));

            this.subject = subject;
            this.evaluator = evaluator;
            this.QueriedState = queriedState;

            this.UpdateInputValue(inputValue);
        }

        /// <summary>
        /// The subject.
        /// </summary>
        public Label Subject => this.subject.Label;

        /// <summary>
        /// Gets the expected state.
        /// </summary>
        public FuzzyState QueriedState { get; }

        /// <summary>
        /// Gets the inputValue.
        /// </summary>
        public double InputValue { get; private set; }

        /// <summary>
        /// The update input value.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public void UpdateInputValue(double input)
        {
            Validate.NotOutOfRange(input, nameof(input));

            this.InputValue = input;
        }

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate() => this.evaluator.Evaluate(this.QueriedState, this.subject.GetState(this.InputValue));

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => $"Query: {this.Subject} {this.evaluator} {this.QueriedState}";
    }
}