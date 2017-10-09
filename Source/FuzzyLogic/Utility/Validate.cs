﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validate.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Utility
{
    using System;
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
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// Throws is string is null or white space.
        /// </exception>
        [DebuggerStepThrough]
        internal static void NotNull<T>(string argument, string paramName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(paramName);
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
        internal static void NotInvalidNumber(double value, string paramName)
        {
            if (value.IsInvalidNumber())
            {
                throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is an invalid number.");
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
        internal static void NotOutOfRange(double value, string paramName, double lower, double upper, RangeEndPoints endPoints = RangeEndPoints.Inclusive)
        {
            NotInvalidNumber(value, paramName);

            switch (endPoints)
            {
                case RangeEndPoints.Inclusive:
                    if (value < lower || value > upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range of [{lower}, {upper}] inclusive. Value = {value}.");
                    }
                    break;

                case RangeEndPoints.LowerExclusive:
                    if (value <= lower || value > upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range of [{lower}, {upper}] lower exclusive. Value = {value}.");
                    }
                    break;

                case RangeEndPoints.UpperExclusive:
                    if (value < lower || value >= upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range of [{lower}, {upper}] upper exclusive. Value = {value}.");
                    }
                    break;

                case RangeEndPoints.Exclusive:
                    if (value <= lower || value >= upper)
                    {
                        throw new ArgumentOutOfRangeException(paramName, $"The {paramName} is not within the specified range of [{lower}, {upper}] exclusive. Value = {value}.");
                    }
                    break;
            }
        }

        /// <summary>
        /// Checks if the double is a valid number.
        /// </summary>
        /// <param name="value">
        /// The value to be checked.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsInvalidNumber(this double value)
        {
            return double.IsNaN(value)
                || double.IsNegativeInfinity(value)
                || double.IsPositiveInfinity(value);
        }
    }
}