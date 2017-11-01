// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyEvaluator.cs" author="Christopher Sellers">
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
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Logic;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable sealed <see cref="FuzzyEvaluator"/> class.
    /// </summary>
    [Immutable]
    public sealed class FuzzyEvaluator
    {
        private readonly ITriangularNorm triangularNorm;
        private readonly ITriangularConorm triangularConorm;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyEvaluator"/> class.
        /// </summary>
        public FuzzyEvaluator()
        {
            this.triangularNorm = TriangularNormFactory.MinimumTNorm();
            this.triangularConorm = TriangularConormFactory.MaximumTConorm();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyEvaluator"/> class.
        /// </summary>
        /// <param name="tnorm">
        /// The t-norm function.
        /// </param>
        /// <param name="tconorm">
        /// The t-conorm function.
        /// </param>
        public FuzzyEvaluator(ITriangularNorm tnorm, ITriangularConorm tconorm)
        {
            Validate.NotNull(tnorm, nameof(tnorm));
            Validate.NotNull(tconorm, nameof(tconorm));

            this.triangularNorm = tnorm;
            this.triangularConorm = tconorm;
        }

        /// <summary>
        /// Returns the result of an evaluation of two membership values separated by an 'AND'.
        /// </summary>
        /// <param name="membershipA">
        /// The membership value A.
        /// </param>
        /// <param name="membershipB">
        /// The membership value V.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        [Pure]
        public UnitInterval And(UnitInterval membershipA, UnitInterval membershipB)
        {
            return this.triangularNorm.Evaluate(membershipA, membershipB);
        }

        /// <summary>
        /// The and.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public UnitInterval And(IEnumerable<UnitInterval> input)
        {
            Validate.NotNull(input, nameof(input));

            return input.Aggregate(this.And);
        }

        /// <summary>
        /// The or.
        /// </summary>
        /// <param name="membershipA">
        /// The membership a.
        /// </param>
        /// <param name="membershipB">
        /// The membership b.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        [Pure]
        public UnitInterval Or(UnitInterval membershipA, UnitInterval membershipB)
        {
            return this.triangularConorm.Evaluate(membershipA, membershipB);
        }

        /// <summary>
        /// The or.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public UnitInterval Or(IEnumerable<UnitInterval> input)
        {
            Validate.NotNull(input, nameof(input));

            return input.Aggregate(this.Or);
        }

        /// <summary>
        /// Returns the result of the aggregated evaluation of the given collection of evaluations.
        /// </summary>
        /// <param name="evaluations">
        /// The evaluations.
        /// </param>
        /// <returns>
        /// A <see cref="UnitInterval"/>.
        /// </returns>
        public UnitInterval Evaluate(IEnumerable<Evaluation> evaluations)
        {
            var statementCount = 0;
            var statements = new Dictionary<int, IList<UnitInterval>> { { statementCount, new List<UnitInterval>() } };

            foreach (var evaluation in evaluations)
            {
                if (evaluation.Connective.Equals(LogicOperators.And())
                 || evaluation.Connective.Equals(LogicOperators.If()))
                {
                    statements[statementCount].Add(evaluation.Result);
                }

                if (evaluation.Connective.Equals(LogicOperators.Or()))
                {
                    statementCount++;
                    statements.Add(statementCount, new List<UnitInterval>());
                    statements[statementCount].Add(evaluation.Result);
                }
            }

            return this.Or(statements
                .Select(statement => this.And(statement.Value))
                .ToList());
        }
    }
}