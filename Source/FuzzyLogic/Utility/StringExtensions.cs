// -------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Utility
{
    using System;
    using System.Linq;

    /// <summary>
    /// The static <see cref="StringExtensions"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all whitespace from the given string.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string RemoveAllWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        /// <summary>
        /// Returns an enum of the given type (parsed from the given string).
        /// </summary>
        /// <param name="enumerationString">
        /// The enumeration string.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <returns>
        /// The enum type.
        /// </returns>
        public static T ToEnum<T>(this string enumerationString)
        {
            if (string.IsNullOrWhiteSpace(enumerationString))
            {
                return default(T);
            }

            return (T)Enum.Parse(typeof(T), enumerationString);
        }
    }
}