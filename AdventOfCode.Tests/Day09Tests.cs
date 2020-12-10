using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day09Tests
    {
        [Test]
        public void Test_SplitPreamble()
        {
            var d9 = new Day09();
            d9.DebugInput = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

            var parts = d9.SplitPreamble(5);
            Assert.AreEqual(5, parts[0].Count);
            Assert.AreEqual(15, parts[1].Count);
            Assert.AreEqual(40, parts[1][0]);
        }

        [Test]
        public void Test_PossibleSums()
        {
            var l = new List<long> { 5, 2, 3, 4, 1 };
            var sums = Day09.GetPossibleSums(l);
            Assert.AreEqual(7, sums.Count());
            Assert.AreEqual(3, sums[0]);
            Assert.AreEqual(9, sums[^1]);
        }

        [Test]
        public void Test_SolvePt1()
        {
            var d9 = new Day09();
            d9.DebugInput = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

            var result = d9.SolvePt1(5);
            Assert.AreEqual(127, result);
        }

        

        [Test]
        public void Test_SolvePt2()
        {
            var d9 = new Day09();
            d9.DebugInput = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
            var result = d9.SolvePt2(127);
            Assert.AreEqual(62, result);
        }
    }
}
