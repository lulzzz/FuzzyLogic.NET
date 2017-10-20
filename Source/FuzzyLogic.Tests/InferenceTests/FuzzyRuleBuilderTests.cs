// -------------------------------------------------------------------------------------------------
// <copyright file="FuzzyRuleBuilderTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.InferenceTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Inference;
    using FuzzyLogic.MembershipFunctions;
    using Xunit;

    using static FuzzyLogic.Logic.LogicOperators;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class FuzzyRuleBuilderTests
    {
        [Fact]
        internal void WithCondition_ValidCondition_ReturnsExpectedFuzzyRuleBuilder()
        {
            // Arrange
            var function = TrapezoidalFunction.Create(1, 2, 3, 4);
            var fuzzySets = new FuzzySet("cold", function);
            var water = new LinguisticVariable("Temperature", new List<FuzzySet> { fuzzySets });

            // Act
            var rule1 = new FuzzyRuleBuilder("Rule1")
                .WithCondition(If(), water, Is(), "cold")
                .WithConclusion(water, Is(), "cold")
                .Build();

            // Assert
        }
    }
}
