using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AdventOfCode.Solutions.Year2020;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day07Tests
    {
        [Test]
        public void Test_ParseColour()
        {
            var line = "dark orange bags contain 3 bright white bags, 4 muted yellow bags";
            var bag = Bag.Parse(line);
            Assert.AreEqual("dark orange", bag.Colour);
        }

        [Test]
        public void Test_ParseChirdren()
        {
            var line = "dark orange bags contain 3 bright white bags, 4 muted yellow bags";
            var bag = Bag.Parse(line);
            Assert.AreEqual(2, bag.Bags.Count);
            Assert.AreEqual("bright white", bag.Bags[0].Item1.Colour);
            Assert.AreEqual("muted yellow", bag.Bags[1].Item1.Colour);
        }

        [Test]
        public void Test_GetParent_ReturnsNullIfNotFound()
        {
            var bag = new Bag() { Colour = "red" };
            bag.Bags.Add(new Tuple<Bag, int>(new Bag() { Colour = "blue" }, 1));
            var bags = new List<Bag>();
            bags.Add(bag);

            var result = Day07.GetParents("green", bags);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Test_GetParent_ReturnsTheParentBag()
        {
            var bag = new Bag() { Colour = "red" };
            bag.Bags.Add(new Tuple<Bag, int>(new Bag() { Colour = "blue" }, 1));
            var bags = new List<Bag>();
            bags.Add(bag);

            var result = Day07.GetParents("blue", bags);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("red", result[0].Colour);
        }

        [Test]
        public void Test_DeepContains()
        {
            var bag = new Bag { Colour = "dark orange" };
            bag.Bags.Add(new Tuple<Bag, int>(new Bag { Colour = "bright white" }, 1));
            bag.Bags[0].Item1.Bags.Add(new Tuple<Bag, int>(new Bag { Colour = "shiny gold" }, 1));

            // Assert.IsFalse(bag.DeepContains("muted yellow"));
            Assert.IsTrue(bag.DeepContains("shiny gold"));
        }

        [Test]
        public void Test_Day07_Part1()
        {
            var d7 = new Day07();
            d7.DebugInput = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            Assert.AreEqual(4, d7.SolvePt1());
        }

        [Test]
        public void Test_Day07_Part2()
        {
            var d7 = new Day07();
            d7.DebugInput = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            Assert.AreEqual(32, d7.SolvePt2());
        }

        [Test]
        public void Test_Day07_Part2_Again()
        {
            var d7 = new Day07();
            d7.DebugInput = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

            Assert.AreEqual(126, d7.SolvePt2());
        }
    }
}