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
    using System.Collections.ObjectModel;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Utility;

    /// <summary>
    /// The sealed <see cref="Database"/> class.
    /// </summary>
    public sealed class Database
    {
        private readonly IDictionary<Label, DataPoint> variableData = new Dictionary<Label, DataPoint>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            Validate.NotNull(this.variableData, nameof(this.variableData));
        }

        /// <summary>
        /// Returns the count of variable labels held within the <see cref="Database"/>.
        /// </summary>
        public int VariableCount => this.variableData.Count;

        /// <summary>
        /// Returns an <see cref="IReadOnlyCollection{T}"/> of <see cref="LinguisticVariable"/> names.
        /// </summary>
        /// <returns>
        /// A <see cref="IReadOnlyCollection{Label}"/>.
        /// </returns>
        public IReadOnlyList<Label> VariableNames() => new List<Label>(this.variableData.Keys).AsReadOnly();

        /// <summary>
        /// Returns all data contained within the <see cref="Database"/> as a read only dictionary.
        /// </summary>
        /// <returns>
        /// A <see cref="IReadOnlyCollection{DataPoint}"/>.
        /// </returns>
        public IReadOnlyList<DataPoint> GetAllData() => new List<DataPoint>(this.variableData.Values).AsReadOnly();

        /// <summary>
        /// Returns all data contained within the <see cref="Database"/> as a read only dictionary.
        /// </summary>
        /// <returns>
        /// A <see cref="IReadOnlyDictionary{Label, DataPoint}"/>.
        /// </returns>
        public IReadOnlyDictionary<Label, DataPoint> GetAllDataLabeled() => new ReadOnlyDictionary<Label, DataPoint>(this.variableData);

        /// <summary>
        /// Evaluates whether the variable is contained within the database.
        /// </summary>
        /// <param name="variable">
        /// The variable name.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/>.
        /// </returns>
        public bool ContainsVariable(string variable)
        {
            Validate.NotNull(variable, nameof(variable));

            return this.ContainsVariable(Label.Create(variable));
        }

        /// <summary>
        /// Evaluates whether the variable is contained within the database.
        /// </summary>
        /// <param name="variable">
        /// The variable name.
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
        /// Adds the input label to the database.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <param name="input">
        /// The input value.
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

            this.variableData.Add(variable, new DataPoint(variable, input));
        }

        /// <summary>
        /// Updates the data point for that variable within the database.
        /// </summary>
        /// <param name="input">
        /// The input data point.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the variable label has not been added to the database.
        /// </exception>
        public void UpdateData(DataPoint input)
        {
            Validate.NotNull(input, nameof(input));
            Validate.DictionaryContainsKey(input.Variable, nameof(input.Variable), this.variableData);

            this.variableData[input.Variable] = input;
        }

        /// <summary>
        /// Returns the held data point matching the given variable label.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <returns>
        /// A <see cref="DataPoint"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws an exception if a variable with the given variable label is not contained within the database.
        /// </exception>
        public DataPoint GetData(Label variable)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.DictionaryContainsKey(variable, nameof(variable), this.variableData);

            return this.variableData[variable];
        }

        /// <summary>
        /// Deletes the variable label and associated data point from the database.
        /// </summary>
        /// <param name="variable">
        /// The variable label.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws an exception if the given variable label is not found within the database.
        /// </exception>
        public void DeleteVariable(Label variable)
        {
            Validate.NotNull(variable, nameof(variable));
            Validate.DictionaryContainsKey(variable, nameof(variable), this.variableData);

            this.variableData.Remove(variable);
        }

        /// <summary>
        /// Clears all variable labels and data points in the database.
        /// </summary>
        public void DeleteAllVariables()
        {
            this.variableData.Clear();
        }
    }
}