// -------------------------------------------------------------------------------------------------
// <copyright file="Validate.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using FuzzyLogic.Annotations;

    /// <summary>
    /// The immutable static <see cref="Validate"/> class.
    /// </summary>
    [Immutable]
    internal static class Validate
    {
        /// <summary>
        /// Validates that the given argument is not null.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Throws if the argument is null.
        /// </exception>
        [DebuggerStepThrough]
        internal static void NotNull<T>(T argument, string paramName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Validates that the given string is not null.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="paramName">
        /// The param name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if the string is null or white space.
        /// </exception>
        [DebuggerStepThrough]
        internal static void NotNull(string argument, string paramName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Validates that the given collection is not null or empty.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="paramName">
        /// The param name.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Throws if the collection is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if the collection is empty.
        /// </exception>
        [DebuggerStepThrough]
        internal static void CollectionNotNullOrEmpty<T>(ICollection<T> collection, string paramName)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(paramName, $"The {paramName} collection is null.");
            }

            if (collection.Count == 0)
            {
                throw new ArgumentException($"The {paramName} collection is empty.", paramName);
            }
        }

        /// <summary>
        /// Validates that the collection is not null, or empty (count zero).
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <typeparam name="T">
        /// The type of collection.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Throws if the collection is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if the collection is empty.
        /// </exception>
        [DebuggerStepThrough]
        internal static void CollectionEmpty<T>(ICollection<T> collection, string paramName)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(paramName, $"The {paramName} collection is null.");
            }

            if (collection.Count != 0)
            {
                throw new ArgumentException($"The {paramName} collection is not empty.", paramName);
            }
        }

        /// <summary>
        /// Validates that the collection contains the element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T">
        /// The type of collection.
        /// </typeparam>
        /// <exception cref="ArgumentException">
        /// Throws if the collection does not contain the element.
        /// </exception>
        [DebuggerStepThrough]
        internal static void CollectionContains<T>(T element, string paramName, ICollection<T> collection)
        {
            if (!collection.Contains(element))
            {
                throw new ArgumentException($"The collection does not contain the {paramName} element.", paramName);
            }
        }

        /// <summary>
        /// Validates that the collection does not contain the element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T">
        /// The type of collection.
        /// </typeparam>
        /// <exception cref="ArgumentException">
        /// Throws if the collection contains the element.
        /// </exception>
        [DebuggerStepThrough]
        internal static void CollectionDoesNotContain<T>(T element, string paramName, ICollection<T> collection)
        {
            if (collection.Contains(element))
            {
                throw new ArgumentException($"The collection already contains the {paramName} element.", paramName);
            }
        }

        /// <summary>
        /// Validates that the dictionary contains the key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T1">
        /// The type of the keys.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The type of the values
        /// </typeparam>
        /// <exception cref="ArgumentException">
        /// Throws if the dictionary does not contain the key.
        /// </exception>
        [DebuggerStepThrough]
        internal static void DictionaryContainsKey<T1, T2>(T1 key, string paramName, IDictionary<T1, T2> collection)
        {
            if (!collection.ContainsKey(key))
            {
                throw new ArgumentException($"The collection does not contain the {paramName} element.", paramName);
            }
        }

        /// <summary>
        /// Validates that the dictionary does not contain the key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T1">
        /// The type of the keys.
        /// </typeparam>
        /// <typeparam name="T2">
        /// The type of the values.
        /// </typeparam>
        /// <exception cref="ArgumentException">
        /// Throws if the dictionary does not contain the key.
        /// </exception>
        [DebuggerStepThrough]
        internal static void DictionaryDoesNotContainKey<T1, T2>(T1 key, string paramName, IDictionary<T1, T2> collection)
        {
            if (collection.ContainsKey(key))
            {
                throw new ArgumentException($"The collection already contains the {paramName} element.", paramName);
            }
        }

        /// <summary>
        /// Validates the minimum vs maximum arguments.
        /// </summary>
        /// <param name="min">
        /// The min value.
        /// </param>
        /// <param name="max">
        /// The max value.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws if min is greater than max.
        /// </exception>
        [DebuggerStepThrough]
        internal static void MinMax(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Minimum value cannot be greater than Maximum value.");
            }
        }

        /// <summary>
        /// Validates the the given <see cref="double"/> is not out of the specified range.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The param name.
        /// </param>
        /// <param name="lowerBound">
        /// The lower bound of the range.
        /// </param>
        /// <param name="upperBound">
        /// The upper bound of the range.
        /// </param>
        /// <param name="endPoints">
        /// The end point literal.
        /// </param>
        [DebuggerStepThrough]
        internal static void NotOutOfRange(
            double value,
            string paramName,
            double lowerBound = double.MinValue,
            double upperBound = double.MaxValue,
            RangeEndPoints endPoints = RangeEndPoints.Inclusive)
        {
            NotInvalidNumber(value, paramName);

            switch (endPoints)
            {
                case RangeEndPoints.Inclusive:
                    if (value < lowerBound || value > upperBound)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lowerBound}, {upperBound}] inclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.LowerExclusive:
                    if (value <= lowerBound || value > upperBound)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lowerBound}, {upperBound}] lower exclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.UpperExclusive:
                    if (value < lowerBound || value >= upperBound)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lowerBound}, {upperBound}] upper exclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.Exclusive:
                    if (value <= lowerBound || value >= upperBound)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lowerBound}, {upperBound}] exclusive. InputValue = {value}.");
                    }
                    break;
            }
        }

        /// <summary>
        /// Validates the <see cref="FuzzyPoint"/> array.
        /// </summary>
        /// <param name="points">
        /// The points array.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws if points are out of sequence.
        /// </exception>
        [DebuggerStepThrough]
        internal static void FuzzyPointArray(FuzzyPoint[] points, string paramName)
        {
            CollectionNotNullOrEmpty(points, nameof(points));

            for (var i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (points[i - 1].X > points[i].X)
                {
                    throw new ArgumentException("Points array out of sequence (must be in ascending order on X axis).", paramName);
                }
            }
        }

        /// <summary>
        /// Validates the collection of <see cref="FuzzySet"/>.
        /// </summary>
        /// <param name="inputSets">
        /// The input sets.
        /// </param>
        /// <param name="lowerBound">
        /// The lower bound.
        /// </param>
        /// <param name="upperBound">
        /// The upper bound.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws if elements of a set are out of bounds.
        /// </exception>
        [DebuggerStepThrough]
        internal static void FuzzySetCollection(
            ICollection<FuzzySet> inputSets,
            double lowerBound,
            double upperBound)
        {
            CollectionNotNullOrEmpty(inputSets, nameof(inputSets));
            NotOutOfRange(lowerBound, nameof(lowerBound));
            NotOutOfRange(upperBound, nameof(upperBound));
            MinMax(lowerBound, upperBound);

            foreach (var set in inputSets)
            {
                NotOutOfRange(set.LowerBound, nameof(set.LowerBound), lowerBound, upperBound);
                NotOutOfRange(set.UpperBound, nameof(set.UpperBound), lowerBound, upperBound);
            }
        }

        /// <summary>
        /// Validates the given number.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if the input value is invalid.
        /// </exception>
        [DebuggerStepThrough]
        private static void NotInvalidNumber(double value, string paramName)
        {
            if (double.IsNaN(value)
             || double.IsNegativeInfinity(value)
             || double.IsPositiveInfinity(value))
            {
                throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is an invalid number.");
            }
        }
    }
}