// -------------------------------------------------------------------------------------------------
// <copyright file="LinguisticVariable.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The linguistic variable immutable class.
    /// </summary>
    [Immutable]
    public class LinguisticVariable
    {
        private readonly Dictionary<Label, FuzzySet> fuzzySets = new Dictionary<Label, FuzzySet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguisticVariable"/> class.
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="inputSets">
        /// The input Sets.
        /// </param>
        /// <param name="lowerBound">
        /// The lower bound.
        /// </param>
        /// <param name="upperBound">
        /// The upper bound.
        /// </param>
        public LinguisticVariable(
            string label,
            IList<FuzzySet> inputSets,
            double lowerBound = double.MinValue,
            double upperBound = double.MaxValue)
        {
            Validate.NotNull(label, nameof(label));
            Validate.NotNullOrEmpty(inputSets, nameof(inputSets));
            Validate.NotOutOfRange(lowerBound, nameof(lowerBound));
            Validate.NotOutOfRange(upperBound, nameof(upperBound));
            Validate.FuzzySetCollection(inputSets, lowerBound, upperBound);

            this.Label = new Label(label);
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;

            foreach (var set in inputSets)
            {
                this.fuzzySets.Add(set.Label, set);
            }
        }

        /// <summary>
        /// Gets the label of the <see cref="LinguisticVariable"/>.
        /// </summary>
        public Label Label { get; }

        /// <summary>
        /// Gets the lower bound of the <see cref="LinguisticVariable"/>.
        /// </summary>
        public double LowerBound { get; }

        /// <summary>
        /// Gets the upper bound of the <see cref="LinguisticVariable"/>.
        /// </summary>
        public double UpperBound { get; }

        /// <summary>
        /// The get members.
        /// </summary>
        /// <returns>
        /// The <see cref="IReadOnlyCollection{T}"/>.
        /// </returns>
        public IReadOnlyCollection<Label> GetMembers() => this.fuzzySets.Keys.ToList().AsReadOnly();

        /// <summary>
        /// The is member.
        /// </summary>
        /// <param name="label">
        /// The lingualExpression.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsMember(Label label)
        {
            Validate.NotNull(label, nameof(label));

            return this.fuzzySets.ContainsKey(label);
        }

        /// <summary>
        /// The get set.
        /// </summary>
        /// <param name="label">
        /// The lingualExpression.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzySet"/>.
        /// </returns>
        public FuzzySet GetSet(Label label)
        {
            Validate.NotNull(label, nameof(label));

            return this.fuzzySets[label];
        }

        /// <summary>
        /// The get set membership.
        /// </summary>
        /// <param name="label">
        /// The set name.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetLabelMembership(Label label, double input)
        {
            Validate.NotNull(label, nameof(label));
            Validate.NotOutOfRange(input, nameof(input));

            return this.fuzzySets[label].GetMembership(input);
        }

        /// <summary>
        /// The get fuzzy membership.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public FuzzyState GetState(double input)
        {
            Validate.NotOutOfRange(input, nameof(input));

            var label = this.fuzzySets
                .OrderByDescending(fs => fs.Value.GetMembership(input))
                .FirstOrDefault()
                .Value
                .Label;

            return new FuzzyState(label.Value);
        }
    }
}