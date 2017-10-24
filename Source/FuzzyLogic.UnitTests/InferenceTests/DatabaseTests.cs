// -------------------------------------------------------------------------------------------------
// <copyright file="DatabaseTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.InferenceTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class DatabaseTests
    {
        [Fact]
        internal void AddVariable_WhenVariableNotAlreadyInDatabase_AddsExpectedVariableToDatabase()
        {
            // Arrange
            var database = new Database();
            var label = Label.Create("pressure");

            // Act
            database.AddVariable(label, 3000);

            // Assert
            Assert.Equal(1, database.VariableCount);
        }

        [Fact]
        internal void ContainsVariable_WhenVariableNotContainedWithinDatabase_ReturnsFalse()
        {
            // Arrange
            var database = new Database();
            var label = Label.Create("pressure");

            // Act
            var result = database.ContainsVariable(label);

            // Assert
            Assert.False(result);
        }

        [Fact]
        internal void ContainsVariable_WhenVariableContainedWithinDatabase_ReturnsTrue()
        {
            // Arrange
            var database = new Database();
            var label = Label.Create("pressure");
            database.AddVariable(label, 3000);

            // Act
            var result = database.ContainsVariable(label);

            // Assert
            Assert.True(result);
        }

        [Fact]
        internal void DeleteVariable_WhenVariableContainedWithinDatabase_ReturnsExpectedResultWhenQueried()
        {
            // Arrange
            var database = new Database();
            var label = Label.Create("pressure");
            database.AddVariable(label, 3000);
            var result1 = database.ContainsVariable(label);

            // Act
            database.DeleteVariable(label);
            var result2 = database.ContainsVariable(label);

            // Assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.Equal(0, database.VariableCount);
        }

        [Fact]
        internal void DeleteAllVariables_WhenVariablesContainedWithinDatabase_ReturnsVariableCountZero()
        {
            // Arrange
            var database = new Database();
            var label1 = Label.Create("pressure");
            var label2 = Label.Create("temperature");
            var label3 = Label.Create("pump1");

            database.AddVariable(label1, 3000);
            database.AddVariable(label2, 25);
            database.AddVariable(label3, 199);

            // Tests the variables were added
            var result1 = database.VariableCount;

            // Act
            database.DeleteAllVariables();
            var result2 = database.VariableCount;

            // Assert
            Assert.Equal(3, result1);
            Assert.Equal(0, result2);
        }

        [Fact]
        internal void Variables_WhenVariablesContainedWithinDatabase_ReturnsExpectedList()
        {
            // Arrange
            var database = new Database();
            var label1 = Label.Create("pressure");
            var label2 = Label.Create("temperature");
            var label3 = Label.Create("pump1");

            database.AddVariable(label1, 3000);
            database.AddVariable(label2, 25);
            database.AddVariable(label3, 199);

            var expectedList = new List<Label> { label1, label2, label3 };

            // Act
            var result = database.Variables;

            // Assert
            Assert.Equal(expectedList, result);
        }

        [Fact]
        internal void GetData_WhenVariableContainedWithinDatabase_ThenReturnsExpectedData()
        {
            // Arrange
            var database = new Database();
            var pressure = Label.Create("pressure");

            database.AddVariable(pressure, 3000);

            // Act
            database.Update(pressure, 3001);
            var result = database.GetData(pressure);

            // Assert
            Assert.Equal(3001, result);
        }

        [Fact]
        internal void Update_WhenVariableContainedWithinDatabase_ThenReturnsExpectedData()
        {
            // Arrange
            var database = new Database();
            var pressure = Label.Create("pressure");

            database.AddVariable(pressure, 3000);

            // Act
            database.Update(pressure, 3001);
            var result = database.GetData(pressure);

            // Assert
            Assert.Equal(3001, result);
        }

        [Fact]
        internal void GetAllData_ReturnsExpectedData()
        {
            // Arrange
            var database = new Database();
            var label1 = Label.Create("pressure");
            var label2 = Label.Create("temperature");
            var label3 = Label.Create("pump1");

            database.AddVariable(label1, 3000);
            database.AddVariable(label2, 25);
            database.AddVariable(label3, 199);

            // Act
            var result = database.GetAllData();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(3000, result[label1]);
            Assert.Equal(25, result[label2]);
            Assert.Equal(199, result[label3]);
        }
    }
}