// -------------------------------------------------------------------------------------------------
// <copyright file="SugenoInferenceEngine.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference.Engines
{
    using FuzzyLogic.BinaryOperations;

    /// <summary>
    /// The sealed <see cref="SugenoInferenceEngine"/> class.
    /// </summary>
    public sealed class SugenoInferenceEngine : FuzzyInferenceEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SugenoInferenceEngine"/> class.
        /// </summary>
        /// <param name="tnorm">
        /// The t-norm function.
        /// </param>
        /// <param name="tconorm">
        /// The t-conorm function.
        /// </param>
        public SugenoInferenceEngine(
            ITriangularNorm tnorm,
            ITriangularConorm tconorm)
            : base(tnorm, tconorm)
        {
        }
    }
}