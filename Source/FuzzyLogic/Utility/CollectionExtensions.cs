// -------------------------------------------------------------------------------------------------
// <copyright file="CollectionExtensions.cs" author="Christopher Sellers">
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

    internal static class CollectionExtensions
    {
        /// <summary>
        /// Performs the action on each element in the <see cref="IEnumerable{T}"/> source.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
            {
                action(element);
            }
        }
    }
}