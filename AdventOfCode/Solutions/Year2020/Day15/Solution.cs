using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day15 : ASolution
    {
        // private Dictionary<int, List<int>> nums = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> nums = new Dictionary<int, List<int>>();
        private int currentTurn = 0;
        private int lastNumber = 0;
        public Day15() : base(15, 2020, "")
        {}

        protected override string SolvePartOne()
        {
            // DebugInput = @"0,3,6";

            var startingNumbers = Input.ToIntArray(",");
            for (int i = 0; i < startingNumbers.Length; i++)
            {
                var n = startingNumbers[i];
                currentTurn = i + 1;
                SayNumber(n);
            }
            while (currentTurn < 30000000)
            {
                ++currentTurn;
                if (nums[lastNumber].Count == 1)
                {
                    // Console.WriteLine("{0} has never been said before", lastNumber);
                    SayNumber(0);
                }
                else
                {
                    var lastTurnSaid = nums[lastNumber][^2];
                    // Console.WriteLine("{0} has been said before, most recently on turn {1}", lastNumber, lastTurnSaid);
                    var diff = currentTurn - lastTurnSaid - 1;
                    SayNumber(diff);
                }
            }

            return null;
        }

        private void SayNumber(int n)
        {
            if (currentTurn % 10000 == 0)
                Console.WriteLine("Turn {0}; Saying {1}", currentTurn, n);
            if (! nums.ContainsKey(n))
            {
                nums.Add(n, new List<int>());
            }

            nums[n].Add(currentTurn);
            lastNumber = n;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
