// -------------------------------------------------------------------------------------------------
// <copyright file="IDefuzzifier.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Defuzzification
{
    using System.Collections.Generic;
    using FuzzyLogic.Inference;

    /// <summary>
    /// The <see cref="IDefuzzifier"/> interface.
    /// </summary>
    public interface IDefuzzifier
    {
        /// <summary>
        /// Returns a single crisp value based on the given fuzzy output collection.
        /// </summary>
        /// <param name="fuzzyOutputs">
        /// The fuzzy outputs collection.
        /// </param>
        /// <returns>
        /// An <see cref="Output"/>.
        /// </returns>
        Output Defuzzify(IList<FuzzyOutput> fuzzyOutputs);
    }
}