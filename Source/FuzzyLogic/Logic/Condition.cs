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

    /// <summary>
    /// The <see cref="Condition"/> class.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Condition"/> class.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <returns>
        /// The <see cref="Condition"/>.
        /// </returns>
        private Condition(double weight)
        {
            Utility.Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

            this.Weight = weight;
        }

        /// <summary>
        /// Gets the connective logic operator.
        /// </summary>
        public IConnectiveOperator Connective { get; private set; }

        /// <summary>
        /// Gets the list of premises.
        /// </summary>
        public IList<Premise> Premises { get; } = new List<Premise>();

        /// <summary>
        /// Gets the weight.
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Sets the conditions connective (if null).
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Throws if the method is called when the connective is already set (not null).
        /// </exception>
        public void SetConnective(IConnectiveOperator connective)
        {
            if (this.Connective != null)
            {
                throw new InvalidOperationException(
                    "Invalid Operation (cannot change a conditions connective once set).");
            }

            this.Connective = connective;
        }

        /// <summary>
        /// The set weight.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        public void SetWeight(double weight)
        {
            Utility.Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

            this.Weight = weight;
        }

        /// <summary>
        /// Returns a new condition with the given weight.
        /// </summary>
        /// <param name="weight">
        /// The weight [0, 1].
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public static Condition Create(double weight = 1)
        {
            Utility.Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

            return new Condition(weight);
        }

        /// <summary>
        /// Adds an 'If' premise to the condition.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition If(Proposition proposition)
        {
            Utility.Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.If(),
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

            return this;
        }

        /// <summary>
        /// Adds an 'And' premise to the condition.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition And(Proposition proposition)
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
        /// Adds an 'Or' premise to the condition.
        /// </summary>
        /// <param name="proposition">
        /// The proposition.
        /// </param>
        /// <returns>
        /// A <see cref="Condition"/>.
        /// </returns>
        public Condition Or(Proposition proposition)
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
            Utility.Validate.CollectionNotNullOrEmpty(this.Premises, nameof(this.Premises));
            Utility.Validate.CollectionNotNullOrEmpty(data, nameof(data));

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
        /// Validates the condition.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Throws if the condition is found invalid.
        /// </exception>
        public void Validate()
        {
            if (this.Connective == null)
            {
                throw new InvalidOperationException(
                    "Invalid Condition (the connective is null).");
            }

            if (this.Premises.Count == 0)
            {
                throw new InvalidOperationException(
                    "Invalid Condition (there are no premises).");
            }
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