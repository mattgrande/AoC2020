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

        public long SolvePt1(int preambleSize = 25)
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
            return SolvePt2(1930745883).ToString();
        }

        public long SolvePt2(long pt1Sln)
        {
            var numbers = Input.ToLongArray("\n");

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentList = new List<long> { numbers[i] };
                var sum = numbers[i];
                for (int j = (i + 1); j < numbers.Length; j++)
                {
                    currentList.Add(numbers[j]);
                    sum += numbers[j];
                    if (sum > pt1Sln) break;
                    if (sum == pt1Sln)
                    {
                        var min = currentList.Aggregate(long.MaxValue, (x, y) => Math.Min(x, y));
                        var max = currentList.Aggregate(0L, (x, y) => Math.Max(x, y));
                        return min + max;
                    }
                }

                Console.WriteLine("");
            }

            return 0;
        }

        public IList<IList<long>> SplitPreamble(int preambleSize = 25)
        {
            var ints = Input.ToLongArray("\n").ToList();
            var preamble = ints.Take(preambleSize).ToList();
            var theRest = ints.Skip(preambleSize).ToList();
            return new List<IList<long>> { preamble, theRest };
        }

        public static IList<long> GetPossibleSums(IList<long> preamble)
        {
            var sums = new List<long>();
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
