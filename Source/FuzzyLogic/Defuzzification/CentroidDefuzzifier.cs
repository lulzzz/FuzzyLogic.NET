// -------------------------------------------------------------------------------------------------
// <copyright file="CentroidDefuzzifier.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Defuzzification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FuzzyLogic.Annotations;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Inference;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The immutable <see cref="CentroidDefuzzifier"/> class.
    /// </summary>
    [Immutable]
    public class CentroidDefuzzifier : IDefuzzifier
    {
        private readonly int decimalAccuracy;

        /// <summary>
        /// Initializes a new instance of the <see cref="CentroidDefuzzifier"/> class.
        /// </summary>
        /// <param name="decimalAccuracy">
        /// The decimal accuracy (for rounding of the result).
        /// </param>
        public CentroidDefuzzifier(int decimalAccuracy = 5)
        {
            Validate.NotOutOfRange(decimalAccuracy, nameof(decimalAccuracy), 1, 15);

            this.decimalAccuracy = decimalAccuracy;
        }

        /// <summary>
        /// Returns an output as a result of de-fuzzification.
        /// </summary>
        /// <param name="fuzzyOutputs">
        /// The fuzzy outputs.
        /// </param>
        /// <returns>
        /// An <see cref="Output"/>.
        /// </returns>
        public Output Defuzzify(IList<FuzzyOutput> fuzzyOutputs)
        {
            Validate.CollectionNotNullOrEmpty(fuzzyOutputs, nameof(fuzzyOutputs));

            if (fuzzyOutputs.Any(o => o.Subject != fuzzyOutputs[0].Subject))
            {
                throw new InvalidOperationException(
                    "Invalid Defuzzification (not all subjects in provided fuzzy outputs are equal).");
            }

            var totalWeight = 0.0;
            var totalMembership = 0.0;

            foreach (var point in GetAllFuzzyPoints(fuzzyOutputs))
            {
                var maxMembershipAtPoint = fuzzyOutputs
                    .Select(output => Math.Min(output.OutputFunction.GetMembership(point.X).Value, output.FiringStrength.Value))
                    .Concat(new[] { 0.0 })
                    .Max();

                totalWeight += point.X * maxMembershipAtPoint;
                totalMembership += maxMembershipAtPoint;
            }

            var result = Math.Round(totalWeight / totalMembership, this.decimalAccuracy);

            return new Output(fuzzyOutputs[0].Subject, result);
        }

        private static IList<FuzzyPoint> GetAllFuzzyPoints(IList<FuzzyOutput> fuzzyOutputs)
        {
            return fuzzyOutputs
                .SelectMany(o => o.OutputFunction.GetPoints())
                .OrderBy(o => o.X)
                .ToList();
        }
    }
}