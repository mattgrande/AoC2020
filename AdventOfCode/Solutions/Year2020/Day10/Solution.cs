using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    public class Day10 : ASolution
    {

        public Day10() : base(10, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return SolvePt1().ToString();
        }

        public int SolvePt1()
        {
            var adapters = Input.ToIntArray("\n")
                            .OrderBy(i => i);

            int jolts = 0;
            int diffsOfOne = 0;
            int diffsOfThree = 1;   // An extra for the actual device
            foreach (var a in adapters)
            {
                var diff = a - jolts;
                jolts = a;
                if (diff == 1) ++diffsOfOne;
                if (diff == 3) ++diffsOfThree;
            }
            return diffsOfOne * diffsOfThree;
        }

        protected override string SolvePartTwo()
        {
            return SolvePt2().ToString();
        }

        public long SolvePt2()
        {
            var adapters = Input.ToIntArray("\n")
                                .ToList();
            var max = adapters.Max();
            adapters.Add(0);
            adapters.Add(max + 3);
            adapters = adapters.OrderBy(i => i).ToList();

            var cache = new Dictionary<int, long> { [adapters.Count - 1] = 1 };

            for (int i = adapters.Count - 2; i >= 0; i--)
            {
                long connections = 0;
                for (var j = i + 1; j < adapters.Count && adapters[j] - adapters[i] <= 3; j++)
                {
                    connections += cache[j];
                }

                cache[i] = connections;
            }

            return cache[0];
        }
    }
}
