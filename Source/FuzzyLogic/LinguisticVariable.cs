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
    using System.Threading;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The linguistic variable immutable class.
    /// </summary>
    public class LinguisticVariable
    {
        private readonly Dictionary<string, FuzzySet> fuzzySets = new Dictionary<string, FuzzySet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguisticVariable"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
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
            string name,
            IList<FuzzySet> inputSets,
            double lowerBound = double.MinValue,
            double upperBound = double.MaxValue)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(inputSets, nameof(inputSets));
            Validate.NotOutOfRange(lowerBound, nameof(lowerBound));
            Validate.NotOutOfRange(upperBound, nameof(upperBound));
            ValidateFuzzySetsCollection(inputSets, lowerBound, upperBound);

            this.Name = name;
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;

            foreach (var set in inputSets)
            {
                this.fuzzySets.Add(set.Name, set);
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the lower bound of the <see cref="LinguisticVariable"/>.
        /// </summary>
        public double LowerBound { get; }

        /// <summary>
        /// Gets the upper bound of the <see cref="LinguisticVariable"/>.
        /// </summary>
        public double UpperBound { get; }

        /// <summary>
        /// Gets or sets the input value.
        /// </summary>
        public double InputValue { get; set; } = 0;

        /// <summary>
        /// The get members.
        /// </summary>
        /// <returns>
        /// The <see cref="IReadOnlyCollection{T}"/>.
        /// </returns>
        public IReadOnlyCollection<string> GetMembers() => this.fuzzySets.Keys.ToList().AsReadOnly();

        /// <summary>
        /// The is member.
        /// </summary>
        /// <param name="labelName">
        /// The label name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsMember(string labelName)
        {
            Validate.NotNull(labelName, nameof(labelName));

            return this.fuzzySets.ContainsKey(labelName);
        }

        /// <summary>
        /// The is.
        /// </summary>
        /// <param name="labelName">
        /// The label name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Is(string labelName)
        {
            return this.GetFuzzyMembership() == labelName;
        }

        /// <summary>
        /// The get set.
        /// </summary>
        /// <param name="labelName">
        /// The set name.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzySet"/>.
        /// </returns>
        public FuzzySet GetSet(string labelName)
        {
            Validate.NotNull(labelName, nameof(labelName));

            return this.fuzzySets[labelName];
        }

        /// <summary>
        /// The get set membership.
        /// </summary>
        /// <param name="labelName">
        /// The set name.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetLabelMembership(string labelName)
        {
            Validate.NotNull(labelName, nameof(labelName));
            Validate.NotOutOfRange(this.InputValue, nameof(this.InputValue), 0);

            return this.fuzzySets[labelName].GetMembership(this.InputValue);
        }

        /// <summary>
        /// The get fuzzy membership.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetFuzzyMembership()
        {
            Validate.NotOutOfRange(this.InputValue, nameof(this.InputValue), 0);

            return this.fuzzySets
                .OrderByDescending(fs => fs.Value.GetMembership(this.InputValue))
                .FirstOrDefault()
                .Value
                .Name;
        }

        private static void ValidateFuzzySetsCollection(
            ICollection<FuzzySet> inputSets,
            double lowerBound,
            double upperBound)
        {
            Validate.NotNull(inputSets, nameof(inputSets));
            Validate.NotOutOfRange(lowerBound, nameof(lowerBound));
            Validate.NotOutOfRange(lowerBound, nameof(upperBound));

            if (lowerBound > upperBound)
            {
                throw new ArgumentException(
                    $"Lower bound ({lowerBound}) cannot be greater than upper bound ({upperBound}).");
            }

            foreach (var set in inputSets)
            {
                if (set.LowerBound < lowerBound)
                {
                    throw new ArgumentException(
                        $"Lower bound cannot be greater than lowest bound of input set ({set.Name} {lowerBound} < {set.LowerBound}).");
                }

                if (set.UpperBound > upperBound)
                {
                    throw new ArgumentException(
                        $"Upper bound cannot be less than highest upper bound of input set ({set.Name}).");
                }
            }
        }
    }
}