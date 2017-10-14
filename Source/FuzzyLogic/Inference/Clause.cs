// -------------------------------------------------------------------------------------------------
// <copyright file="Clause.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="Clause"/> immutable class.
    /// </summary>
    public class Clause
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clause"/> class.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="fuzzySet">
        /// The fuzzySet.
        /// </param>
        public Clause(LinguisticVariable variable, FuzzySet fuzzySet)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotNull(fuzzySet, nameof(fuzzySet));

            this.Variable = variable;
            this.FuzzySet = fuzzySet;
        }

        /// <summary>
        /// Gets the <see cref="LinguisticVariable"/> of the <see cref="Clause"/>.
        /// </summary>
        public LinguisticVariable Variable { get; }

        /// <summary>
        /// Gets the <see cref="FuzzyLogic.FuzzySet"/> of the <see cref="Clause"/>.
        /// </summary>
        public FuzzySet FuzzySet { get; }

        /// <summary>
        /// Returns the membership value of the given evaluate input.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Evaluate(double input)
        {
            return this.FuzzySet.GetMembership(input);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Variable.Name + " IS " + this.FuzzySet.Name;
        }
    }
}
