using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        public Day01() : base(01, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            var lines = Input.Split('\n');
            var nums = lines.Select(s => Int32.Parse(s)).ToList();
            for (var i = 0; i < nums.Count(); i++)
            {
                for (var j = i; j < nums.Count(); j++)
                {
                    var sum = nums[i] + nums[j];
                    if (sum == 2020)
                    {
                        return (nums[i] * nums[j]).ToString();
                    }
                }
            }
            return null;
        }

        protected override string SolvePartTwo()
        {
            var lines = Input.Split('\n');
            var nums = lines.Select(s => Int32.Parse(s)).ToList();
            for (var i = 0; i < nums.Count(); i++)
            {
                for (var j = i; j < nums.Count(); j++)
                {
                    for (var k = j; k < nums.Count(); k++)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if (sum == 2020)
                        {
                            return (nums[i] * nums[j] * nums[k]).ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}
