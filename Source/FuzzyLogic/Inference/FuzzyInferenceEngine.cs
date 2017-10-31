// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyInferenceEngine.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The abstract <see cref="FuzzyInferenceEngine"/> class.
    /// </summary>
    public abstract class FuzzyInferenceEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyInferenceEngine"/> class.
        /// </summary>
        /// <param name="tnorm">
        /// The t-norm function.
        /// </param>
        /// <param name="tconorm">
        /// The t-conorm function.
        /// </param>
        protected FuzzyInferenceEngine(ITriangularNorm tnorm, ITriangularConorm tconorm)
        {
            Validate.NotNull(tnorm, nameof(tnorm));
            Validate.NotNull(tconorm, nameof(tconorm));

            this.TNorm = tnorm;
            this.TConorm = tconorm;

            this.Database = new Database();
            this.Rulebase = new Rulebase();
        }

        /// <summary>
        /// Gets the t-norm function.
        /// </summary>
        protected ITriangularNorm TNorm { get; }

        /// <summary>
        /// Gets the t-conorm function.
        /// </summary>
        protected ITriangularConorm TConorm { get; }

        /// <summary>
        /// Gets the database.
        /// </summary>
        protected Database Database { get; }

        /// <summary>
        /// Gets the rule base.
        /// </summary>
        protected Rulebase Rulebase { get; }
    }
}