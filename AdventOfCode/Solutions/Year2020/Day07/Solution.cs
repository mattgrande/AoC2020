using System;
using System.Collections.Generic;
using System.Linq;

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
                                 .Distinct()
                                 .ToList();
            Console.WriteLine(string.Join(", ", containers));
            return containers.Count;
        }

        protected override string SolvePartTwo()
        {
            return SolvePt2().ToString();
        }

        public int SolvePt2()
        {
            var bags = Parse();
            var containers = bags.Where(b => b.Colour == "shiny gold")
                                 .Distinct()
                                 .Aggregate(0, (acc, b) => acc + b.TotalQuantity);
            return containers - 1;
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
                if (!line.EndsWith("no other bags")) continue;

                var bag = Bag.Parse(line);
                Console.WriteLine(bag.Colour);
                parsedBags.Add(bag.Colour);
                allBags.Add(bag);

                lines.RemoveAt(i);
                --i;
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
                    if (!AllChildrenParsed(bag, parsedBags)) continue;

                    bag.AttachChildren(allBags);
                    parsedBags.Add(bag.Colour);
                    allBags.Add(bag);
                    lines.RemoveAt(i);
                    --i;
                }
            }
             
            return allBags;
        }

        private static bool AllChildrenParsed(Bag bag, IReadOnlySet<string> parsedBags)
        {
            return bag.Bags.All(b => parsedBags.Contains(b.Item1.Colour));
        }

        public static List<Bag> GetParents(string colour, IList<Bag> bags)
        {
            return bags.Where(bag => bag.Contains(colour)).ToList();
        }
    }
}
