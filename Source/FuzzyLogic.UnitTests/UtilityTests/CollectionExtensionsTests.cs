// -------------------------------------------------------------------------------------------------
// <copyright file="CollectionExtensionsTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/CodeEssence
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.UtilityTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.Utility;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class CollectionExtensionsTests
    {
        [Fact]
        internal void ForEach_ExecutesEachMethod()
        {
            // Arrange
            var testClass1 = new TestClass();
            var testClass2 = new TestClass();
            var testClass3 = new TestClass();

            IEnumerable<TestClass> listOfActions = new List<TestClass> { testClass1, testClass2, testClass3 };

            // Act
            listOfActions.ForEach(tc => tc.Invoke());

            // Assert
            Assert.True(testClass1.WasCalled);
            Assert.True(testClass2.WasCalled);
            Assert.True(testClass3.WasCalled);
        }

        private class TestClass
        {
            public bool WasCalled { get; private set; } = false;

            public void Invoke()
            {
                this.WasCalled = true;
            }
        }
    }
}