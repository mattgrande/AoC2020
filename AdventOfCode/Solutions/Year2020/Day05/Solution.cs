using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    public class Day05 : ASolution
    {
        public Day05() : base(05, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            var lines = Input.SplitByNewline();
            var max = 0;
            foreach (var line in lines)
            {
                var i = FindSeatIndex(line);
                max = Math.Max(max, i);
            }
            return max.ToString();
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.SplitByNewline();
            var seatIndicies = lines.Select(l => FindSeatIndex(l)).OrderBy(i => i).ToList();
            var lowestSeat = seatIndicies[0];
            var biggestSeat = seatIndicies[seatIndicies.Count - 1];
            var unusedSeats = new List<int>();
            foreach (var i in Enumerable.Range(lowestSeat, biggestSeat - lowestSeat))
            {
                if (! seatIndicies.Contains(i))
                {
                    return i.ToString();
                }
            }
            return null;
        }

        public int FindSeatIndex(string s)
        {
            var rowPart = s.Substring(0, 7);
            var seatPart = s.Substring(7);

            var row = FindRow(rowPart);
            var seat = FindSeat(seatPart);

            return (row * 8) + seat;
        }

        public int FindRow(string s)
        {
            return PartitionToNumber(s, Enumerable.Range(0, 128));
        }

        public int FindSeat(string s)
        {
            return PartitionToNumber(s, Enumerable.Range(0, 8));
        }

        public int PartitionToNumber(string s, IEnumerable<int> range)
        {
            for (var i = 0; i < s.Length; i++)
            {
                char fOrB = s[i];
                range = CutInHalf(fOrB, range);
            }

            return range.ElementAt(0);
        }

        public IEnumerable<int> CutInHalf(char fOrB, IEnumerable<int> range)
        {
            var midpoint = range.Count() / 2;
            var ranges = range.Split(midpoint);
            var i = (fOrB == 'F' || fOrB == 'L') ? 0 : 1;
            return ranges.ElementAt(i);
        }
    }
}
