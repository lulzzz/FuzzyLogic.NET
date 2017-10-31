﻿// -------------------------------------------------------------------------------------------------
// <copyright file="TestEnums.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.TestKit
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum WaterTemp
    {
        Unknown = 0,
        Frozen = 1,
        Freezing = 2,
        Cold = 3,
        Warm = 4,
        Hot = 6,
        Boiling = 7
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum PumpSpeed
    {
        Unknown = 0,
        Off = 1,
        VeryLow = 2,
        Low = 3,
        Moderate = 4,
        High = 6,
        VeryHigh = 7,
        AtLimit = 8
    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum PumpSpeedRule
    {
        Rule0 = 0,
        Rule1 = 1,
        Rule2 = 2,
        Rule3 = 3,

    }

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum InputVariable
    {
        Unknown = 0,
        WaterTemp = 1,
        Pressure = 2,
        FanSpeed = 3
    }
}