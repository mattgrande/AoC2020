using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day08Tests
    {
        [Test]
        public void Test_Part1()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            var d8 = new Day08();
            d8.DebugInput = input;
            var result = d8.SolvePt1();
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void Test_Part2()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            var d8 = new Day08();
            d8.DebugInput = input;
            var result = d8.SolvePt2();
            Assert.AreEqual(8, result);
        }
    }
}
