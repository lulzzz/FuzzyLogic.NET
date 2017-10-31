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
            double weight)
        {
            Validate.NotNull(connective, nameof(connective));
            Validate.CollectionNotNullOrEmpty(premises, nameof(premises));
            Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

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
        public double Weight { get; private set; }

        /// <summary>
        /// The set weight.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        public void SetWeight(double weight)
        {
            Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

            this.Weight = weight;
        }

        /// <summary>
        /// Evaluates the fuzzy condition.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws if provided data does not contain all subjects.
        /// </exception>
        public double Evaluate(IDictionary<Label, double> data)
        {
            Validate.CollectionNotNullOrEmpty(data, nameof(data));

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

            var ifAndAverage = evaluations
                .Where(e => e.Connective.Equals(LogicOperators.If()) || e.Connective.Equals(LogicOperators.And()))
                .Average(e => e.Result);

            var highestOr = 0.0;

            if (evaluations.Exists(e => e.Connective.Equals(LogicOperators.Or())))
            {
                highestOr = evaluations
                    .Where(e => e.Connective.Equals(LogicOperators.Or()))
                    .Max(e => e.Result);
            }

            return Math.Max(ifAndAverage, highestOr) * this.Weight;
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