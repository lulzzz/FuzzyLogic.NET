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
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <returns>
        /// The <see cref="Condition"/>.
        /// </returns>
        private Condition(double weight)
        {
            Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

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
        public double Weight { get; }

        /// <summary>
        /// Sets the connective (if null).
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
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
            Validate.NotOutOfRange(weight, nameof(weight), 0, 1);

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
            Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.If,
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
            Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.And,
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
            Validate.NotNull(proposition, nameof(proposition));

            this.Premises.Add(new Premise(
                LogicOperators.Or,
                proposition.Variable,
                proposition.Evaluator,
                proposition.State));

            return this;
        }

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
                || truthTable.Any(p => p.Connective.Equals(LogicOperators.Or) && p.Result);
        }
    }
}