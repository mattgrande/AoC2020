using System;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {
        public Day02() : base(02, 2020, "")
        {
        }

        protected override string SolvePartOne()
        {
            Func<string, bool> v = (s) => IsValidOne(s);
            return ValidatePassword(v);
        }

        protected override string SolvePartTwo()
        {
            Func<string, bool> v = (s) => IsValidTwo(s);
            return ValidatePassword(v);
        }

        private string ValidatePassword(Func<string, bool> validationFn)
        {
            var lines = Input.Split('\n');
            var c = lines.Where(validationFn)
                         .Count();
            return c.ToString();
        }

        private bool IsValidOne(string input)
        {
            var pwl = new PasswordLine(input);
            var count = pwl.Password.Where(c => c == pwl.Letter).Count();

            return count >= pwl.FirstNumber && count <= pwl.SecondNumber;
        }

        private bool IsValidTwo(string input)
        {
            var pwl = new PasswordLine(input);
            return (pwl.Password[pwl.FirstNumber - 1] == pwl.Letter ^ pwl.Password[pwl.SecondNumber - 1] == pwl.Letter);
        }

        protected class PasswordLine
        {
            internal string Password { get; private set; }
            internal char Letter { get; private set; }
            internal int FirstNumber { get; private set; }
            internal int SecondNumber { get; private set; }

            public PasswordLine(string input)
            {
                var split = input.Split(':');
                var nums = split[0];
                Password = split[1].Trim();

                var split2 = nums.Split(' ');
                var split3 = split2[0].Split('-');

                FirstNumber = int.Parse(split3[0]);
                SecondNumber = int.Parse(split3[1]);
                Letter = split2[1][0];
            }
        }
    }
}
