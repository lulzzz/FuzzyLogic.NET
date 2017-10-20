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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    using static Logic.LogicOperators;

    /// <summary>
    /// The fuzzy rule.
    /// </summary>
    [Immutable]
    public class FuzzyRule
    {
        private readonly IList<ICondition> premises;

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
        public FuzzyRule(string name, ICondition premise, Conclusion conclusion)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(premise, nameof(premise));
            Validate.NotNull(conclusion, nameof(conclusion));

            this.Name = name;
            this.premises = new List<ICondition> { premise };
            this.Conclusion = conclusion;

            this.ValidateFuzzyRule();
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
        public FuzzyRule(string name, IList<ICondition> premises, Conclusion conclusion)
        {
            Validate.NotNull(name, nameof(name));
            Validate.NotNull(premises, nameof(premises));
            Validate.NotNull(conclusion, nameof(conclusion));

            this.Name = name;
            this.premises = premises;
            this.Conclusion = conclusion;
        }

        /// <summary>
        /// Gets the rule name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The premises.
        /// </summary>
        public IReadOnlyCollection<ICondition> Premises => this.premises.ToList().AsReadOnly();

        /// <summary>
        /// Gets the conclusion.
        /// </summary>
        public Conclusion Conclusion { get; }

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate() => this.premises.All(p => p.Evaluate());

        private void ValidateFuzzyRule()
        {
            if (this.premises.Count == 0)
            {
                throw new ArgumentException(
                    "Invalid premises (the list of premise cannot be empty).");
            }

            if (this.premises[0].Connective != If())
            {
                throw new ArgumentException(
                    $"Invalid connective (the first premise must be an IF) = {this.premises[0].Connective}.");
            }
        }
    }
}