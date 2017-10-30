// -------------------------------------------------------------------------------------------------
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
    /// The static <see cref="StubLinguisticVariableFactory"/> class.
    /// </summary>
    public static class StubLinguisticVariableFactory
    {
        /// <summary>
        /// Returns a <see cref="LinguisticVariable"/> representing water temperature.
        /// </summary>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        public static LinguisticVariable WaterTemp()
        {
            var frozen = new FuzzySet(TestKit.WaterTemp.Frozen, SingletonFunction.Create(0));
            var freezing = new FuzzySet(TestKit.WaterTemp.Freezing, TriangularFunction.Create(0, 5, 10));
            var cold = new FuzzySet(TestKit.WaterTemp.Cold, TrapezoidalFunction.Create(5, 10, 15, 20));
            var warm = new FuzzySet(TestKit.WaterTemp.Warm, TrapezoidalFunction.Create(15, 25, 35, 40));
            var hot = new FuzzySet(TestKit.WaterTemp.Hot, TrapezoidalFunction.Create(35, 60, 80, 100));
            var boiling = new FuzzySet(TestKit.WaterTemp.Boiling, TrapezoidalFunction.CreateWithRightEdge(95, 100));

            return new LinguisticVariable(InputVariable.WaterTemp, new List<FuzzySet> { frozen, freezing, cold, warm, hot, boiling }, -20, 200);
        }
    }
}