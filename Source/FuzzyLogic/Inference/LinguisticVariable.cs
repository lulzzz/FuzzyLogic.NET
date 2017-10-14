// -------------------------------------------------------------------------------------------------
// <copyright file="LinguisticVariable.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using System.Collections.Generic;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The linguistic variable immutable class.
    /// </summary>
    public class LinguisticVariable
    {
        private readonly Dictionary<string, FuzzySet> fuzzySets;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinguisticVariable"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="lowerBound">
        /// The lower bound.
        /// </param>
        /// <param name="upperBound">
        /// The upper bound.
        /// </param>
        /// <param name="fuzzySets">
        /// The fuzzy sets.
        /// </param>
        public LinguisticVariable(
            string name,
            double lowerBound,
            double upperBound,
            Dictionary<string, FuzzySet> fuzzySets)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotOutOfRange(lowerBound, nameof(lowerBound), 0);
            Validate.NotOutOfRange(upperBound, nameof(upperBound), 0);
            Validate.NotNull(fuzzySets, nameof(fuzzySets));

            this.Name = name;
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
            this.fuzzySets = fuzzySets;
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
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double GetLabelMembership(string labelName, double value)
        {
            Validate.NotNull(labelName, nameof(labelName));

            return this.fuzzySets[labelName].GetMembership(value);
        }
    }
}
