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
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy rule.
    /// </summary>
    [Immutable]
    public class FuzzyRule
    {
        private readonly IList<Premise> premises;
        private readonly Conclusion conclusion;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRule"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="premise">
        /// The premise.
        /// </param>
        /// <param name="conclusion">
        /// The conclusion.
        /// </param>
        private FuzzyRule(string name, Premise premise, Conclusion conclusion)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(premise, nameof(premise));
            Validate.NotNull(conclusion, nameof(conclusion));

            this.Name = name;
            this.premises = new List<Premise> { premise };
            this.conclusion = conclusion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRule"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="premises">
        /// The premises.
        /// </param>
        /// <param name="conclusion">
        /// The conclusion.
        /// </param>
        private FuzzyRule(string name, IList<Premise> premises, Conclusion conclusion)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(premises, nameof(premises));
            Validate.NotNull(conclusion, nameof(conclusion));

            this.Name = name;
            this.premises = premises;
            this.conclusion = conclusion;
        }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public string Name { get; }
    }
}