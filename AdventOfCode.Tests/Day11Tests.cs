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
        public void Test_Step1()
        {
            var d11 = new Day11();
            d11.Step(defaultInput);
            Assert.AreEqual("#.##.##.##", d11.Rows[0]);
            Assert.AreEqual("#.#####.##", d11.Rows[^1]);
        }

        [Test]
        public void Test_Step2()
        {
            var d11 = new Day11();
            var result = d11.Step(defaultInput);
            d11.Step();
            Assert.AreEqual("#.LL.L#.##", d11.Rows[0]);
            Assert.AreEqual("#.#LLLL.##", d11.Rows[^1]);
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

        [Test]
        public void Test_ShouldVacate_true()
        {
            var rows = new [] {
                "#.##.##.##",
                "#######.##",
                "#.#.#..#..",
                "####.##.##",
                "#.##.##.##",
                "#.#####.##",
                "..#.#.....",
                "##########",
                "#.######.#",
                "#.#####.##",
            };

            var d11 = new Day11();
            var result = d11.ShouldVacate(1, 2, rows);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldVacate_false()
        {
            var rows = new [] {
                "#.##.##.##",
                "#######.##",
                "#.#.#..#..",
                "####.##.##",
                "#.##.##.##",
                "#.#####.##",
                "..#.#.....",
                "##########",
                "#.######.#",
                "#.#####.##",
            };

            var d11 = new Day11();
            var result = d11.ShouldVacate(5, 6, rows);
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_CountOccupiedSeats()
        {
            var rows = new [] {
                "#.#L.L#.##",
                "#LLL#LL.L#",
                "L.#.L..#..",
                "#L##.##.L#",
                "#.#L.LL.LL",
                "#.#L#L#.##",
                "..L.L.....",
                "#L#L##L#L#",
                "#.LLLLLL.L",
                "#.#L#L#.##",
            };

            var d11 = new Day11();
            var result = d11.CountOccupiedSeats(rows);
            Assert.AreEqual(37, result);
        }

        [Test]
        public void Test_SolvePt1()
        {
            var d11 = new Day11();
            var result = d11.SolvePt1();
            Assert.AreEqual(37, result);
        }

        [Test]
        public void Test_ShouldOccupy2_true()
        {
            var d11 = new Day11();
            var rows = new [] {
                ".##.##.",
                "#.#.#.#",
                "##...##",
                "...L...",
                "##...##",
                "#.#.#.#",
                ".##.##.",
            };
            var result = d11.ShouldOccupy2(3, 3, rows);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldOccupy2_false()
        {
            var d11 = new Day11();
            var rows = new [] {
                ".......#.",
                "...#.....",
                ".#.......",
                ".........",
                "..#L....#",
                "....#....",
                ".........",
                "#........",
                "...#.....",
            };
            var result = d11.ShouldOccupy2(4, 3, rows);
            Assert.IsFalse(result);
        }

        [Test]
        public void Test_ShouldVacate2_true()
        {
            var rows = new [] {
                "#.L#.##.L#",
                "#L#####.LL",
                "L.#.#..#..",
                "##L#.##.##",
                "#.##.#L.##",
                "#.#####.#L",
                "..#.#.....",
                "LLL####LL#",
                "#.L#####.L",
                "#.L####.L#",
            };

            var d11 = new Day11();
            var result = d11.ShouldVacate2(2, 2, rows);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_ShouldVacate2_false()
        {
            var rows = new [] {
                "#.L#.##.L#",
                "#L#####.LL",
                "L.#.#..#..",
                "##L#.##.##",
                "#.##.#L.##",
                "#.#####.#L",
                "..#.#.....",
                "LLL####LL#",
                "#.L#####.L",
                "#.L####.L#",
            };

            var d11 = new Day11();
            var result = d11.ShouldVacate2(2, 7, rows);
            Assert.IsFalse(result);
        }

        // [Test]
        // public void Test_Part2_Step1()
        // {
        //     var d11 = new Day11();
        //     d11.Step2(defaultInput);
        //     Assert.AreEqual("#.##.##.##", d11.Rows[0]);
        //     Assert.AreEqual("#.#####.##", d11.Rows[^1]);
        // }

        // [Test]
        // public void Test_Part2_Step2()
        // {
        //     var d11 = new Day11();
        //     var result = d11.Step(defaultInput);
        //     d11.Step2();
        //     Assert.AreEqual("#.LL.LL.L#", d11.Rows[0]);
        //     Assert.AreEqual("#.LLLLL.L#", d11.Rows[^1]);
        // }
    }
}
