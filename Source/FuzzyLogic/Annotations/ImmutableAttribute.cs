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
    /// This decoration indicates that the annotated class or structure should be completely immutable.
    /// Once instantiated the objects public properties should not change.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal sealed class ImmutableAttribute : Attribute
    {
    }
}