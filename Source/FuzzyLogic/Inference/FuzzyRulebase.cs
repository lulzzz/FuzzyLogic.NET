// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRulebase.cs" author="Christopher Sellers">
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
    using System.Collections.ObjectModel;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="FuzzyRulebase"/> class.
    /// </summary>
    public class FuzzyRulebase
    {
        private readonly Dictionary<Label, FuzzyRule> rules = new Dictionary<Label, FuzzyRule>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRulebase"/> class.
        /// </summary>
        public FuzzyRulebase()
        {
            Validate.NotNull(this.rules, nameof(this.rules));
        }

        /// <summary>
        /// Returns the count of the <see cref="FuzzyRulebase"/>.
        /// </summary>
        public int Count => this.rules.Count;

        /// <summary>
        /// Returns a dictionary of rules.
        /// </summary>
        /// <returns>
        /// A read only dictionary.
        /// </returns>
        public IReadOnlyDictionary<Label, FuzzyRule> GetRules() => new ReadOnlyDictionary<Label, FuzzyRule>(this.rules);

        /// <summary>
        /// Adds the given <see cref="FuzzyRule"/> to the database.
        /// </summary>
        /// <param name="fuzzyRule">
        /// The input <see cref="FuzzyRule"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a fuzzy rule with the same name is already contained within the fuzzyRule base.
        /// </exception>
        public void AddRule(FuzzyRule fuzzyRule)
        {
            Validate.DictionaryDoesNotContainKey(fuzzyRule.Label, nameof(fuzzyRule.Label), this.rules);

            this.rules.Add(fuzzyRule.Label, fuzzyRule);
        }

        /// <summary>
        /// Clears all rules from the <see cref="FuzzyRulebase"/>.
        /// </summary>
        public void DeleteAllRules()
        {
            this.rules.Clear();
        }

        /// <summary>
        /// Returns the <see cref="FuzzyRule"/> which matches the given string.
        /// </summary>
        /// <param name="ruleLabel">
        /// The rule label.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRule"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the ruleLabel is null.
        /// </exception>
        public FuzzyRule GetRule(Label ruleLabel)
        {
            Validate.NotNull(ruleLabel, nameof(ruleLabel));

            return this.rules[ruleLabel];
        }
    }
}