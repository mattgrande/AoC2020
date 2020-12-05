using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{
    class Day04 : ASolution
    {

        public Day04() : base(04, 2020, "")
        {

        }

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
                                  .Where(p => p.IsValid)
                                  .Count();
        }
    }

    public class Passport
    {
        public bool IsValid { get; private set; } = true;
        private static string[] RequiredKeys = new [] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public Passport(string input, bool strictValidation)
        {
            var kvps = input.Split(new char[] { ' ', '\n' });
            var dict = kvps.Select(kvp => kvp.Split(':')).ToDictionary((pair) => pair[0], (pair) => pair[1]);
            IsValid = RequiredKeys.All(key => dict.ContainsKey(key));

            if (IsValid && strictValidation)
            {
                var validations = new Dictionary<string, Func<string, bool>>();
                validations.Add("byr", _validateBirthYear);
                validations.Add("iyr", _validateIssuedYear);
                validations.Add("eyr", _validateExpirationYear);
                validations.Add("hgt", _validateHeight);
                validations.Add("hcl", _validateHair);
                validations.Add("ecl", _validateEye);
                validations.Add("pid", _validatePassport);

                IsValid = validations.All(kvp =>
                {
                    var value = dict[kvp.Key];
                    return kvp.Value(value);
                });
            }
        }

        private static int ToNumber(string s) => int.Parse(s);
        private static Func<int, bool> IsBetween(int min, int max) => (int n) => n >= min && n <= max;
        private readonly Func<string, bool> _validateBirthYear = (y) => y.Pipe(ToNumber, IsBetween(1920, 2002));
        private readonly Func<string, bool> _validateIssuedYear = (y) => y.Pipe(ToNumber, IsBetween(2010, 2020));
        private readonly Func<string, bool> _validateExpirationYear = (y) => y.Pipe(ToNumber, IsBetween(2020, 2030));
        private readonly Func<string, bool> _validateHeight = (h) => {
            if (h.Length < 3) { return false; }
            var value = int.Parse(h.Substring(0, h.Length - 2));
            var units = h.Substring(h.Length - 2);

            if (units == "cm")
            {
                return IsBetween(150, 193)(value);
            }
            else if (units == "in")
            {
                return IsBetween(59, 76)(value);
            }

            return false;
        };
        private readonly Func<string, bool> _validateHair = (h) => new Regex(@"^#[0-9a-f]{6}$").IsMatch(h);
        private readonly Func<string, bool> _validateEye = (h) => new [] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(h);
        private readonly Func<string, bool> _validatePassport = (h) => new Regex(@"^\d{9}$").IsMatch(h);
    }
}
