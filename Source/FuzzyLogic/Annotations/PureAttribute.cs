// -------------------------------------------------------------------------------------------------
// <copyright file="PureAttribute.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/CodeEssence
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.Annotations
{
    using System;

    /// <summary>
    /// This decoration indicates that the annotated method is pure, and thus has no side effects.
    /// </summary>
    /// <remarks>
    ///     Properties of a pure function include;
    ///     - Does not produce side effects (including assigning a variable, or throwing an exception).
    ///     - Does not mutate the input arguments in any way.
    ///     - Does not depend on anything external to itself (or reference any global variable).
    ///     - Produces the same output for a given input.
    ///     - Is stateless.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class PureAttribute : Attribute
    {
    }
}