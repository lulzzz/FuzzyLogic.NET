﻿// -------------------------------------------------------------------------------------------------
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

    /// <summary>
    /// The validate.
    /// </summary>
    internal static class Validate
    {
        /// <summary>
        /// The not null.
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
        /// Throws if argument is null.
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
        /// The not null.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="paramName">
        /// The param name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws is string is null or white space.
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
        /// The not null or empty.
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
        [DebuggerStepThrough]
        internal static void NotNullOrEmpty<T>(ICollection<T> collection, string paramName)
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
        /// The double not out of range.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The param name.
        /// </param>
        /// <param name="lower">
        /// The lower.
        /// </param>
        /// <param name="upper">
        /// The upper.
        /// </param>
        /// <param name="endPoints">
        /// The end points.
        /// </param>
        [DebuggerStepThrough]
        internal static void NotOutOfRange(
            double value,
            string paramName,
            double lower = double.MinValue,
            double upper = double.MaxValue,
            RangeEndPoints endPoints = RangeEndPoints.Inclusive)
        {
            NotInvalidNumber(value, paramName);

            switch (endPoints)
            {
                case RangeEndPoints.Inclusive:
                    if (value < lower || value > upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lower}, {upper}] inclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.LowerExclusive:
                    if (value <= lower || value > upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lower}, {upper}] lower exclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.UpperExclusive:
                    if (value < lower || value >= upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lower}, {upper}] upper exclusive. InputValue = {value}.");
                    }
                    break;

                case RangeEndPoints.Exclusive:
                    if (value <= lower || value >= upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range [{lower}, {upper}] exclusive. InputValue = {value}.");
                    }
                    break;
            }
        }

        /// <summary>
        /// Validates the points array.
        /// </summary>
        /// <param name="points">
        /// The points.
        /// </param>
        /// <param name="paramName">
        /// The param Name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throws if points out of sequence.
        /// </exception>
        [DebuggerStepThrough]
        internal static void FuzzyPointArray(FuzzyPoint[] points, string paramName)
        {
            NotNull(points, nameof(points));

            if (points.Length == 0)
            {
                throw new ArgumentException("Points array cannot be empty.", paramName);
            }

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
        /// The fuzzy set collection.
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
        /// Throws an exception for various reasons.
        /// </exception>
        [DebuggerStepThrough]
        internal static void FuzzySetCollection(
            ICollection<FuzzySet> inputSets,
            double lowerBound,
            double upperBound)
        {
            NotNullOrEmpty(inputSets, nameof(inputSets));
            NotOutOfRange(lowerBound, nameof(lowerBound));
            NotOutOfRange(lowerBound, nameof(upperBound));

            if (lowerBound > upperBound)
            {
                throw new ArgumentException(
                    $"Lower bound ({lowerBound}) cannot be greater than upper bound ({upperBound}).");
            }

            foreach (var set in inputSets)
            {
                if (set.LowerBound < lowerBound)
                {
                    throw new ArgumentException(
                        $"Lower bound cannot be greater than lowest bound of input set ({set.Label} {lowerBound} < {set.LowerBound}).");
                }

                if (set.UpperBound > upperBound)
                {
                    throw new ArgumentException(
                        $"Upper bound cannot be less than highest upper bound of input set ({set.Label}).");
                }
            }
        }

        /// <summary>
        /// The not invalid number.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The param name.
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