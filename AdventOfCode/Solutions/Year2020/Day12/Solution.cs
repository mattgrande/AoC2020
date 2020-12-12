using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day12 : ASolution
    {
        public char Facing { get; private set; }
        public int NS { get; private set; }
        public int EW { get; private set; }
        public Day12() : this('E', 0, 0) {}
        public Day12(char facing = 'E', int ns = 0, int ew = 0) : base(12, 2020, "")
        {
            Facing = facing;
            NS = ns;
            EW = ew;
        }

        protected override string SolvePartOne()
        {
            return CalculateManhattanDistance().ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        public int CalculateManhattanDistance()
        {
            var instructions = Input.SplitByNewline();
            foreach (var inst in instructions)
            {
                Move(inst);
            }
            return Math.Abs(NS) + Math.Abs(EW);
        }

        public void Move(string inst)
        {
            var command = inst[0];
            var n = int.Parse(inst.Substring(1));
            switch (command)
            {
                case 'F':
                    var mult = (Facing == 'W' || Facing == 'S') ? -1 : 1;
                    n *= mult;

                    if (Facing == 'E' || Facing == 'W') EW += n;
                    if (Facing == 'N' || Facing == 'S') NS += n;
                    break;
                case 'N':
                    NS += n;
                    break;
                case 'S':
                    NS -= n;
                    break;
                case 'E':
                    EW += n;
                    break;
                case 'W':
                    EW -= n;
                    break;
                case 'R':
                    {
                    var rotations = n / 90;
                    var directions = new [] { 'E', 'S', 'W', 'N' }.ToList();
                    var currentIndex = directions.FindIndex(f => f == Facing);
                    Facing = directions[(currentIndex + rotations) % 4];
                    }
                    break;
                case 'L':
                    {
                    var rotations = n / 90;
                    var directions = new [] { 'E', 'S', 'W', 'N' }.ToList();
                    var currentIndex = directions.FindIndex(f => f == Facing);
                    var newIndex = currentIndex - rotations;
                    // Console.WriteLine("NI:{0}", newIndex);
                    Facing = newIndex >= 0 ? directions[newIndex % 4] : directions[^Math.Abs(newIndex)];
                    }
                    break;
            }
            return;
        }
    }
}
