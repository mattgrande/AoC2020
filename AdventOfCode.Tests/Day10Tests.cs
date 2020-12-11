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

        [Test]
        public void Test_Part2()
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
            var result = d10.SolvePt2();
            Assert.AreEqual(8, result);
        }
    
        [Test]
        public void Test_Part2_Again()
        {
            var input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
            var d10 = new Day10();
            d10.DebugInput = input;
            var result = d10.SolvePt2();
            Assert.AreEqual(19208, result);
        }
    }
}
