// -------------------------------------------------------------------------------------------------
// <copyright file="Premise.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic
{
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Inference;
    using FuzzyLogic.Logic.Interfaces;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The premise.
    /// </summary>
    [Immutable]
    public class Premise : Proposition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Premise"/> class.
        /// </summary>
        /// <param name="connective">
        /// The connective.
        /// </param>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <param name="query">
        /// The query.
        /// </param>
        public Premise(
            IConnectiveOperator connective,
            LinguisticVariable variable,
            IEvaluationOperator evaluator,
            FuzzyQuery query)
            : base(variable, evaluator, query.QueriedState)
        {
            Validate.NotNull(connective, nameof(connective));
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(query, nameof(query));

            this.Connective = connective;
            this.Query = query;
        }

        /// <summary>
        /// Gets the connective.
        /// </summary>
        public IConnectiveOperator Connective { get; }

        /// <summary>
        /// Gets the query.
        /// </summary>
        public FuzzyQuery Query { get; }

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Evaluate() => this.Query.Evaluate();

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => $"{this.Connective} {this.Variable.Label} {this.Evaluator} {this.State}";
    }
}