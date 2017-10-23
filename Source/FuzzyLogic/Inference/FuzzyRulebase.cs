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
        /// Adds the input <see cref="FuzzyRule"/> to the database.
        /// </summary>
        /// <param name="fuzzyRule">
        /// The input <see cref="FuzzyRule"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a fuzzy rule with the same name is already contained within the fuzzyRule base.
        /// </exception>
        public void Add(FuzzyRule fuzzyRule)
        {
            if (this.rules.ContainsKey(fuzzyRule.Label))
            {
                throw new ArgumentException($"Cannot add rule (Rule base already contains a rule named {fuzzyRule.Label}).");
            }

            this.rules.Add(fuzzyRule.Label, fuzzyRule);
        }

        /// <summary>
        /// Clears all rules from the <see cref="FuzzyRulebase"/>.
        /// </summary>
        public void ClearRules()
        {
            this.rules.Clear();
        }

        /// <summary>
        /// Returns the <see cref="FuzzyRule"/> which matches the given string.
        /// </summary>
        /// <param name="ruleName">
        /// The rule name.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRule"/>.
        /// </returns>
        public FuzzyRule GetRule(string ruleName)
        {
            return this.rules[Label.Create(ruleName)];
        }
    }
}