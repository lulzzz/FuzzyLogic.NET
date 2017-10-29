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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="LinguisticVariable"/> class.
    /// </summary>
    [Immutable]
    public sealed class LinguisticVariable
    {
        private readonly Dictionary<Label, FuzzySet> fuzzySets = new Dictionary<Label, FuzzySet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguisticVariable"/> class.
        /// </summary>
        /// <param name="label">
        /// The <see cref="LinguisticVariable"/> label.
        /// </param>
        /// <param name="inputSets">
        /// The input sets.
        /// </param>
        /// <param name="lowerBound">
        /// The lower bound for the <see cref="LinguisticVariable"/>.
        /// </param>
        /// <param name="upperBound">
        /// The upper bound for the <see cref="LinguisticVariable"/>.
        /// </param>
        public LinguisticVariable(
            string label,
            IList<FuzzySet> inputSets,
            double lowerBound = double.MinValue,
            double upperBound = double.MaxValue)
        {
            Validate.NotNull(label, nameof(label));
            Validate.CollectionNotNullOrEmpty(inputSets, nameof(inputSets));
            Validate.NotOutOfRange(lowerBound, nameof(lowerBound));
            Validate.NotOutOfRange(upperBound, nameof(upperBound));
            Validate.FuzzySetCollection(inputSets, lowerBound, upperBound);

            this.Label = Label.Create(label);
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
        /// Returns the members contained within this <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="IReadOnlyCollection{T}"/>.
        /// </returns>
        public IReadOnlyCollection<Label> GetMembers() => this.fuzzySets.Keys.ToList().AsReadOnly();

        /// <summary>
        /// Returns a proposition based on whether the variable IS in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Proposition"/>.
        /// </returns>
        public Proposition Is(Enum state)
        {
            Validate.NotNull(state, nameof(state));

            return this.Is(state
                .ToString()
                .ToLower());
        }

        /// <summary>
        /// Returns a proposition based on whether the variable IS in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Premise"/>.
        /// </returns>
        public Proposition Is(string state)
        {
            Validate.NotNull(state, nameof(state));

            return this.Is(FuzzyState.Create(state));
        }

        /// <summary>
        /// Returns a proposition based on whether the variable IS in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Premise"/>.
        /// </returns>
        public Proposition Is(FuzzyState state)
        {
            return new Proposition(this, LogicOperators.Is, state);
        }

        /// <summary>
        /// Returns a proposition based on whether the variable IS NOT in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Proposition"/>.
        /// </returns>
        public Proposition IsNot(Enum state)
        {
            Validate.NotNull(state, nameof(state));

            return this.IsNot(state
                .ToString()
                .ToLower());
        }

        /// <summary>
        /// Returns a proposition based on whether the variable IS NOT in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Proposition"/>.
        /// </returns>
        public Proposition IsNot(string state)
        {
            Validate.NotNull(state, nameof(state));

            return this.IsNot(FuzzyState.Create(state));
        }

        /// <summary>
        /// Returns a proposition based on whether the variable IS NOT in the given state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Proposition"/>.
        /// </returns>
        public Proposition IsNot(FuzzyState state)
        {
            return new Proposition(this, LogicOperators.IsNot, state);
        }

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the given label is a member
        /// of this <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <param name="label">
        /// The label.
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
        /// Returns a <see cref="FuzzySet"/> with a label which matches the given label.
        /// </summary>
        /// <param name="label">
        /// The label.
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
        /// Returns the membership value [0, 1] of the member matching the given label
        /// (using the given <see cref="double"/>).
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetMembership(Label label, double input)
        {
            Validate.NotNull(label, nameof(label));
            Validate.NotOutOfRange(input, nameof(input), this.LowerBound, this.UpperBound);

            return this.fuzzySets[label].GetMembership(input);
        }

        /// <summary>
        /// Returns the <see cref="FuzzyState"/> of this <see cref="LinguisticVariable"/> determined
        /// by the given <see cref="double"/>.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public FuzzyState GetState(double input)
        {
            Validate.NotOutOfRange(input, nameof(input), this.LowerBound, this.UpperBound);

            var label = this.fuzzySets
                .OrderByDescending(fs => fs.Value.GetMembership(input))
                .FirstOrDefault()
                .Value
                .Label;

            return FuzzyState.Create(label.Value);
        }
    }
}