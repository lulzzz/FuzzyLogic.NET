// -------------------------------------------------------------------------------------------------
// <copyright file="ImmutableAttribute.cs" author="Christopher Sellers">
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
    /// This decoration indicates that the annotated class should be completely immutable
    /// (to fulfill its design by contract specification).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class ImmutableAttribute : Attribute
    {
    }
}