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
            var sum = 0;
            var groups = Input.Split("\n\n").Select(people => people.Split('\n'));
            groups.Select(group => group.Select(person => person.Distinct().OrderBy(c => c)));

            foreach (var group in groups)
            {
                var groupsum = 0;
                string person = group.First();
                Console.WriteLine("First: {0}", person);
                foreach (char q in person)
                {
                    Console.WriteLine("Checking {0} for", q);
                    Console.WriteLine(group.All(p => p.Contains(q)) ? "Y" : "N");
                    groupsum += group.All(p => p.Contains(q)) ? 1 : 0;
                }
                sum += groupsum;
            }

            return sum.ToString();
        }
    }
}
