using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day13 : ASolution
    {
        public Day13() : base(13, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
//             DebugInput = @"939
// 7,13,x,x,59,x,31,19";

            var lines = Input.Split('\n');
            var arrival = int.Parse(lines[0]);
            var buses = lines[1].Split(',')
                                .Where(b => b != "x")
                                .Select(b => int.Parse(b));

            var min = int.MaxValue;
            var result = 0;
            foreach (var b in buses)
            {
                var x = (arrival / b) + 1;
                var m = (x * b) - arrival;
                if (m < min)
                {
                    min = m;
                    result = m * b;
                }
                Console.WriteLine("Bus {0} will depart in {1} minutes", b, m);
            }

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
