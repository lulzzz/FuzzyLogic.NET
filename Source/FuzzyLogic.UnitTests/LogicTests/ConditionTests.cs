﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ConditionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.LogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using FuzzyLogic.Logic;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class ConditionTests
    {
        [Fact]
        internal void WithWeight_SetsWeightToExpectedValue()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            var condition = ConditionBuilder
                .If(waterTemp.Is(WaterTemp.Boiling))
                .WithWeight(0.5)
                .Build();

            // Act
            condition.SetWeight(UnitInterval.Create(0.5));

            // Assert
            Assert.Equal(0.5, condition.Weight.Value);
        }

        [Fact]
        internal void Evaluate_WhenInvalidData_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            var condition = ConditionBuilder.If(waterTemp.Is(WaterTemp.Boiling)).Build();

            var dataPoint = new DataPoint(Label.Create(InputVariable.Pressure), 3000);

            var data = new Dictionary<Label, DataPoint> { { dataPoint.Variable, dataPoint } };

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => condition.Evaluate(data, new FuzzyEvaluator()));
        }

        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            var condition = ConditionBuilder
                .If(waterTemp.Not(WaterTemp.Boiling))
                .And(waterTemp.Not(WaterTemp.Freezing))
                .And(waterTemp.Not(WaterTemp.Frozen))
                .Build();

            // Act
            var result = condition.ToString();

            // Assert
            Assert.Equal("IF WaterTemp NOT boiling AND WaterTemp NOT freezing AND WaterTemp NOT frozen", result);
        }
    }
}