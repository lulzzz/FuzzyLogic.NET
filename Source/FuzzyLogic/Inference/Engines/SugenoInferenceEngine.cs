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
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Defuzzification;
    using FuzzyLogic.Inference.Engines.Base;

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
        /// <param name="defuzzifier">
        /// The de-fuzzifier.
        /// </param>
        public SugenoInferenceEngine(
            ITriangularNorm tnorm,
            ITriangularConorm tconorm,
            IDefuzzifier defuzzifier)
            : base(tnorm, tconorm, defuzzifier)
        {
        }

        /// <summary>
        /// Returns a list of the outputs computed from the inference engine.
        /// </summary>
        /// <returns>
        /// A <see cref="IList{DataPoint}"/>.
        /// </returns>
        public IList<Output> Compute()
        {
            var data = this.Database.GetAllDataLabeled();
            var rules = this.Rulebase.GetAllRules();

            var fuzzyOutputs = GroupFuzzyOutputs(EvaluateRules(rules, data, this.Evaluator));

            return fuzzyOutputs
                .Select(fuzzyOutputGroup => this.Defuzzifier.Defuzzify(fuzzyOutputGroup.Value))
                .ToList();
        }
    }
}