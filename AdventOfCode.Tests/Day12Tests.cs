using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day12Tests
    {
        [Test]
        public void Test_MoveF()
        {
            var d12 = new Day12();
            d12.Move("F10");
            Assert.AreEqual(d12.NS, 0);
            Assert.AreEqual(d12.EW, 10);
        }
        
        [Test]
        public void Test_MoveN()
        {
            var d12 = new Day12('E', 0, 10);
            d12.Move("N3");
            Assert.AreEqual(d12.Facing, 'E');
            Assert.AreEqual(d12.NS, 3);
            Assert.AreEqual(d12.EW, 10);
        }
        
        [Test]
        public void Test_MoveR()
        {
            var d12 = new Day12('E', 3, 10);
            d12.Move("R90");
            Assert.AreEqual(d12.Facing, 'S');
            Assert.AreEqual(d12.NS, 3);
            Assert.AreEqual(d12.EW, 10);

            d12.Move("R180");
            Assert.AreEqual(d12.Facing, 'N');
            d12.Move("R270");
            Assert.AreEqual(d12.Facing, 'W');
        }

        [Test]
        public void Test_GetManhattanDistance()
        {
            var d12 = new Day12();
            d12.DebugInput = @"F10
N3
F7
R90
F11";
            var mDist = d12.CalculateManhattanDistance();
            Assert.AreEqual(25, mDist);
        }

        [Test]
        public void Test_MoveWaypointF()
        {
            var d12 = new Day12();
            d12.MoveWaypoint("F10");
            Assert.AreEqual(10, d12.NS);
            Assert.AreEqual(100, d12.EW);
        }
    }
}
