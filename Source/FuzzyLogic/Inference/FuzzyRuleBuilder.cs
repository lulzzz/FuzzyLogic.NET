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
    /// The fuzzy rule builder.
    /// </summary>
    public class FuzzyRuleBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRuleBuilder"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public FuzzyRuleBuilder(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        private string Name { get; }

        private IList<Condition> Conditions { get; set; } = new List<Condition>();

        private IList<Conclusion> Conclusions { get; set; } = new List<Conclusion>();

        /// <summary>
        /// The add condition.
        /// </summary>
        /// <param name="condition">
        /// The condition.
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
        /// The add condition.
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
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Then(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            this.Conclusions.Add(new Conclusion(variable, evaluator, new FuzzyState(state)));

            return this;
        }

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="FuzzyRule"/>.
        /// </returns>
        public FuzzyRule Build()
        {
            return new FuzzyRule(this.Name, this.Conditions, this.Conclusions);
        }
    }
}