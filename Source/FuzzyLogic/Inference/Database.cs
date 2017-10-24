// -------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" author="Christopher Sellers">
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
    /// The sealed <see cref="Database"/> class.
    /// </summary>
    internal sealed class Database
    {
        private readonly IDictionary<Label, double> variableData = new Dictionary<Label, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            Validate.NotNull(this.variableData, nameof(this.variableData));
        }

        /// <summary>
        /// Returns an <see cref="IReadOnlyCollection{T}"/> of <see cref="LinguisticVariable"/> names.
        /// </summary>
        public IReadOnlyCollection<Label> Variables => this.variableData.Keys.ToList().AsReadOnly();

        /// <summary>
        /// Returns the count of variable labels held within the <see cref="Database"/>.
        /// </summary>
        public int VariableCount => this.variableData.Count;

        /// <summary>
        /// Adds the input label to the database.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the same name is already contained
        /// within the database.
        /// </exception>
        public void AddVariable(Label variable, double input = 0)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotOutOfRange(input, nameof(input));
            Validate.DictionaryDoesNotContainKey(variable, nameof(variable), this.variableData);

            this.variableData.Add(variable, input);
        }

        /// <summary>
        /// Updates the <see cref="Database"/> with the input <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the input <see cref="LinguisticVariable"/> if not found within the <see cref="Database"/>.
        /// </exception>
        public void DeleteVariable(Label variable)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.DictionaryContainsKey(variable, nameof(variable), this.variableData);

            this.variableData.Remove(variable);
        }

        /// <summary>
        /// Clears all <see cref="LinguisticVariable"/> elements in the <see cref="Database"/>.
        /// </summary>
        public void DeleteAllVariables()
        {
            this.variableData.Clear();
        }

        /// <summary>
        /// Returns a <see cref="bool"/> indicating whether the <see cref="Database"/>
        /// contains the input <see cref="LinguisticVariable"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public bool ContainsVariable(Label variable)
        {
            Validate.NotNull(variable, nameof(variable));

            return this.variableData.ContainsKey(variable);
        }

        /// <summary>
        /// Updates the <see cref="LinguisticVariable"/> data with the given <see cref="double"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <param name="input">
        /// The input data.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input label is not contained within the database.
        /// </exception>
        public void Update(Label variable, double input)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.NotOutOfRange(input, nameof(input));
            Validate.DictionaryContainsKey(variable, nameof(variable), this.variableData);

            this.variableData[variable] = input;
        }

        /// <summary>
        /// Returns the current input <see cref="double"/> of the given <see cref="Label"/>.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the input label is not contained within the database.
        /// </exception>
        public double GetData(Label variable)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.DictionaryContainsKey(variable, nameof(variable), this.variableData);

            return this.variableData[variable];
        }

        /// <summary>
        /// Returns all data contained within the <see cref="Database"/> as a list of <see cref="ValueTuple"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="IList{ValueType}"/>.
        /// </returns>
        public IList<(Label variable, double data)> GetAllData()
        {
            return this.variableData.Select(variable => (variable.Key, variable.Value)).ToList();
        }
    }
}