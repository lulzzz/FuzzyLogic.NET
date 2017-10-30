// -------------------------------------------------------------------------------------------------
// <copyright file="ValidateTests.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.UnitTests.UtilityTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FuzzyLogic.MembershipFunctions;
    using FuzzyLogic.Utility;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK within the Test Suite.")]
    public class ValidateTests
    {
        [Fact]
        internal void NotNull_WhenArgumentNull_Throws()
        {
            // Arrange
            object nullObject = null;

            // Act
            // Assert (ignore expression is always null)
            Assert.Throws<ArgumentNullException>(() => Validate.NotNull(nullObject, nameof(nullObject)));
        }

        [Fact]
        internal void NotNull_WhenStringWhiteSpace_Throws()
        {
            // Arrange
            string whiteSpace = " ";

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Validate.NotNull(whiteSpace, nameof(whiteSpace)));
        }

        [Fact]
        internal void NotNullOrEmpty_WhenCollectionNull_Throws()
        {
            // Arrange
            List<string> collection = null;

            // Act
            // Assert (ignore expression is always null)
            Assert.Throws<ArgumentNullException>(() => Validate.CollectionNotNullOrEmpty(collection, nameof(collection)));
        }

        [Fact]
        internal void NotNullOrEmpty_WhenCollectionEmpty_Throws()
        {
            // Arrange
            List<string> collection = new List<string>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionNotNullOrEmpty(collection, nameof(collection)));
        }


        [Fact]
        internal void CollectionEmpty_WhenCollectionNotEmpty_Throws()
        {
            // Arrange
            List<string> collection = new List<string> { "anElement" };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionEmpty(collection, nameof(collection)));
        }

        [Fact]
        internal void CollectionEmpty_WhenCollectionNull_Throws()
        {
            // Arrange
            List<string> collection = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Validate.CollectionEmpty(collection, nameof(collection)));
        }

        [Fact]
        internal void CollectionNotNullOrEmpty_WhenCollectionNull_Throws()
        {
            // Arrange
            List<string> collection = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Validate.CollectionNotNullOrEmpty(collection, nameof(collection)));
        }

        [Fact]
        internal void CollectionNotNullOrEmpty_WhenCollectionEmpty_Throws()
        {
            // Arrange
            var collection = new List<string>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionNotNullOrEmpty(collection, nameof(collection)));
        }

        [Fact]
        internal void CollectionNotNullOrEmpty_WhenDictionaryNull_Throws()
        {
            // Arrange
            Dictionary<string, int> dictionary = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => Validate.CollectionNotNullOrEmpty(dictionary, nameof(dictionary)));
        }

        [Fact]
        internal void CollectionNotNullOrEmpty_WhenDictionaryEmpty_Throws()
        {
            // Arrange
            var dictionary = new Dictionary<string, int>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionNotNullOrEmpty(dictionary, nameof(dictionary)));
        }

        [Fact]
        internal void CollectionContains_WhenCollectionDoesNotContainElement_Throws()
        {
            // Arrange
            var element = "the_fifth_element";
            var collection = new List<string>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionContains(element, nameof(element), collection));
        }

        [Fact]
        internal void CollectionDoesNotContain_WhenCollectionContainsElement_Throws()
        {
            // Arrange
            var element = "the_fifth_element";
            var collection = new List<string> { element };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.CollectionDoesNotContain(element, nameof(element), collection));
        }

        [Fact]
        internal void DictionaryContainsKey_WhenDictionaryDoesNotContainKey_Throws()
        {
            // Arrange
            var key = "the_key";
            var collection = new Dictionary<string, int>();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.DictionaryContainsKey(key, nameof(key), collection));
        }

        [Fact]
        internal void DictionaryDoesNotContainKey_WhenDictionaryContainsKey_Throws()
        {
            // Arrange
            var key = "the_key";
            var collection = new Dictionary<string, int> { { key, 1 } };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.DictionaryDoesNotContainKey(key, nameof(key), collection));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(-1, -2)]
        [InlineData(2, 1)]
        internal void MinMax_WhenMinGreaterThanMax_Throws(double min, double max)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.MinMax(min, max));
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        internal void NotOutOfRange_VariousInvalidNumbers_Throws(double number)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Validate.NotOutOfRange(number, nameof(number)));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-.01)]
        [InlineData(1.01)]
        internal void NotOutOfRange_VariousOutOfInclusiveRangeNumbers_Throws(double number)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Validate.NotOutOfRange(number, nameof(number), 0, 1, RangeEndPoints.Inclusive));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-.01)]
        [InlineData(1.01)]
        internal void NotOutOfRange_VariousOutOfLowerExclusiveRangeNumbers_Throws(double number)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Validate.NotOutOfRange(number, nameof(number), 0, 1, RangeEndPoints.LowerExclusive));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-.01)]
        [InlineData(1)]
        internal void NotOutOfRange_VariousOutOfUpperExclusiveRangeNumbers_Throws(double number)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Validate.NotOutOfRange(number, nameof(number), 0, 1, RangeEndPoints.UpperExclusive));
        }

        [Theory]
        [InlineData(-1.1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2.1)]
        internal void NotOutOfRange_VariousOutOfExclusiveRangeNumbers_Throws(double number)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Validate.NotOutOfRange(number, nameof(number), 0, 1, RangeEndPoints.Exclusive));
        }

        [Fact]
        internal void FuzzyPointArray_WithEmptyArray_Throws()
        {
            // Arrange
            var points = new FuzzyPoint[] { };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.FuzzyPointArray(points, nameof(points)));
        }

        [Fact]
        internal void FuzzyPointArray_WithOutOfSequencePoints_Throws()
        {
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(4, 0.5), // X out of sequence
                                 new FuzzyPoint(3, 1)
                             };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.FuzzyPointArray(points, nameof(points)));
        }

        [Fact]
        internal void FuzzyPointArray_WithMinYAboveMaxY_Throws()
        {
            // Arrange
            var points = new FuzzyPoint[]
                             {
                                 new FuzzyPoint(2, 0.5),
                                 new FuzzyPoint(4, 0.5), // X out of sequence
                                 new FuzzyPoint(3, 1)
                             };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => Validate.FuzzyPointArray(points, nameof(points)));
        }

        [Fact]
        internal void FuzzySetCollection_WhenLowerBoundGreaterThanUpperBound_Throws()
        {
            // Arrange
            var fuzzySet1 = new FuzzySet("set1", SingletonFunction.Create(1));
            var fuzzySet2 = new FuzzySet("set1", SingletonFunction.Create(1));

            var fuzzySetCollection = new List<FuzzySet> { fuzzySet1, fuzzySet2 };

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new LinguisticVariable("test", fuzzySetCollection, 1, 0));
        }

        [Fact]
        internal void FuzzySetCollection_WhenLowerBoundGreaterThanLowestBoundOfFunctions_Throws()
        {
            // Arrange
            var fuzzySet1 = new FuzzySet("set1", TrapezoidalFunction.Create(1, 2, 3, 4));
            var fuzzySet2 = new FuzzySet("set1", SingletonFunction.Create(1));

            var fuzzySetCollection = new List<FuzzySet> { fuzzySet1, fuzzySet2 };

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LinguisticVariable("test", fuzzySetCollection, 2, 100));
        }

        [Fact]
        internal void FuzzySetCollection_WhenUpperBoundLessThanHighestBoundOfFunctions_Throws()
        {
            // Arrange
            var fuzzySet1 = new FuzzySet("set1", TrapezoidalFunction.Create(1, 2, 3, 4));
            var fuzzySet2 = new FuzzySet("set1", SingletonFunction.Create(1));

            var fuzzySetCollection = new List<FuzzySet> { fuzzySet1, fuzzySet2 };

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LinguisticVariable("test", fuzzySetCollection, 1, 3));
        }
    }
}