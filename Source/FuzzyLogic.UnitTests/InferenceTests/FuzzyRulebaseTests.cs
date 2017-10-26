// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRulebaseTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.InferenceTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyRulebaseTests
    {
        [Fact]
        internal void Count_WhenNoRulesInRulebase_ReturnsZero()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();

            // Act
            // Assert
            Assert.Equal(0, rulebase.Count);
        }

        [Fact]
        internal void Add_AddsRuleToRulebase()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();
            var rule = StubFuzzyRuleFactory.Create("Rule1");

            // Act
            rulebase.AddRule(rule);

            // Assert
            Assert.Equal(1, rulebase.Count);
        }

        [Fact]
        internal void DeleteRule_WhenRuleInRulebase_ReturnsExpectedCountOfRules()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();
            var rule = StubFuzzyRuleFactory.Create("Rule1");

            rulebase.AddRule(rule);
            var countAfterAddingRule = rulebase.Count;

            // Act
            rulebase.DeleteAllRules();

            // Assert
            Assert.Equal(1, countAfterAddingRule);
            Assert.Equal(0, rulebase.Count);
        }

        [Fact]
        internal void GetRule_WhenRuleInRulebase_ReturnsExpectedCountOfRules()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();
            var rule = StubFuzzyRuleFactory.Create("Rule1");

            rulebase.AddRule(rule);

            // Act
            var result = rulebase.GetRule(Label.Create("Rule1"));

            // Assert
            Assert.Equal(rule, result);
        }

        [Fact]
        internal void GetRules_WhenNoRuleInRulebase_ReturnsDictionaryWithCountZero()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();

            // Act
            var result = rulebase.GetRules().Count;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        internal void GetRules_RulesInRulebase_ReturnsDictionaryWithCountZero()
        {
            // Arrange
            var rulebase = new FuzzyRulebase();
            var rule1 = StubFuzzyRuleFactory.Create("Rule1");
            var rule2 = StubFuzzyRuleFactory.Create("Rule2");

            rulebase.AddRule(rule1);
            rulebase.AddRule(rule2);

            // Act
            var result = rulebase.GetRules();

            // Assert
            Assert.True(result.ContainsKey(rule1.Label));
            Assert.True(result.ContainsKey(rule2.Label));
        }
    }
}