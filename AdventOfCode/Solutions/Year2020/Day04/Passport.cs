using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{
    public class Passport
    {
        public bool IsValid { get; }
        private static readonly string[] RequiredKeys = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public Passport(string input, bool strictValidation)
        {
            var kvps = input.Split(' ', '\n');
            var dict = kvps.Select(kvp => kvp.Split(':')).ToDictionary((pair) => pair[0], (pair) => pair[1]);
            IsValid = RequiredKeys.All(key => dict.ContainsKey(key));

            if (!IsValid || !strictValidation) return;

            var validations = new Dictionary<string, Func<string, bool>>
            {
                {"byr", _validateBirthYear},
                {"iyr", _validateIssuedYear},
                {"eyr", _validateExpirationYear},
                {"hgt", _validateHeight},
                {"hcl", _validateHair},
                {"ecl", _validateEye},
                {"pid", _validatePassport}
            };

            IsValid = validations.All(kvp =>
            {
                var value = dict[kvp.Key];
                return kvp.Value(value);
            });
        }

        private static int ToNumber(string s) => int.Parse(s);
        private static Func<int, bool> IsBetween(int min, int max) => (n) => n >= min && n <= max;
        private readonly Func<string, bool> _validateBirthYear = (y) => y.Pipe(ToNumber, IsBetween(1920, 2002));
        private readonly Func<string, bool> _validateIssuedYear = (y) => y.Pipe(ToNumber, IsBetween(2010, 2020));
        private readonly Func<string, bool> _validateExpirationYear = (y) => y.Pipe(ToNumber, IsBetween(2020, 2030));
        private readonly Func<string, bool> _validateHeight = (h) => {
            if (h.Length < 3) { return false; }
            var value = int.Parse(h.Substring(0, h.Length - 2));
            var units = h.Substring(h.Length - 2);

            return units switch
            {
                "cm" => IsBetween(150, 193)(value),
                "in" => IsBetween(59, 76)(value),
                _ => false,
            };
        };
        private readonly Func<string, bool> _validateHair = (h) => new Regex(@"^#[0-9a-f]{6}$").IsMatch(h);
        private readonly Func<string, bool> _validateEye = (h) => new [] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(h);
        private readonly Func<string, bool> _validatePassport = (h) => new Regex(@"^\d{9}$").IsMatch(h);
    }
}