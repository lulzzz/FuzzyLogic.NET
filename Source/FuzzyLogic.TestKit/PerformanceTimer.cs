// -------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTimer.cs" author="Christopher Sellers">
//   Copyright (C) 2017. All rights reserved.
//   https://github.com/cjdsellers/FuzzyLogic
//   the use of this source code is governed by the Apache 2.0 license
//   as found in the LICENSE.txt file.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace FuzzyLogic.TestKit
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The static <see cref="PerformanceTimer"/> class.
    /// </summary>
    public static class PerformanceTimer
    {
        /// <summary>
        /// Performance tests the given <see cref="Action"/> and returns the time it took to invoke.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static long Test(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}