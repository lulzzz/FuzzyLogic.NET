// -------------------------------------------------------------------------------------------------
// <copyright file="Proposition.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using System;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Logic.Operators;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy rule proposition.
    /// </summary>
    [Immutable]
    public abstract class Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Proposition"/> class.
        /// </summary>
        /// <param name="connectiveA">
        /// The connective A.
        /// </param>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="connectiveB">
        /// The connective B.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        protected Proposition(
            ILogicOperator connectiveA,
            LinguisticVariable variable,
            ILogicOperator connectiveB,
            string condition)
        {
            Validate.NotNull(connectiveA, nameof(connectiveB));
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(condition, nameof(condition));

            this.ConnectiveA = connectiveA;
            this.Variable = variable;
            this.ConnectiveB = connectiveB;
            this.Condition = condition.ToLower();

            this.ValidateProposition();
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public ILogicOperator ConnectiveA { get; }

        /// <summary>
        /// Gets the variable.
        /// </summary>
        public LinguisticVariable Variable { get; }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public ILogicOperator ConnectiveB { get; }

        /// <summary>
        /// Gets the label.
        /// </summary>
        public string Condition { get; }

        private void ValidateProposition()
        {
            if (!this.Variable.IsMember(this.Condition))
            {
                throw new ArgumentException($"Invalid condition (the condition '{this.Condition}' is not a member of the variable '{this.Variable.Name}').");
            }
        }
    }
}