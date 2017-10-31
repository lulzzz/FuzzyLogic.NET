// -------------------------------------------------------------------------------------------------
// <copyright file="PremiseTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.LogicTests
{
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Logic;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class PremiseTests
    {
        [Fact]
        internal void ToString_ReturnsExpectedString()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();
            var premise = new Premise(
                LogicOperators.If(),
                waterTemp,
                LogicOperators.Is(),
                FuzzyState.Create(WaterTemp.Cold));

            // Act
            var result = premise.ToString();

            // Assert
            Assert.Equal("IF WaterTemp IS cold", result);
        }
    }
}