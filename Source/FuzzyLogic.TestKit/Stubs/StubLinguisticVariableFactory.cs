﻿// -------------------------------------------------------------------------------------------------
// <copyright file="StubLinguisticVariableFactory.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.TestKit.Stubs
{
    using System.Collections.Generic;
    using FuzzyLogic.MembershipFunctions;

    /// <summary>
    /// The stub linguistic variable factory.
    /// </summary>
    public static class StubLinguisticVariableFactory
    {
        /// <summary>
        /// Returns a <see cref="LinguisticVariable"/> representing water temperature.
        /// </summary>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        public static LinguisticVariable CreateTemperature()
        {
            var frozen = new FuzzySet("frozen", SingletonFunction.Create(0));
            var freezing = new FuzzySet("freezing", TriangularFunction.Create(0, 5, 10));
            var cold = new FuzzySet("cold", TrapezoidalFunction.Create(5, 10, 15, 20));
            var warm = new FuzzySet("warm", TrapezoidalFunction.Create(15, 25, 35, 40));
            var hot = new FuzzySet("hot", TrapezoidalFunction.Create(35, 60, 80, 100));
            var boiling = new FuzzySet("boiling", TrapezoidalFunction.CreateWithRightEdge(95, 100));

            return new LinguisticVariable("Temperature", new List<FuzzySet> { frozen, freezing, cold, warm, hot, boiling }, -20, 200);
        }
    }
}