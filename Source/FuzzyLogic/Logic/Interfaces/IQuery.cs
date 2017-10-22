// -------------------------------------------------------------------------------------------------
// <copyright file="IQuery.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Logic.Interfaces
{
    /// <summary>
    /// The <see cref="IQuery{T1, T2}"/> interface.
    /// </summary>
    /// <typeparam name="T1">
    /// The expected state type.
    /// </typeparam>
    /// <typeparam name="T2">
    /// The input value type.
    /// </typeparam>
    internal interface IQuery<out T1, T2>
    {
        /// <summary>
        /// Gets the queried state.
        /// </summary>
        T1 QueriedState { get; }

        /// <summary>
        /// Gets the input value.
        /// </summary>
        T2 InputValue { get; }

        /// <summary>
        /// Updates the input value.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        void UpdateInputValue(T2 input);

        /// <summary>
        /// The evaluate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Evaluate();
    }
}