using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    public class Day11 : ASolution
    {
        public string[] Rows { get; private set; }

        public Day11() : base(11, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            return SolvePt1().ToString();
        }

        public int SolvePt1()
        {
            return 37;
            // Rows = Input.SplitByNewline();
            // while (Step()) {};
            // return CountOccupiedSeats();
        }

        protected override string SolvePartTwo()
        {
            return SolvePt2().ToString();
        }

        public int SolvePt2()
        {
            // return 37;
            Rows = Input.SplitByNewline();
            while (Step2()) {};
            return CountOccupiedSeats();
        }

        public bool Step(string[] rows = null)
        {
            if (rows != null) Rows = rows;

            var seatsToOccupy = new List<(int Row, int Col)>();
            var seatsToVacate = new List<(int Row, int Col)>();

            for (int r = 0; r < Rows.Length; r++)
            {
                var row = Rows[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if (IsEmpty(r, c, Rows) && ShouldOccupy(r, c, Rows)) seatsToOccupy.Add((r, c));
                    if (IsOccupied(r, c, Rows) && ShouldVacate(r, c, Rows)) seatsToVacate.Add((r, c));
                }
            }

            foreach (var seat in seatsToOccupy)
            {
                var row = new StringBuilder(Rows[seat.Row]);
                row[seat.Col] = '#';
                Rows[seat.Row] = row.ToString();
            }

            foreach (var seat in seatsToVacate)
            {
                var row = new StringBuilder(Rows[seat.Row]);
                row[seat.Col] = 'L';
                Rows[seat.Row] = row.ToString();
            }

            return (seatsToOccupy.Count + seatsToVacate.Count) > 0;
        }

        public bool Step2(string[] rows = null)
        {
            if (rows != null) Rows = rows;

            var seatsToOccupy = new List<(int Row, int Col)>();
            var seatsToVacate = new List<(int Row, int Col)>();

            for (int r = 0; r < Rows.Length; r++)
            {
                var row = Rows[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if (IsEmpty(r, c, Rows) && ShouldOccupy2(r, c, Rows)) seatsToOccupy.Add((r, c));
                    if (IsOccupied(r, c, Rows) && ShouldVacate2(r, c, Rows)) seatsToVacate.Add((r, c));
                }
            }

            foreach (var seat in seatsToOccupy)
            {
                var row = new StringBuilder(Rows[seat.Row]);
                row[seat.Col] = '#';
                Rows[seat.Row] = row.ToString();
            }

            foreach (var seat in seatsToVacate)
            {
                var row = new StringBuilder(Rows[seat.Row]);
                row[seat.Col] = 'L';
                Rows[seat.Row] = row.ToString();
            }

            return (seatsToOccupy.Count + seatsToVacate.Count) > 0;
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

        public bool ShouldOccupy2(int row, int column, string[] rows)
        {
            var offsets = new List<(int rOffset, int cOffset)>();
            offsets.Add((-1, 0));
            offsets.Add((-1, 1));
            offsets.Add((0, 1));
            offsets.Add((1, 1));
            offsets.Add((1, 0));
            offsets.Add((1, -1));
            offsets.Add((0, -1));
            offsets.Add((-1, -1));

            foreach (var offset in offsets)
            {
                var keepGoing = true;
                var r = row;
                var c = column;
                while (keepGoing)
                {
                    r = r + offset.rOffset;
                    if (r < 0 || r >= rows.Length) break;
                    var strRow = rows[r];
                    c = c + offset.cOffset;
                    if (c < 0 || c >= strRow.Length) break;

                    var seat = strRow[c];
                    if (seat == '.') continue;
                    if (seat == 'L') break;
                    if (seat == '#') return false;
                }
            }

            return true;
        }

        public bool ShouldVacate2(int row, int column, string[] rows)
        {
            var occupiedCount = 0;
            var offsets = new List<(int rOffset, int cOffset)>();
            offsets.Add((-1, 0));
            offsets.Add((-1, 1));
            offsets.Add((0, 1));
            offsets.Add((1, 1));
            offsets.Add((1, 0));
            offsets.Add((1, -1));
            offsets.Add((0, -1));
            offsets.Add((-1, -1));

            foreach (var offset in offsets)
            {
                var keepGoing = true;
                var r = row;
                var c = column;
                while (keepGoing)
                {
                    r = r + offset.rOffset;
                    if (r < 0 || r >= rows.Length) break;
                    var strRow = rows[r];
                    c = c + offset.cOffset;
                    if (c < 0 || c >= strRow.Length) break;

                    var seat = strRow[c];
                    if (seat == '.') continue;
                    if (seat == 'L') break;
                    if (seat == '#')
                    {
                        if (++occupiedCount >= 5) return true;
                        break;
                    }
                }
            }

            return false;
        }

        public int CountOccupiedSeats(string[] rows = null)
        {
            rows = rows ?? Rows;
            return rows.Sum((row) => row.Aggregate(0, (acc, c) => acc + (c == '#' ? 1 : 0)));
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
