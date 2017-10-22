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
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy rule.
    /// </summary>
    [Immutable]
    public class FuzzyRule
    {
        private readonly IList<Condition> conditions;
        private readonly IList<Conclusion> conclusions;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRule"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="conditions">
        /// The conditions.
        /// </param>
        /// <param name="conclusions">
        /// The conclusions.
        /// </param>
        public FuzzyRule(
            string name,
            IList<Condition> conditions,
            IList<Conclusion> conclusions)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNullOrEmpty(conditions, nameof(conditions));
            Validate.NotNullOrEmpty(conclusions, nameof(conclusions));

            this.Name = name;
            this.conditions = conditions;
            this.conclusions = conclusions;
        }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The premises.
        /// </summary>
        public IReadOnlyCollection<Condition> Conditions => this.conditions.ToList().AsReadOnly();

        /// <summary>
        /// Gets the conclusions.
        /// </summary>
        public IReadOnlyCollection<Conclusion> Conclusions => this.conclusions.ToList().AsReadOnly();

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate() => true;
    }
}