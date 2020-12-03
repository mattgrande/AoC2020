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

            int x = 0;
            int y = 0;
            int c = 0;

            while (y < lines.Length - 1) {
                y++;
                x+=3;
                var row = lines[y];
                var space = row[x % row.Length];
                // Console.Write(space);
                if (IsTree(space))
                {
                    c++;
                }
            }

            return c.ToString();
        }

        protected override string SolvePartTwo()
        {
            var opts = new List<Tuple<int, int>>();
            opts.Add(new Tuple<int, int>(1, 1));
            opts.Add(new Tuple<int, int>(3, 1));
            opts.Add(new Tuple<int, int>(5, 1));
            opts.Add(new Tuple<int, int>(7, 1));
            opts.Add(new Tuple<int, int>(1, 2));

            var results = new List<long>();

            var lines = Input.Split('\n');

            foreach (var opt in opts)
            {
                int x = 0;
                int y = 0;
                int c = 0;

                while ((y += opt.Item2) < lines.Length)
                {
                    x += opt.Item1;
                    var row = lines[y];
                    var space = row[x % row.Length];
                    // Console.Write(space);
                    if (IsTree(space))
                    {
                        c++;
                    }
                }

                Console.WriteLine("Right {0}, Down {1}: {2}", opt.Item1, opt.Item2, c);
                results.Add(c);
            }

            long seed = 1;
            return results.Aggregate(seed, (acc, x) => acc * x).ToString();
        }

        private bool IsTree(char x)
        {
            return x == '#';
        }
    }
}
