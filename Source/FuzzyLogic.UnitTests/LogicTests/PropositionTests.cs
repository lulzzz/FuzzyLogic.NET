// -------------------------------------------------------------------------------------------------
// <copyright file="PropositionTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.LogicTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Logic;
    using FuzzyLogic.TestKit;
    using FuzzyLogic.TestKit.Stubs;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class PropositionTests
    {
        [Fact]
        internal void ValidateProposition_WhenStateNotAMemberOfLinguisticVariable_Throws()
        {
            // Arrange
            var waterTemp = StubLinguisticVariableFactory.WaterTemp();

            // Invalid fuzzy state.
            var fuzzyState = FuzzyState.Create(PumpSpeed.Off);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => new Proposition(waterTemp, LogicOperators.Is(), fuzzyState));
        }
    }
}