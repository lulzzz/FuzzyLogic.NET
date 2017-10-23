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
            Validate.NotNullOrEmpty(conditions, nameof(conditions));
            Validate.NotNullOrEmpty(conclusions, nameof(conclusions));

            this.Label = Label.Create(label);
            this.conditions = conditions;
            this.conclusions = conclusions;
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
        /// A <see cref="bool"/>.
        /// </returns>
        public bool Evaluate(IDictionary<Label, double> data) => this.Conditions.All(c => c.Evaluate(data));
    }
}