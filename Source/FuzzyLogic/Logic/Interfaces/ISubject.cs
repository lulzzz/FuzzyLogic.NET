// -------------------------------------------------------------------------------------------------
// <copyright file="ISubject.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Interfaces
{
    /// <summary>
    /// The <see cref="ISubject{T1, T2, T3}"/> interface.
    /// </summary>
    /// <typeparam name="T1">
    /// The subject type.
    /// </typeparam>
    /// <typeparam name="T2">
    /// The state type.
    /// </typeparam>
    /// <typeparam name="T3">
    /// The input value type.
    /// </typeparam>
    internal interface ISubject<out T1, out T2, in T3>
    {
        /// <summary>
        /// Gets the subject.
        /// </summary>
        T1 Label { get; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="input">
        /// The input type.
        /// </param>
        /// <returns>
        /// The return type.
        /// </returns>
        T2 GetState(T3 input);
    }
}