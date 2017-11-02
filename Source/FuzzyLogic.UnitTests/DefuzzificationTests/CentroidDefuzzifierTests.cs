// -------------------------------------------------------------------------------------------------
// <copyright file="CentroidDefuzzifierTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.DefuzzificationTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Defuzzification;
    using FuzzyLogic.Fuzzification;
    using FuzzyLogic.Inference;
    using FuzzyLogic.MembershipFunctions;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class CentroidDefuzzifierTests
    {
        [Fact]
        internal void Defuzzify_WithTriangle_ReturnsExpectedResult()
        {
            // Arrange
            var fuzzySet = new FuzzySet("centre", TriangularFunction.Create(-1, 0, 1));

            var fuzzyOutput = new List<FuzzyOutput>
                                  {
                                      new FuzzyOutput(
                                          Label.Create("Balance"),
                                          fuzzySet,
                                          UnitInterval.Create(0.5))
                                  };

            var centroidDefuzzifier = new CentroidDefuzzifier();

            // Act
            var result = centroidDefuzzifier.Defuzzify(fuzzyOutput);

            // Assert
            Assert.Equal("Balance", result.Subject.Value);
            Assert.Equal(0, result.Value);
        }

        [Fact]
        internal void Defuzzify_WithTwoTriangles_ReturnsExpectedResult()
        {
            // Arrange
            var fuzzySet1 = new FuzzySet("left", TriangularFunction.Create(1, 2, 3));
            var fuzzySet2 = new FuzzySet("right", TriangularFunction.Create(3, 4, 5));

            var fuzzyOutput = new List<FuzzyOutput>
                                  {
                                      new FuzzyOutput(
                                          Label.Create("Balance"),
                                          fuzzySet1,
                                          UnitInterval.One()),

                                      new FuzzyOutput(
                                          Label.Create("Balance"),
                                          fuzzySet2,
                                          UnitInterval.One())
                                  };

            var centroidDefuzzifier = new CentroidDefuzzifier();

            // Act
            var result = centroidDefuzzifier.Defuzzify(fuzzyOutput);

            // Assert
            Assert.Equal("Balance", result.Subject.Value);
            Assert.Equal(3, result.Value);
        }
    }
}