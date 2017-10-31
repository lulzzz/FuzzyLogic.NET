// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRule.cs" author="Christopher Sellers">
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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable sealed <see cref="FuzzyRule"/> class.
    /// </summary>
    [Immutable]
    public sealed class FuzzyRule
    {
        private readonly IList<Condition> conditions;
        private readonly IList<Conclusion> conclusions;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRule"/> class.
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="conditions">
        /// The conditions.
        /// </param>
        /// <param name="conclusions">
        /// The conclusions.
        /// </param>
        public FuzzyRule(
            string label,
            IList<Condition> conditions,
            IList<Conclusion> conclusions)
        {
            Validate.NotNull(label, nameof(label));
            Validate.CollectionNotNullOrEmpty(conditions, nameof(conditions));
            Validate.CollectionNotNullOrEmpty(conclusions, nameof(conclusions));
            ValidateFuzzyRule(conditions, conclusions);

            this.Label = Label.Create(label);
            this.conditions = conditions;
            this.conclusions = conclusions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRule"/> class.
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="conditions">
        /// The conditions.
        /// </param>
        /// <param name="conclusions">
        /// The conclusions.
        /// </param>
        public FuzzyRule(
            Enum label,
            IList<Condition> conditions,
            IList<Conclusion> conclusions)
            : this(label.ToString(), conditions, conclusions)
        {
        }

        /// <summary>
        /// Gets the rule label.
        /// </summary>
        public Label Label { get; }

        /// <summary>
        /// Returns a collection of the premises.
        /// </summary>
        public IReadOnlyCollection<Condition> Conditions => this.conditions.ToList().AsReadOnly();

        /// <summary>
        /// Returns a collection of the conclusions.
        /// </summary>
        public IReadOnlyCollection<Conclusion> Conclusions => this.conclusions.ToList().AsReadOnly();

        /// <summary>
        /// Returns the result of the rules evaluation.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{FuzzyOutput}"/>.
        /// </returns>
        public IEnumerable<FuzzyOutput> Evaluate(IDictionary<Label, double> data)
        {
            Validate.NotNull(data, nameof(data));

            var firingStrength = this.conditions
                .Select(c => c.Evaluate(data))
                .Max();

            var output = new List<FuzzyOutput>();

            foreach (var conclusion in this.conclusions)
            {
                output.Add(new FuzzyOutput(
                    conclusion.Variable.Label,
                    conclusion.State,
                    conclusion.Variable.GetSet(conclusion.State),
                    firingStrength));
            }

            return output;
        }

        private static void ValidateFuzzyRule(IList<Condition> conditions, IList<Conclusion> conclusions)
        {
            Validate.CollectionNotNullOrEmpty(conditions, nameof(conditions));
            Validate.CollectionNotNullOrEmpty(conclusions, nameof(conclusions));

            conditions.ForEach(c => c.Validate());

            if (conditions[0].Connective.ToString() != LogicOperators.If().ToString())
            {
                throw new InvalidOperationException(
                    $"Invalid FuzzyRule (the connective of the first condition must be an IF). Value = {conditions[0].Connective}.");
            }

            var remainingConditions = new List<Condition>(conditions);
            remainingConditions.RemoveAt(0);

            if (remainingConditions.Any(conclusion => conclusion.Connective.Equals(LogicOperators.If())))
            {
                throw new InvalidOperationException(
                    $"Invalid FuzzyRule (only the connective of the first condition can be an IF).");
            }

            for (var i = 0; i < conditions.Count - 1; i++)
            {
                if (conditions[i].Connective.Equals(LogicOperators.Or())
                 && conditions[i + 1].Connective.Equals(LogicOperators.And()))
                {
                    throw new InvalidOperationException(
                        $"Invalid FuzzyRule (an OR condition connective cannot be followed by an AND).");
                }
            }
        }
    }
}