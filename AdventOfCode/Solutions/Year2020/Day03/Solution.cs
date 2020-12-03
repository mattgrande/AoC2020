using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day03 : ASolution
    {
        public Day03() : base(03, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            var lines = Input.Split('\n');
            int c = GetTreeCount(1, 3, lines);
            return c.ToString();
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.Split('\n');

            var opts = new List<Tuple<int, int>>();
            opts.Add(new Tuple<int, int>(1, 1));
            opts.Add(new Tuple<int, int>(3, 1));
            opts.Add(new Tuple<int, int>(5, 1));
            opts.Add(new Tuple<int, int>(7, 1));
            opts.Add(new Tuple<int, int>(1, 2));

            return opts.Select(opt => GetTreeCount(opt.Item2, opt.Item1, lines))
                       .Aggregate(1L, (acc, x) => acc * x).ToString();
        }

        private int GetTreeCount(int moveDown, int moveRight, string[] lines)
        {
            int x = 0;
            int y = 0;
            int c = 0;

            while ((y += moveDown) < lines.Length)
            {
                x += moveRight;
                var row = lines[y];
                var space = row[x % row.Length];
                if (IsTree(space))
                {
                    c++;
                }
            }

            return c;
        }

        private bool IsTree(char x)
        {
            return x == '#';
        }
    }
}
