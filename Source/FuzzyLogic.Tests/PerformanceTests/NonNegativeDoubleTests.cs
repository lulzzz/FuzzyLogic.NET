// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NonNegativeDoubleTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Tests.PerformanceTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The non negative double tests.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class NonNegativeDoubleTests
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// The non negative double tests.
        /// </summary>
        public NonNegativeDoubleTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        internal void ListSumPerformance1_WritesElapsedMillisecondsToConsole()
        {
            // Arrange
            // Act
            var result = PerformanceTimer.Run(this.NonNegativeDoublesSumToOneMillion);

            // Assert
            this.output.WriteLine($"NonNegativeDouble Performance result: {result}ms");
        }

        [Fact]
        internal void ListSumPerformance2_WritesElapsedMillisecondsToConsole()
        {
            // Arrange
            // Act
            var result = PerformanceTimer.Run(this.DoublesSumToOneMillion);

            // Assert
            this.output.WriteLine($"Double Performance result: {result}ms");
        }

        [Fact]
        internal void ListSumPerformance3_WritesElapsedMillisecondsToConsole()
        {
            // Arrange
            // Act
            var result = PerformanceTimer.Run(this.ValueTuplesSumToOneMillion);

            // Assert
            this.output.WriteLine($"Value Tuple Performance result: {result}ms");
        }

        private void NonNegativeDoublesSumToOneMillion()
        {
            double sum = 0;
            var listOfNumbers = new List<NonNegativeDouble>();

            for (int i = 0; i < 1000000; i++)
            {
                listOfNumbers.Add(NonNegativeDouble.Create(i));
            }

            foreach (var element in listOfNumbers)
            {
                sum += element.Value;
            }
        }

        private void DoublesSumToOneMillion()
        {
            double sum = 0;
            var listOfNumbers = new List<double>();

            for (int i = 0; i < 1000000; i++)
            {
                listOfNumbers.Add(i);
            }

            foreach (var element in listOfNumbers)
            {
                sum += element;
            }
        }

        private void ValueTuplesSumToOneMillion()
        {
            double sum = 0;
            var listOfNumbers = new List<(double, double)>();

            for (int i = 0; i < 1000000; i++)
            {
                listOfNumbers.Add((i, i));
            }

            foreach (var element in listOfNumbers)
            {
                sum += element.Item1;
            }
        }
    }
}