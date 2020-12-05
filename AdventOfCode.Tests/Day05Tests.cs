using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    public class Day05Tests
    {
        [Test]
        public void Test_FindRow()
        {
            var d5 = new Day05();
            var row = d5.FindRow("FBFBBFF");
            Assert.AreEqual(44, row);
        }

        [Test]
        public void Test_FindSeat()
        {
            var d5 = new Day05();
            var column = d5.FindSeat("RLR");
            Assert.AreEqual(5, column);
        }

        [Test]
        public void Test_CutInHalf()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('F', Enumerable.Range(0, 128)).ToList();
            Assert.AreEqual(0, range[0]);
            Assert.AreEqual(63, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_2()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('B', Enumerable.Range(0, 64)).ToList();
            Assert.AreEqual(32, range[0]);
            Assert.AreEqual(63, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_3()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('F', Enumerable.Range(32, 32)).ToList();
            Assert.AreEqual(32, range[0]);
            Assert.AreEqual(47, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_4()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('B', Enumerable.Range(32, 16)).ToList();
            Assert.AreEqual(40, range[0]);
            Assert.AreEqual(47, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_5()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('B', Enumerable.Range(40, 8)).ToList();
            Assert.AreEqual(44, range[0]);
            Assert.AreEqual(47, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_6()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('F', Enumerable.Range(44, 4)).ToList();
            Assert.AreEqual(44, range[0]);
            Assert.AreEqual(45, range[range.Count() - 1]);
        }

        [Test]
        public void Test_CutInHalf_Last()
        {
            var d5 = new Day05();
            var range = d5.CutInHalf('F', Enumerable.Range(44, 2)).ToList();
            Assert.AreEqual(44, range[0]);

            var range2 = d5.CutInHalf('B', Enumerable.Range(44, 2)).ToList();
            Assert.AreEqual(45, range2[0]);
        }

        [Test]
        public void Test_FindSeatIndex()
        {
            var d5 = new Day05();
            var i = d5.FindSeatIndex("FBFBBFFRLR");
            Assert.AreEqual(357, i);
        }
    }
}