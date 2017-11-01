// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRuleTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.InferenceTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;
    using Xunit.Abstractions;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyRuleTests
    {
        private readonly ITestOutputHelper output;

        public FuzzyRuleTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        internal void Validate_WhenFirstConditionConnectiveNotIf_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var fanSpeed = StubLinguisticVariableFactory.FanSpeed();

            var fuzzyRule = new FuzzyRuleBuilder("Rule0")
                .And(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Frozen)))
                .Then(fanSpeed.Is(FanSpeed.Off));

            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => fuzzyRule.Build());

            this.output.WriteLine(ex.Message);
        }

        [Fact]
        internal void Validate_WhenAnotherConditionConnectiveIsIf_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var fanSpeed = StubLinguisticVariableFactory.FanSpeed();

            var fuzzyRule = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Frozen)))
                .If(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Boiling)))
                .Then(fanSpeed.Is(FanSpeed.AtLimit));

            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => fuzzyRule.Build());

            this.output.WriteLine(ex.Message);
        }

        [Fact]
        internal void Validate_WhenAnOrConditionConnectiveIsFollowedByAnAnd_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var fanSpeed = StubLinguisticVariableFactory.FanSpeed();

            var fuzzyRule = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Frozen)))
                .Or(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Boiling)))
                .And(new ConditionBuilder(0.5).If(waterTemp.IsNot(WaterTemp.Freezing)))
                .Then(fanSpeed.Is(FanSpeed.AtLimit));

            // Act
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => fuzzyRule.Build());

            this.output.WriteLine(ex.Message);
        }

        [Fact]
        internal void Evaluate_ValidRuleAndConditions_ReturnsExpectedFuzzyOutput()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var fanSpeed = StubLinguisticVariableFactory.FanSpeed();

            var fuzzyRule = new FuzzyRuleBuilder(PumpSpeedRule.Rule0)
                .If(new ConditionBuilder().If(waterTemp.Is(WaterTemp.Frozen)))
                .Or(new ConditionBuilder(0.5).If(waterTemp.Is(WaterTemp.Freezing)))
                .Then(fanSpeed.Is(FanSpeed.Off))
                .Build();

            var dataPoint = new DataPoint(waterTemp.Subject, 0);

            var data = new Dictionary<Label, DataPoint> { { dataPoint.Variable, dataPoint } };

            // Act
            var result = fuzzyRule.Evaluate(data, new FuzzyEvaluator());

            // Assert
            Assert.Equal(fanSpeed.Subject, result[0].Subject);
            Assert.Equal(fanSpeed.GetState(0), result[0].State);
            Assert.Equal(UnitInterval.One(), result[0].FiringStrength);
            Assert.Equal(fanSpeed.GetSet(FanSpeed.Off), result[0].OutputFunction);
        }
    }
}