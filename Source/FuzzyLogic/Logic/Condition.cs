﻿// -------------------------------------------------------------------------------------------------
// <copyright file="Condition.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The condition.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition"/> class.
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
        /// The value.
        /// </param>
        public Condition(
            IConnectiveOperator connective,
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            Validate.NotNull(connective, nameof(connective));
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Connective = connective;

            this.Premises.Add(new Premise(LogicOperators.If, variable, evaluator, new FuzzyState(state)));
        }

        /// <summary>
        /// Gets the connective.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the premise.
        /// </summary>
        public IList<Premise> Premises { get; } = new List<Premise>();

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate(IDictionary<Label, double> data)
        {
            var truthTable = new List<Evaluation>();

            foreach (var premise in this.Premises)
            {
                if (data.ContainsKey(premise.Subject))
                {
                    var input = data[premise.Subject];

                    truthTable.Add(premise.Evaluate(input));
                }
                else
                {
                    throw new ArgumentException(
                        $"Evaluation Failed (cannot evaluate premise '{premise.Subject}' with provided data).");
                }
            }

            return truthTable.All(p => p.Result)
                || truthTable.Any(p => p.Connective == LogicOperators.Or && p.Result);
        }

        /// <summary>
        /// The and.
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
        /// The <see cref="Condition"/>.
        /// </returns>
        public Condition And(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Premises.Add(new Premise(LogicOperators.And, variable, evaluator, new FuzzyState(state)));

            return this;
        }

        /// <summary>
        /// The and.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <param name="state">
        /// The expected state.
        /// </param>
        /// <returns>
        /// The <see cref="Condition"/>.
        /// </returns>
        public Condition Or(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Premises.Add(new Premise(LogicOperators.Or, variable, evaluator, new FuzzyState(state)));

            return this;
        }
    }
}