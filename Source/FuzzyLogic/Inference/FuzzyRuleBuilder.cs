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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="FuzzyRuleBuilder"/> class.
    /// </summary>
    public class FuzzyRuleBuilder
    {
        private readonly string name;
        private readonly IList<Condition> conditions = new List<Condition>();
        private readonly IList<Conclusion> conclusions = new List<Conclusion>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRuleBuilder"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="FuzzyRule"/> to be built.
        /// </param>
        public FuzzyRuleBuilder(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Adds a condition to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition to be added.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder If(Condition condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.SetConnective(LogicOperators.If);
            this.conditions.Add(condition);

            return this;
        }

        /// <summary>
        /// Adds a condition to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder And(Condition condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.SetConnective(LogicOperators.And);
            this.conditions.Add(condition);

            return this;
        }

        /// <summary>
        /// Adds an OR condition to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Or(Condition condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.SetConnective(LogicOperators.Or);
            this.conditions.Add(condition);

            return this;
        }

        /// <summary>
        /// Adds a conclusion to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Then(Proposition proposition)
        {
            Validate.NotNull(proposition, nameof(proposition));

            this.conclusions.Add(new Conclusion(
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

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
            Validate.CollectionNotNullOrEmpty(this.conditions, nameof(this.conditions));
            Validate.CollectionNotNullOrEmpty(this.conclusions, nameof(this.conclusions));

            if (this.conditions[0].Connective.ToString() != LogicOperators.If.ToString())
            {
                throw new InvalidOperationException(
                    $"Invalid FuzzyRule (the connective of the first condition must be an IF). Value = {this.conditions[0].Connective}.");
            }

            var remainingConditions = new List<Condition>(this.conditions);
            remainingConditions.RemoveAt(0);

            if (remainingConditions.Any(conclusion => conclusion.Connective.ToString() == LogicOperators.If.ToString()))
            {
                throw new InvalidOperationException(
                    $"Invalid FuzzyRule (only the connective of the first condition can be an IF).");
            }

            return new FuzzyRule(this.name, this.conditions, this.conclusions);
        }
    }
}