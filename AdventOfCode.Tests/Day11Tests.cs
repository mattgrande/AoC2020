using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day11Tests
    {
        private string[] defaultInput;

        [SetUp]
        public void SetUp()
        {
            defaultInput = new [] {"L.LL.LL.LL",
"LLLLLLL.LL",
"L.L.L..L..",
"LLLL.LL.LL",
"L.LL.LL.LL",
"L.LLLLL.LL",
"..L.L.....",
"LLLLLLLLLL",
"L.LLLLLL.L",
"L.LLLLL.LL" };
        }

        [Test]
        public void Test_Part1()
        {
            var d11 = new Day11();
            var result = d11.Step(defaultInput);
            Assert.AreEqual("#.##.##.##", result[0]);
            Assert.AreEqual("#.#####.##", result[^1]);
        }

        [Test]
        public void Test_ShouldOccupy_true()
        {
            var d11 = new Day11();
            var result = d11.ShouldOccupy(1, 4, defaultInput);
            Assert.IsTrue(result);
        }

        [TestCase(1, 0)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void Test_ShouldOccupy_false(int r, int c)
        {
            var d11 = new Day11();
            var row = defaultInput[1 + r];
            var charArray = row.ToCharArray();
            charArray[4 + c] = '#';
            defaultInput[1 + r] = new String(charArray);
            var result = d11.ShouldOccupy(1, 4, defaultInput);
            Assert.IsFalse(result);
        }
    }
}
