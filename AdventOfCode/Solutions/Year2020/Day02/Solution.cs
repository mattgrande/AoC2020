using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {
        public Day02() : base(02, 2020, "")
        {
        }

        protected override string SolvePartOne()
        {
            var lines = Input.Split('\n');
            var c = lines.Where(s => IsValidOne(s))
                         .Count();
            return c.ToString();
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.Split('\n');
            var c = lines.Where(s => IsValidTwo(s))
                         .Count();
            return c.ToString();
        }

        private bool IsValidOne(string input)
        {
            var split = input.Split(':');
            var nums = split[0];
            var pw = split[1].Trim();

            var split2 = nums.Split(' ');
            var split3 = split2[0].Split('-');

            var lowerBound = int.Parse(split3[0]);
            var upperBound = int.Parse(split3[1]);
            var letter = split2[1][0];

            var count = pw.Where(c => c == letter).Count();

            return count >= lowerBound && count <= upperBound;
        }

        private bool IsValidTwo(string input)
        {
            var split = input.Split(':');
            var nums = split[0];
            var pw = split[1].Trim();

            var split2 = nums.Split(' ');
            var split3 = split2[0].Split('-');

            var index1 = int.Parse(split3[0]) - 1;
            var index2 = int.Parse(split3[1]) - 1;
            var letter = split2[1][0];

            return (pw[index1] == letter ^ pw[index2] == letter);
        }
    }
}
