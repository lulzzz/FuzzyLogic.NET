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
    using FuzzyLogic.Fuzzification;
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
            return new LinguisticVariable(
                InputVariable.WaterTemp,
                new List<FuzzySet>
                    {
                        new FuzzySet(TestKit.WaterTemp.Frozen, SingletonFunction.Create(0)),
                        new FuzzySet(TestKit.WaterTemp.Freezing, TriangularFunction.Create(0, 5, 10)),
                        new FuzzySet(TestKit.WaterTemp.Cold, TrapezoidalFunction.Create(5, 10, 15, 20)),
                        new FuzzySet(TestKit.WaterTemp.Warm, TrapezoidalFunction.Create(15, 25, 35, 40)),
                        new FuzzySet(TestKit.WaterTemp.Hot, TrapezoidalFunction.Create(35, 60, 80, 100)),
                        new FuzzySet(TestKit.WaterTemp.Boiling, TrapezoidalFunction.CreateWithRightEdge(95, 100))
                    },
                -20,
                200);
        }

        /// <summary>
        /// Returns a <see cref="LinguisticVariable"/> representing fan speed.
        /// </summary>
        /// <returns>
        /// The <see cref="LinguisticVariable"/>.
        /// </returns>
        public static LinguisticVariable PumpSpeed()
        {
            return new LinguisticVariable(
                InputVariable.PumpSpeed,
                new List<FuzzySet>
                    {
                        new FuzzySet(TestKit.PumpSpeed.Off, SingletonFunction.Create(0)),
                        new FuzzySet(TestKit.PumpSpeed.VeryLow, TrapezoidalFunction.CreateWithLeftEdge(1, 200)),
                        new FuzzySet(TestKit.PumpSpeed.Low, TriangularFunction.Create(0, 500, 1000)),
                        new FuzzySet(TestKit.PumpSpeed.Moderate, TriangularFunction.Create(500, 1000, 2000)),
                        new FuzzySet(TestKit.PumpSpeed.High, TriangularFunction.Create(3000, 3500, 4000)),
                        new FuzzySet(TestKit.PumpSpeed.VeryHigh, TrapezoidalFunction.CreateWithRightEdge(3500, 4999)),
                        new FuzzySet(TestKit.PumpSpeed.AtLimit, SingletonFunction.Create(5000))
                    });
        }
    }
}