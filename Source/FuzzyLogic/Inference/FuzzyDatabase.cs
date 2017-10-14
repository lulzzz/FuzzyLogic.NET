// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyDatabase.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Inference
{
    using System.Collections.Generic;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The fuzzy database.
    /// </summary>
    public class FuzzyDatabase
    {
        private readonly Dictionary<string, LinguisticVariable> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyDatabase"/> class.
        /// </summary>
        /// <param name="variables">
        /// The dictionary of variables.
        /// </param>
        public FuzzyDatabase(Dictionary<string, LinguisticVariable> variables)
        {
            Validate.NotNull(variables, nameof(variables));

            this.variables = variables;
        }

        /// <summary>
        /// Returns the <see cref="LinguisticVariable"/> of the given variable name.
        /// </summary>
        /// <param name="variableName">
        /// The variable name.
        /// </param>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        public LinguisticVariable GetVariable(string variableName)
        {
            return this.variables[variableName];
        }

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the <see cref="FuzzyDatabase"/>
        /// contains the variable.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ContainsVariable(LinguisticVariable variable)
        {
            return this.variables.ContainsValue(variable);
        }
    }
}