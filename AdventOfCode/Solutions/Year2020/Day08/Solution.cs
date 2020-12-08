using System;
using System.Linq;
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
            return RunProgram(lines).Item1;
        }

        protected override string SolvePartTwo()
        {
            return SolvePt2().ToString();
        }

        public int SolvePt2()
        {
            var lines = Input.SplitByNewline();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith("acc")) continue;

                var flippedCopy = lines.ToArray();
                flippedCopy[i] = FlipInstruction(line);
                var result = RunProgram(flippedCopy);
                if (result.Item2 == false)
                {
                    return result.Item1;
                }
            }

            return 0;
        }

        private static Instruction ParseInstruction(string input)
        {
            var parts = input.Split(' ');
            return new Instruction
            {
                Command = parts[0],
                Value = int.Parse(parts[1]),
            };
        }

        private static Tuple<int, bool> RunProgram(string[] lines)
        {
            var infiniteLoop = false;
            var acc = 0;
            var visitedCommands = new SortedSet<int>();

            for (var i = 0; i < lines.Length;)
            {
                Console.WriteLine("{0}: {1} ({2})", i, lines[i], acc);
                if (visitedCommands.Contains(i)) 
                {
                    infiniteLoop = true;
                    break;
                }

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

            Console.WriteLine("Done! {0},{1}", acc, infiniteLoop);
            return new Tuple<int, bool>(acc, infiniteLoop);
        }

        private static string FlipInstruction(string inst)
        {
            var parts = inst.Split(' ');
            return parts[0] == "jmp" ? $"nop {parts[1]}" : $"jmp {parts[1]}";
        }

        public class Instruction
        {
            public string Command { get; set; }
            public int Value { get; set; }
        }
    }
}
