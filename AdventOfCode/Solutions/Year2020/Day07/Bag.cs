using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{
    public class Bag
    {
        public string Colour { get; set; }
        public List<Tuple<Bag, int>> Bags { get; } = new List<Tuple<Bag, int>>();
        public int TotalQuantity
        {
            get
            {
                return 1 + Bags.Sum((t) => t.Item1.TotalQuantity * t.Item2);
            }
        }
        public static Bag Parse(string input)
        {
            var bagsRegex = new Regex(" bags?");
            var startWithNumber = new Regex("^\\d+ ");
            var parts = input.Split(" bags contain ");
            var bags = parts[1].Split(", ")
                .Where(b => ! b.Contains("no other"))
                .Select(b => bagsRegex.Replace(b, ""));
            
            var bag = new Bag { Colour = parts[0] };
            foreach (var nOfBags in bags)
            {
                var n = int.Parse(nOfBags.Split(' ')[0]);
                var bagColour = startWithNumber.Replace(nOfBags, "");
                bag.Bags.Add(new Tuple<Bag, int>(new Bag { Colour = bagColour }, n));
            }

            return bag;
        }

        public bool Contains(string colour)
        {
            return Bags.Any(t => t.Item1.Colour == colour);
        }

        public bool DeepContains(string colour)
        {
            return Bags.Any(t =>
                t.Item1.Colour == colour || t.Item1.DeepContains(colour)
            );
        }

        public override string ToString()
        {
            return ToString(0);
        }

        public string ToString(int depth)
        {
            var prefix = new string('>', depth) + (depth > 0 ? " " : "");
            return string.Format("{2}{0}{1}", Colour, Bags.Aggregate("", (acc, b) =>
                $"{acc}\n{b.Item1.ToString(depth + 1)}"), prefix);
        }

        internal void AttachChildren(List<Bag> allBags)
        {
            for (int i = 0; i < Bags.Count; i++)
            {
                var oldBag = Bags[i].Item1;
                var newBag = allBags.Single(b => b.Colour == oldBag.Colour);
                Bags[i] = new Tuple<Bag, int>(newBag, Bags[i].Item2);
            }
        }
    }
}