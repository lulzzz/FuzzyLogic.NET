// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRuleBuilder.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using System.Collections.Generic;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Logic.Interfaces;

    /// <summary>
    /// The <see cref="FuzzyRuleBuilder"/> class.
    /// </summary>
    public class FuzzyRuleBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRuleBuilder"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="FuzzyRule"/> to be built.
        /// </param>
        public FuzzyRuleBuilder(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        private string Name { get; }

        private IList<Condition> Conditions { get; set; } = new List<Condition>();

        private IList<Conclusion> Conclusions { get; set; } = new List<Conclusion>();

        /// <summary>
        /// Adds a condition to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition to be added.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Add(Condition condition)
        {
            this.Conditions.Add(condition);

            return this;
        }

        /// <summary>
        /// Adds a conclusion to the <see cref="FuzzyRule"/> to be built.
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
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Then(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            this.Conclusions.Add(new Conclusion(variable, evaluator, FuzzyState.Create(state)));

            return this;
        }

        /// <summary>
        /// Builds an immutable <see cref="FuzzyRule"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="FuzzyRule"/>.
        /// </returns>
        public FuzzyRule Build()
        {
            return new FuzzyRule(this.Name, this.Conditions, this.Conclusions);
        }
    }
}