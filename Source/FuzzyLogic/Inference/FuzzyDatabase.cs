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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FuzzyLogic.Utility;

    /// <summary>
    /// The <see cref="FuzzyDatabase"/> class.
    /// </summary>
    public class FuzzyDatabase
    {
        private readonly IDictionary<string, LinguisticVariable> variables = new Dictionary<string, LinguisticVariable>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyDatabase"/> class.
        /// </summary>
        public FuzzyDatabase()
        {
            Validate.NotNull(this.variables, nameof(this.variables));
        }

        /// <summary>
        /// Returns an <see cref="IReadOnlyCollection{T}"/> of <see cref="LinguisticVariable"/> names.
        /// </summary>
        public IReadOnlyCollection<string> VariableNames => this.variables.Keys.ToList().AsReadOnly();

        /// <summary>
        /// Returns the count of <see cref="LinguisticVariable"/> in the <see cref="FuzzyDatabase"/>.
        /// </summary>
        public int VariableCount => this.variables.Count;

        /// <summary>
        /// Adds the input variable to the database.
        /// </summary>
        /// <param name="variable">
        /// The input <see cref="LinguisticVariable"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the same name is already contained
        /// within the database.
        /// </exception>
        public void Add(LinguisticVariable variable)
        {
            if (this.variables.ContainsKey(variable.Name))
            {
                throw new ArgumentException($"Cannot add linguistic variable. Fuzzy database already contains a rule named {variable.Name}");
            }

            this.variables.Add(variable.Name, variable);
        }

        /// <summary>
        /// Updates the database with the input variable.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input name is not contained
        /// within the database.
        /// </exception>
        public void Update(LinguisticVariable variable)
        {
            if (!this.variables.ContainsKey(variable.Name))
            {
                throw new ArgumentException($"Cannot update linguistic variable. Fuzzy database does not contain a variable named {variable.Name}.");
            }

            this.variables[variable.Name] = variable;
        }

        /// <summary>
        /// Updates the <see cref="FuzzyDatabase"/> with the input <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the input <see cref="LinguisticVariable"/> if not found within the <see cref="FuzzyDatabase"/>.
        /// </exception>
        public void Delete(LinguisticVariable variable)
        {
            if (!this.variables.ContainsKey(variable.Name))
            {
                throw new ArgumentException($"Cannot delete linguistic variable. Fuzzy database does not contain a variable named {variable.Name}.");
            }

            this.variables.Remove(variable.Name);
        }

        /// <summary>
        /// Clears all <see cref="LinguisticVariable"/> elements in the <see cref="FuzzyDatabase"/>.
        /// </summary>
        public void DeleteAll()
        {
            this.variables.Clear();
        }

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the <see cref="FuzzyDatabase"/>
        /// contains the input <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ContainsVariable(LinguisticVariable variable)
        {
            return this.variables.ContainsKey(variable.Name);
        }

        /// <summary>
        /// Returns the <see cref="LinguisticVariable"/> from the <see cref="FuzzyDatabase"/>.
        /// </summary>
        /// <param name="variableName">
        /// The variable name.
        /// </param>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input name is not contained
        /// within the database.
        /// </exception>
        public LinguisticVariable GetVariable(string variableName)
        {
            Validate.NotNull(variableName, nameof(variableName));

            if (!this.variables.ContainsKey(variableName))
            {
                throw new ArgumentException($"Cannot get linguistic variable. Fuzzy database does not contain a variable named {variableName}");
            }

            return this.variables[variableName];
        }
    }
}