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
    using FuzzyLogic.Inference;
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
        /// The connective.
        /// </param>
        /// <param name="premises">
        /// The premises.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <returns>
        /// The <see cref="Condition"/>.
        /// </returns>
        public Condition(
            IConnectiveOperator connective,
            IList<Premise> premises,
            UnitInterval weight)
        {
            Validate.NotNull(connective, nameof(connective));
            Validate.CollectionNotNullOrEmpty(premises, nameof(premises));
            Validate.NotNull(weight, nameof(weight));

            this.Connective = connective;
            this.Premises = premises;
            this.Weight = weight;
        }

        /// <summary>
        /// Gets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the list of premises.
        /// </summary>
        public IList<Premise> Premises { get; }

        /// <summary>
        /// Gets the weight.
        /// </summary>
        public UnitInterval Weight { get; private set; }

        /// <summary>
        /// The set weight.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        public void SetWeight(UnitInterval weight)
        {
            Validate.NotNull(weight, nameof(weight));

            this.Weight = weight;
        }

        /// <summary>
        /// Evaluates the fuzzy condition.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws if provided data does not contain all subjects.
        /// </exception>
        public Evaluation Evaluate(
            IReadOnlyDictionary<Label, DataPoint> data,
            FuzzyEvaluator evaluator)
        {
            Validate.NotNull(data, nameof(data));
            Validate.NotNull(evaluator, nameof(evaluator));

            var evaluations = new List<Evaluation>();

            foreach (var premise in this.Premises)
            {
                if (data.ContainsKey(premise.Subject))
                {
                    var input = data[premise.Subject];

                    evaluations.Add(premise.Evaluate(input));
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Evaluation Failed (cannot evaluate premise '{premise.Subject}' with provided data).");
                }
            }

            return new Evaluation(this.Connective, UnitInterval.Create(evaluator.Evaluate(evaluations) * this.Weight));
        }

        /// <summary>
        /// Returns a string representation of the condition.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/>.
        /// </returns>
        public override string ToString() => this.Premises
            .Aggregate(string.Empty, (current, premise) => current + $" {premise}")
            .Trim();
    }
}