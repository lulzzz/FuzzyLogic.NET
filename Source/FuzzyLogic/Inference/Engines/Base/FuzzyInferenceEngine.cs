// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyInferenceEngine.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference.Engines.Base
{
    using System.Collections.Generic;
    using FuzzyLogic.BinaryOperations;
    using FuzzyLogic.Defuzzification;
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
        /// <param name="defuzzifier">
        /// The de-fuzzifier.
        /// </param>
        protected FuzzyInferenceEngine(
            ITriangularNorm tnorm,
            ITriangularConorm tconorm,
            IDefuzzifier defuzzifier)
        {
            Validate.NotNull(tnorm, nameof(tnorm));
            Validate.NotNull(tconorm, nameof(tconorm));
            Validate.NotNull(defuzzifier, nameof(defuzzifier));

            this.Database = new Database();
            this.Rulebase = new Rulebase();
            this.Evaluator = new FuzzyEvaluator(tnorm, tconorm);

            this.TNorm = tnorm;
            this.TConorm = tconorm;
            this.Defuzzifier = defuzzifier;
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        public Database Database { get; }

        /// <summary>
        /// Gets the rule base.
        /// </summary>
        public Rulebase Rulebase { get; }

        /// <summary>
        /// Gets the fuzzy evaluator.
        /// </summary>
        public FuzzyEvaluator Evaluator { get; }

        /// <summary>
        /// Gets the t-norm function.
        /// </summary>
        public ITriangularNorm TNorm { get; }

        /// <summary>
        /// Gets the t-conorm function.
        /// </summary>
        public ITriangularConorm TConorm { get; }

        /// <summary>
        /// Gets the de-fuzzifier.
        /// </summary>
        public IDefuzzifier Defuzzifier { get; }

        /// <summary>
        /// Returns the evaluation of all fuzzy rules in the <see cref="Rulebase"/>.
        /// </summary>
        /// <param name="rules">
        /// The fuzzy rules.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="evaluator">
        /// The evaluator.
        /// </param>
        /// <returns>
        /// A <see cref="IList{T}"/>.
        /// </returns>
        protected static IList<FuzzyOutput> EvaluateRules(
            IEnumerable<FuzzyRule> rules,
            IReadOnlyDictionary<Label, DataPoint> data,
            FuzzyEvaluator evaluator)
        {
            var fuzzyOutputs = new List<FuzzyOutput>();

            foreach (var rule in rules)
            {
                var ruleOutputs = rule.Evaluate(data, evaluator);

                ruleOutputs.ForEach(o => fuzzyOutputs.Add(o));
            }

            return fuzzyOutputs;
        }

        /// <summary>
        /// Returns a dictionary which has grouped all fuzzy outputs by variable label.
        /// </summary>
        /// <param name="fuzzyOutputs">
        /// The fuzzy outputs.
        /// </param>
        /// <returns>
        /// A <see cref="IDictionary{T, T}"/>.
        /// </returns>
        protected static Dictionary<Label, IList<FuzzyOutput>> GroupFuzzyOutputs(
            IEnumerable<FuzzyOutput> fuzzyOutputs)
        {
            var groupedFuzzyOutputs = new Dictionary<Label, IList<FuzzyOutput>>();

            foreach (var output in fuzzyOutputs)
            {
                if (!groupedFuzzyOutputs.ContainsKey(output.Subject))
                {
                    groupedFuzzyOutputs.Add(output.Subject, new List<FuzzyOutput>());
                }

                groupedFuzzyOutputs[output.Subject].Add(output);
            }

            return groupedFuzzyOutputs;
        }
    }
}