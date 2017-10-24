// -------------------------------------------------------------------------------------------------
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
    /// The <see cref="Condition"/> class.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition"/> class.
        /// </summary>
        /// <param name="connective">
        /// The connective logic operator.
        /// </param>
        /// <param name="variable">
        /// The linguistic variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator logic operator.
        /// </param>
        /// <param name="state">
        /// The fuzzy state.
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

            this.Premises.Add(new Premise(LogicOperators.If, variable, evaluator, FuzzyState.Create(state)));
        }

        /// <summary>
        /// Gets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the list of premises.
        /// </summary>
        public IList<Premise> Premises { get; } = new List<Premise>();

        /// <summary>
        /// Returns the logical evaluation of all premises.
        /// </summary>
        /// <param name="data">
        /// The input data.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public bool Evaluate(IDictionary<Label, double> data)
        {
            Validate.CollectionNotNullOrEmpty(data, nameof(data));

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
        /// Adds an 'And' premise to the condition.
        /// </summary>
        /// <param name="variable">
        /// The linguistic variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluation logic operator.
        /// </param>
        /// <param name="state">
        /// The expected fuzzy state.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition And(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Premises.Add(new Premise(LogicOperators.And, variable, evaluator, FuzzyState.Create(state)));

            return this;
        }

        /// <summary>
        /// Adds an 'Or' premise to the condition.
        /// </summary>
        /// <param name="variable">
        /// The linguistic variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluation logic operator.
        /// </param>
        /// <param name="state">
        /// The expected fuzzy state.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition Or(
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            string state)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(evaluator, nameof(evaluator));
            Validate.NotNull(state, nameof(state));

            this.Premises.Add(new Premise(LogicOperators.Or, variable, evaluator, FuzzyState.Create(state)));

            return this;
        }
    }
}