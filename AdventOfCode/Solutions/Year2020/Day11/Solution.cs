using System;
using System.Collections.Generic;
using System.Linq;
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
            var seatsToVacate = new List<(int Row, int Col)>();

            for (int r = 0; r < rows.Length; r++)
            {
                var row = rows[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if (IsEmpty(r, c, rows) && ShouldOccupy(r, c, rows)) seatsToOccupy.Add((r, c));
                    if (IsOccupied(r, c, rows) && ShouldVacate(r, c, rows)) seatsToVacate.Add((r, c));
                }
            }

            foreach (var seat in seatsToOccupy)
            {
                Console.WriteLine("Occupy {0},{1}", seat.Row, seat.Col);
                var row = new StringBuilder(rows[seat.Row]);
                row[seat.Col] = '#';
                rows[seat.Row] = row.ToString();
            }

            foreach (var seat in seatsToVacate)
            {
                Console.WriteLine("Vacate {0},{1}", seat.Row, seat.Col);
                var row = new StringBuilder(rows[seat.Row]);
                row[seat.Col] = 'L';
                rows[seat.Row] = row.ToString();
            }

            return rows;
        }

        public bool ShouldOccupy(int row, int column, string[] rows)
        {
            for (int r = (row - 1); r <= (row + 1); r++)
            {
                if (r < 0 || r >= rows.Length) continue;
                var strRow = rows[r];
                for (int c = (column - 1); c <= (column + 1); c++)
                {
                    if (row == r && column == c) continue;
                    if (c < 0 || c >= strRow.Length) continue;
                    if (strRow[c] == '#') return false;
                }
            }
            return true;
        }

        public bool ShouldVacate(int row, int column, string[] rows)
        {
            var occupiedCount = 0;
            for (int r = (row - 1); r <= (row + 1); r++)
            {
                if (r < 0 || r >= rows.Length) continue;
                var strRow = rows[r];
                for (int c = (column - 1); c <= (column + 1); c++)
                {
                    if (row == r && column == c) continue;
                    if (c < 0 || c >= strRow.Length) continue;
                    if (strRow[c] == '#') 
                    {
                        if (++occupiedCount >= 4) return true;
                    }
                }
            }
            return false;
        }

        public int CountOccupiedSeats(string[] rows)
        {
            return rows.Sum((row) => row.Aggregate(acc, c) => acc + (c == '#' ? 1 : 0));
        }

        private bool IsOccupied(int row, int column, string[] rows)
        {
            return rows[row][column] == '#';
        }

        private bool IsEmpty(int row, int column, string[] rows)
        {
            return rows[row][column] == 'L';
        }
    }
}
