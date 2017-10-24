// -------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTimerTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.TestKit
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class PerformanceTimerTests
    {
        private int waitTime;

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        internal void Test_ReturnsLongGreaterThanInputTime(int delay)
        {
            // Arrange
            Action testMethod = this.DummyMethod;
            this.waitTime = delay;

            // Act
            var result = PerformanceTimer.Test(testMethod);

            // Assert
            Assert.True(result >= this.waitTime);
        }

        private void DummyMethod()
        {
            Thread.Sleep(this.waitTime);
        }
    }
}