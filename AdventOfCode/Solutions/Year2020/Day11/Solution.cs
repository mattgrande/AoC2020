using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day11 : ASolution
    {

        public Day11() : base(11, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return null;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        public string[] Step(string[] rows)
        {
            var seatsToOccupy = new List<(int Row, int Col)>();

            for (int r = 0; r < rows.Length; r++)
            {
                var row = rows[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if (IsEmpty(r, c, rows) && ShouldOccupy(r, c, rows)) seatsToOccupy.Add((r, c));
                }
            }

            foreach (var seat in seatsToOccupy)
            {
                Console.WriteLine("Occupy {0},{1}", seat.Row, seat.Col);
                var row = new StringBuilder(rows[seat.Row]);
                row[seat.Col] = '#';
                rows[seat.Row] = row.ToString();
            }

            return rows;
        }

        public bool IsEmpty(int row, int column, string[] rows)
        {
            return rows[row][column] == 'L';
        }

        public bool ShouldOccupy(int row, int column, string[] rows)
        {
            for (int r = (row - 1); r <= (row + 1); r++)
            {
                if (r < 0 || r >= rows.Length) continue;
                var strRow = rows[r];
                for (int c = (column - 1); c <= (column + 1); c++)
                {
                    if (c < 0 || c >= strRow.Length) continue;
                    if (strRow[c] == '#') return false;
                }
            }
            return true;
        }
    }
}
