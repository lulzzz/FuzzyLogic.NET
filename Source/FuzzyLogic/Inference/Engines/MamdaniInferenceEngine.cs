// -------------------------------------------------------------------------------------------------
// <copyright file="MamdaniInferenceEngine.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

using FuzzyLogic.BinaryOperations;

namespace FuzzyLogic.Inference
{
    /// <summary>
    /// The sealed <see cref="MamdaniInferenceEngine"/> class.
    /// </summary>
    public sealed class MamdaniInferenceEngine : FuzzyInferenceEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MamdaniInferenceEngine"/> class.
        /// </summary>
        /// <param name="tnorm">
        /// The t-norm function.
        /// </param>
        /// <param name="tconorm">
        /// The t-conorm function.
        /// </param>
        public MamdaniInferenceEngine(
            ITriangularNorm tnorm, 
            ITriangularConorm tconorm) 
            : base(tnorm, tconorm)
        {
        }
    }
}