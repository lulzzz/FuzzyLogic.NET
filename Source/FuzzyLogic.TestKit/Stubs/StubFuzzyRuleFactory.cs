// -------------------------------------------------------------------------------------------------
// <copyright file="StubFuzzyRuleFactory.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.TestKit.Stubs
{
    using FuzzyLogic.Inference;
    using FuzzyLogic.Logic;

    /// <summary>
    /// The static <see cref="StubFuzzyRuleFactory"/> class.
    /// </summary>
    public static class StubFuzzyRuleFactory
    {
        /// <summary>
        /// Returns a stub <see cref="FuzzyRule"/>.
        /// </summary>
        /// <param name="label">
        /// The rule label.
        /// </param>
        /// <returns>
        /// A <see cref="FuzzyRule"/>.
        /// </returns>
        public static FuzzyRule Create(string label)
        {
            var water = StubLinguisticVariableFactory.WaterTemp();

            var waterTempIsWarm = new ConditionBuilder().If(water.Is("warm"));

           return new FuzzyRuleBuilder(label)
                .If(waterTempIsWarm)
                .Then(water.Is("warm"))
                .Build();
        }
    }
}