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
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyEvaluator"/> class.
        /// </summary>
        public FuzzyEvaluator()
        {
            this.TNorm = TriangularNormFactory.MinimumTNorm();
            this.TConorm = TriangularConormFactory.MaximumTConorm();
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

            this.TNorm = tnorm;
            this.TConorm = tconorm;
        }

        /// <summary>
        /// Gets the t-norm.
        /// </summary>
        public ITriangularNorm TNorm { get; }

        /// <summary>
        /// Gets the t-conorm.
        /// </summary>
        public ITriangularConorm TConorm { get; }

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
            return this.TNorm.Evaluate(membershipA, membershipB);
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
            return this.TConorm.Evaluate(membershipA, membershipB);
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
        /// A <see cref="double"/>.
        /// </returns>
        public UnitInterval Evaluate(List<Evaluation> evaluations)
        {
            var allIfAndResults = evaluations
                .Where(e => e.Connective.Equals(LogicOperators.If()) || e.Connective.Equals(LogicOperators.And()))
                .Select(e => e.Result);

            var ifAndAggregate = this.And(allIfAndResults);

            var orAggregate = UnitInterval.Zero();

            if (evaluations.Exists(e => e.Connective.Equals(LogicOperators.Or())))
            {
                var allOrResults = evaluations
                    .Where(e => e.Connective.Equals(LogicOperators.Or()))
                    .Select(e => e.Result);

                orAggregate = this.Or(allOrResults);
            }

            return this.Or(ifAndAggregate, orAggregate);
        }
    }
}