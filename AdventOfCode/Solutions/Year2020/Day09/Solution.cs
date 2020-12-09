using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    public class Day09 : ASolution
    {

        public Day09() : base(09, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return SolvePt1().ToString();
        }

        public int SolvePt1(int preambleSize = 25)
        {
            var parts = SplitPreamble(preambleSize);
            var preamble = parts[0];
            var numbers = parts[1];

            foreach (var n in numbers)
            {
                var sums = GetPossibleSums(preamble);
                if (! sums.Contains(n)) return n;

                preamble.RemoveAt(0);
                preamble.Add(n);
            }

            return 0;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        public IList<IList<int>> SplitPreamble(int preambleSize = 25)
        {
            var ints = Input.ToIntArray("\n").ToList();
            var preamble = ints.Take(preambleSize).ToList();
            var theRest = ints.Skip(preambleSize).ToList();
            return new List<IList<int>> { preamble, theRest };
        }

        public static IList<int> GetPossibleSums(IList<int> preamble)
        {
            var sums = new List<int>();
            for (int i = 0; i < preamble.Count; i++)
            {
                for (int j = (i + 1); j < preamble.Count; j++)
                {
                    sums.Add(preamble[i] + preamble[j]);
                }
            }
            return sums.OrderBy(i => i).Distinct().ToList();
        }
    }
}
