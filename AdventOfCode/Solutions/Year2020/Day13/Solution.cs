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
            }

            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.Split('\n');
            var buses = lines[1].Split(',')
                                .Select((b, ix) => (s: b, ix))
                                .Where(b => b.s != "x")
                                .Select(b => (s: long.Parse(b.s), ix: b.ix))
                                .ToList()
                                ;

            var increment = buses[0].s;
            var busIndex = 1;
            long i;
            for (i = increment; busIndex < buses.Count; i += increment)
            {
                var bus = buses[busIndex];
                if ((i + bus.ix) % bus.s == 0)
                {
                    increment *= bus.s;
                    busIndex++;
                }
            }

            return (i - increment).ToString();
        }
    }
}
