using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day06 : ASolution
    {

        public Day06() : base(06, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return Input.Split("\n\n")
                        .Select(g => g.Replace("\n", ""))
                        .Select(g => g.Distinct())
                        .Select(g => g.OrderBy(c => c))
                        .Select(g => g.Count())
                        .Aggregate(0, (a, b) => a + b)
                        .ToString();
        }

        protected override string SolvePartTwo()
        {
            return Input.Split("\n\n")
                        .Select(people => people.Split('\n').Select(person => person.Distinct().OrderBy(c => c)))
                        .Aggregate(
                            0,
                            (acc, people) => acc + people.First().Aggregate(
                                0,
                                (acc, q) => acc + (people.All(p => p.Contains(q)) ? 1 : 0)
                            )
                        )
                        .ToString();
        }
    }
}
