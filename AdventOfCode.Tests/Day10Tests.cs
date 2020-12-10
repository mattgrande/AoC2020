using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day10Tests
    {
        [Test]
        public void Test_Part1()
        {
            var input = @"16
10
15
5
1
11
7
19
6
12
4";
            var d10 = new Day10();
            d10.DebugInput = input;
            var result = d10.SolvePt1();
            Assert.AreEqual(35, result);
        }
    }
}
