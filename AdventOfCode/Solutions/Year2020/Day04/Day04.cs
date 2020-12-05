using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{
    class Day04 : ASolution
    {
        public Day04() : base(04, 2020, "") {}

        protected override string SolvePartOne()
        {
            return CountValidPassports(false).ToString();
        }

        protected override string SolvePartTwo()
        {
            return CountValidPassports(true).ToString();
        }

        private int CountValidPassports(bool strictValidation)
        {
            var passportStrings = Input.Split("\n\n");
            return passportStrings.Select(s => new Passport(s, strictValidation))
                                  .Count(p => p.IsValid);
        }
    }
}
