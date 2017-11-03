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
        /// Initializes a new instance of the <see cref="FuzzyRuleBuilder"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="FuzzyRule"/> to be built.
        /// </param>
        public FuzzyRuleBuilder(Enum name)
            : this(name.ToString())
        {
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder If(Proposition proposition)
        {
            Validate.NotNull(proposition, nameof(proposition));

            var condition = ConditionBuilder.If(proposition);

            condition.Connective = LogicOperators.If();
            this.conditions.Add(condition.Build());

            return this;
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder And(Proposition proposition)
        {
            Validate.NotNull(proposition, nameof(proposition));

            var condition = ConditionBuilder.If(proposition);

            condition.Connective = LogicOperators.And();
            this.conditions.Add(condition.Build());

            return this;
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Or(Proposition proposition)
        {
            Validate.NotNull(proposition, nameof(proposition));

            var condition = ConditionBuilder.If(proposition);

            condition.Connective = LogicOperators.Or();
            this.conditions.Add(condition.Build());

            return this;
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition to be added.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder If(ConditionBuilder condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.Connective = LogicOperators.If();
            this.conditions.Add(condition.Build());

            return this;
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder And(ConditionBuilder condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.Connective = LogicOperators.And();
            this.conditions.Add(condition.Build());

            return this;
        }

        /// <summary>
        /// Adds a <see cref="Condition"/> to the <see cref="FuzzyRule"/> to be built.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRuleBuilder"/>.
        /// </returns>
        public FuzzyRuleBuilder Or(ConditionBuilder condition)
        {
            Validate.NotNull(condition, nameof(condition));

            condition.Connective = LogicOperators.Or();
            this.conditions.Add(condition.Build());

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
        /// <exception cref="InvalidOperationException">
        /// Throws if first connective is not an IF, or if there is more than one connective IF.
        /// </exception>
        public FuzzyRule Build()
        {
            Validate.CollectionNotNullOrEmpty(this.conditions, nameof(this.conditions));
            Validate.CollectionNotNullOrEmpty(this.conclusions, nameof(this.conclusions));

            return new FuzzyRule(this.name, this.conditions, this.conclusions);
        }
    }
}