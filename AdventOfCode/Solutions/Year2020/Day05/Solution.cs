using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{
    public class Day05 : ASolution
    {
        public Day05() : base(05, 2020, "")
        {}

        protected override string SolvePartOne()
        {
            var lines = Input.SplitByNewline();
            var max = lines.Select(FindSeatIndex).Concat(new[] {0}).Max();
            return max.ToString();
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.SplitByNewline();
            var seatIndicies = lines.Select(FindSeatIndex).OrderBy(i => i).ToList();
            var lowestSeat = seatIndicies[0];
            var biggestSeat = seatIndicies[^1];
            foreach (var i in Enumerable.Range(lowestSeat, biggestSeat - lowestSeat))
            {
                if (! seatIndicies.Contains(i))
                {
                    return i.ToString();
                }
            }
            return null;
        }

        public static int FindSeatIndex(string s)
        {
            var rowPart = s.Substring(0, 7);
            var seatPart = s.Substring(7);

            var row = FindRow(rowPart);
            var seat = FindSeat(seatPart);

            return (row * 8) + seat;
        }

        public static int FindRow(string s)
        {
            return PartitionToNumber(s, Enumerable.Range(0, 128));
        }

        public static int FindSeat(string s)
        {
            return PartitionToNumber(s, Enumerable.Range(0, 8));
        }

        public static int PartitionToNumber(string s, IEnumerable<int> range)
        {
            range = s.Aggregate(range, (current, fOrB) => CutInHalf(fOrB, current));

            return range.ElementAt(0);
        }

        public static IEnumerable<int> CutInHalf(char fOrB, IEnumerable<int> range)
        {
            var arr = range.ToArray();
            var midpoint = arr.Length / 2;
            var ranges = arr.Split(midpoint);
            var i = (fOrB == 'F' || fOrB == 'L') ? 0 : 1;
            return ranges.ElementAt(i);
        }
    }
}
