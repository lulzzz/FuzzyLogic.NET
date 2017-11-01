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
        /// The membership value B.
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
        /// The or.
        /// </summary>
        /// <param name="membershipA">
        /// The membership value A.
        /// </param>
        /// <param name="membershipB">
        /// The membership value B.
        /// </param>
        /// <returns>
        /// A <see cref="double"/>.
        /// </returns>
        [Pure]
        public UnitInterval Or(UnitInterval membershipA, UnitInterval membershipB)
        {
            return this.triangularConorm.Evaluate(membershipA, membershipB);
        }

        /// <summary>
        /// Returns the final evaluation result of the aggregated collection of evaluations.
        /// </summary>
        /// <param name="evaluations">
        /// The evaluations.
        /// </param>
        /// <returns>
        /// A <see cref="UnitInterval"/>.
        /// </returns>
        public UnitInterval Evaluate(IEnumerable<Evaluation> evaluations)
        {
            var result = UnitInterval.One();

            foreach (var evaluation in evaluations)
            {
                if (evaluation.Connective.Equals(LogicOperators.And())
                 || evaluation.Connective.Equals(LogicOperators.If()))
                {
                    result = this.And(result, evaluation.Result);
                }

                if (evaluation.Connective.Equals(LogicOperators.Or()))
                {
                    result = this.Or(result, evaluation.Result);
                }
            }

            return result;
        }
    }
}