﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ConditionBuilder.cs" author="Christopher Sellers">
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
    /// The <see cref="ConditionBuilder"/> class.
    /// </summary>
    public class ConditionBuilder
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ConditionBuilder"/> class from being created.
        /// </summary>
        /// <returns>
        /// A <see cref="ConditionBuilder"/>.
        /// </returns>
        private ConditionBuilder()
        {
            this.Weight = UnitInterval.One();
        }

        /// <summary>
        /// Gets or sets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; set; }

        /// <summary>
        /// Gets the list of premises.
        /// </summary>
        public IList<Premise> Premises { get; } = new List<Premise>();

        /// <summary>
        /// Gets the weight.
        /// </summary>
        public UnitInterval Weight { get; private set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// The <see cref="ConditionBuilder"/>.
        /// </returns>
        public static ConditionBuilder If(Proposition proposition)
        {
            Utility.Validate.NotNull(proposition, nameof(proposition));

            var conditionBuilder = new ConditionBuilder { Connective = LogicOperators.If() };

            conditionBuilder.Premises.Add(new Premise(
                LogicOperators.If(),
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

            return conditionBuilder;
        }

        /// <summary>
        /// Adds an 'And' premise to the condition builder.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public ConditionBuilder And(Proposition proposition)
        {
            Utility.Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.And(),
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

            return this;
        }

        /// <summary>
        /// Adds an 'Or' premise to the condition builder.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public ConditionBuilder Or(Proposition proposition)
        {
            Utility.Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.Or(),
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

            return this;
        }

        /// <summary>
        /// The with weight.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <returns>
        /// The <see cref="ConditionBuilder"/>.
        /// </returns>
        public ConditionBuilder WithWeight(double weight)
        {
            Utility.Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

            this.Weight = UnitInterval.Create(weight);

            return this;
        }

        /// <summary>
        /// Returns a new condition based on the current <see cref="ConditionBuilder"/> parameters.
        /// </summary>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition Build()
        {
            return new Condition(this.Connective, this.Premises, this.Weight);
        }
    }
}