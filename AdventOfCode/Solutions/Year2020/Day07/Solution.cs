using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day07 : ASolution
    {
        public Day07() : base(07, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return SolvePt1().ToString();
        }

        public int SolvePt1()
        {
            var bags = Parse();
            var containers = bags.Where(b => b.DeepContains("shiny gold"))
                                 .Select(b => b.Colour)
                                 .Distinct();
            Console.WriteLine(string.Join(", ", containers));
            return containers.Count();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        public IList<Bag> Parse()
        {
            var lines = Input.SplitByNewline(true)
                             .Select(l => l.Replace(".", ""))
                             .ToList();
            var parsedBags = new SortedSet<string>();
            var allBags = new List<Bag>();
            
            // Step 1: Parse the bags with no children
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (line.EndsWith("no other bags"))
                {
                    var bag = Bag.Parse(line);
                    Console.WriteLine(bag.Colour);
                    parsedBags.Add(bag.Colour);
                    allBags.Add(bag);

                    lines.RemoveAt(i);
                    --i;
                }
            }

            // Step 2: Attach all of the remaining bags, slowly going up the chain
            var attempts = 0;
            while (lines.Count > 0)
            {
                Console.WriteLine("Attempt {0} (Remaining: {1})", ++attempts, lines.Count);
                for (var i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    var bag = Bag.Parse(line);
                    if (AllChildrenParsed(bag, parsedBags))
                    {
                        bag.AttachChildren(allBags);
                        parsedBags.Add(bag.Colour);
                        allBags.Add(bag);
                        lines.RemoveAt(i);
                        --i;
                    }
                }
            }
             
            return allBags;
        }

        private bool AllChildrenParsed(Bag bag, SortedSet<string> parsedBags)
        {
            return bag.Bags.All(b => parsedBags.Contains(b.Colour));
        }

        public static List<Bag> GetParents(string colour, IList<Bag> bags)
        {
            var foundBags = new List<Bag>();
            foreach (var bag in bags)
            {
                if (bag.Contains(colour))
                {
                    foundBags.Add(bag);
                }
            }
            return foundBags;
        }
    }

    public class Bag
    {
        public string Colour { get; set; }
        public List<Bag> Bags { get; private set; } = new List<Bag>();
        public static Bag Parse(string input)
        {
            var bagsRegex = new Regex(" bags?");
            var startWithNumber = new Regex("^\\d+ ");
            var parts = input.Split(" bags contain ");
            var bags = parts[1].Split(", ")
                               .Select(b => bagsRegex.Replace(b, ""))
                               .Select(b => startWithNumber.Replace(b, ""))
                               .Where(b => b != "no other");
            return new Bag
            {
                Colour = parts[0],
                Bags = bags.Select(b => new Bag {Colour = b}).ToList(),
            };
        }

        public bool Contains(string colour)
        {
            return Bags.Any(b => b.Colour == colour);
        }

        public bool DeepContains(string colour)
        {
            return Bags.Any(b => {
                return b.Colour == colour || b.DeepContains(colour);
            });
        }

        public override string ToString()
        {
            return ToString(0);
        }

        public string ToString(int depth = 0)
        {
            var prefix = new String('>', depth) + (depth > 0 ? " " : "");
            return string.Format("{2}{0}{1}", Colour, Bags.Aggregate("", (acc, b) => string.Format("{0}\n{1}", acc, b.ToString(depth + 1))), prefix);
        }

        internal void AttachChildren(List<Bag> allBags)
        {
            for (int i = 0; i < Bags.Count; i++)
            {
                var oldBag = Bags[i];
                Bags[i] = allBags.Single(b => b.Colour == oldBag.Colour);
            }
        }
    }
}
