// -------------------------------------------------------------------------------------------------
// <copyright file="CanBeZeroAttribute.cs" author="Christopher Sellers">
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
    /// This decoration indicates that the annotated parameter, property or field can be zero.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    internal sealed class CanBeZeroAttribute : Attribute
    {
    }
}