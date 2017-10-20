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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy rule base.
    /// </summary>
    [Immutable]
    public class FuzzyRulebase
    {
        private readonly Dictionary<string, FuzzyRule> rules = new Dictionary<string, FuzzyRule>();

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
        /// Throws an exception if a fuzzyRule with the same name is already contained within the fuzzyRule base.
        /// </exception>
        public void Add(FuzzyRule fuzzyRule)
        {
            if (this.rules.ContainsKey(fuzzyRule.Name))
            {
                throw new ArgumentException($"Cannot add rule (Rule base already contains a rule named {fuzzyRule.Name}).");
            }

            this.rules.Add(fuzzyRule.Name, fuzzyRule);
        }

        /// <summary>
        /// Clears all rules from the <see cref="FuzzyRulebase"/>.
        /// </summary>
        public void ClearRules()
        {
            this.rules.Clear();
        }

        /// <summary>
        /// The get fuzzyRule.
        /// </summary>
        /// <param name="ruleName">
        /// The fuzzyRule name.
        /// </param>
        /// <returns>
        /// The <see cref="FuzzyRule"/>.
        /// </returns>
        public FuzzyRule GetRule(string ruleName)
        {
            return this.rules[ruleName];
        }
    }
}