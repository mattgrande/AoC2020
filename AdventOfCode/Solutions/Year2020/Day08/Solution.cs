using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day08 : ASolution
    {

        public Day08() : base(08, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return SolvePt1().ToString();
        }

        public int SolvePt1()
        {
            var lines = Input.SplitByNewline();
            var acc = 0;
            var visitedCommands = new SortedSet<int>();

            for (var i = 0; i < lines.Length;)
            {
                Console.WriteLine("{0}: {1} ({2})", i, lines[i], acc);
                if (visitedCommands.Contains(i)) break;

                visitedCommands.Add(i);
                var inst = ParseInstruction(lines[i]);

                switch (inst.Command)
                {
                    case "acc":
                        acc += inst.Value;
                        goto case "nop";
                    case "nop":
                        i++;
                        break;
                    case "jmp":
                        i += inst.Value;
                        break;
                    default:
                        Console.WriteLine("Huh? What?");
                        break;
                }
            }

            return acc;
        }

        protected override string SolvePartTwo()
        {
            return SolvePt2().ToString();
        }

        public int SolvePt2()
        {
            return 0;
        }

        public Instruction ParseInstruction(string input)
        {
            var parts = input.Split(' ');
            return new Instruction
            {
                Command = parts[0],
                Value = int.Parse(parts[1]),
            };
        }

        public class Instruction
        {
            public string Command { get; set; }
            public int Value { get; set; }
        }
    }
}
