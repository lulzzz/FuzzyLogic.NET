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
    public sealed class FuzzyDatabase
    {
        private readonly IDictionary<Label, LinguisticVariable> variables = new Dictionary<Label, LinguisticVariable>();

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
        public IReadOnlyCollection<Label> VariableNames => this.variables.Keys.ToList().AsReadOnly();

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
            Validate.NotNull(variable, nameof(variable));

            if (this.variables.ContainsKey(variable.Label))
            {
                throw new ArgumentException($"Cannot add linguistic variable (Fuzzy database already contains a rule named {variable.Label}).");
            }

            this.variables.Add(variable.Label, variable);
        }

        /// <summary>
        /// Replaces the input variable in the database with the input variable given.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input name is not contained
        /// within the database.
        /// </exception>
        public void Replace(LinguisticVariable variable)
        {
            Validate.NotNull(variable, nameof(variable));

            if (!this.variables.ContainsKey(variable.Label))
            {
                throw new ArgumentException($"Cannot update linguistic variable (Fuzzy database does not contain a variable named {variable.Label}).");
            }

            this.variables[variable.Label] = variable;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="label">
        /// The label.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input name is not contained
        /// within the database.
        /// </exception>
        public void Update(Label label, double input)
        {
            Validate.NotNull(label, nameof(label));
            Validate.NotOutOfRange(input, nameof(input));

            if (!this.variables.ContainsKey(label))
            {
                throw new ArgumentException($"Cannot update linguistic variable (Fuzzy database does not contain a variable named {label}).");
            }
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
            Validate.NotNull(variable, nameof(variable));

            if (!this.variables.ContainsKey(variable.Label))
            {
                throw new ArgumentException($"Cannot delete linguistic variable (Fuzzy database does not contain a variable named {variable.Label}).");
            }

            this.variables.Remove(variable.Label);
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
            Validate.NotNull(variable, nameof(variable));

            return this.variables.ContainsKey(variable.Label);
        }

        /// <summary>
        /// Returns the <see cref="LinguisticVariable"/> from the <see cref="FuzzyDatabase"/>.
        /// </summary>
        /// <param name="label">
        /// The variable name.
        /// </param>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input name is not contained
        /// within the database.
        /// </exception>
        public LinguisticVariable GetVariable(Label label)
        {
            Validate.NotNull(label, nameof(label));

            if (!this.variables.ContainsKey(label))
            {
                throw new ArgumentException($"Cannot get linguistic variable (Fuzzy database does not contain a variable named {label}).");
            }

            return this.variables[label];
        }
    }
}