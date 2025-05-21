using System;
using System.Collections.Generic;
using ExamHall.Models;

namespace ExamHall.Services
{
    public static class SeatingAssigner
    {
        private const int Size = 5;

        public static Student[,] AssignSeats(List<Student> students)
        {
            var grid = new Student[Size, Size];
            if (!Backtrack(0, students, grid))
                throw new Exception("No valid seating arrangement found");
            return grid;
        }

        private static bool Backtrack(int index, List<Student> students, Student[,] grid)
        {
            if (index == students.Count) return true;

            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (grid[r, c] == null && IsValid(grid, r, c, students[index].Test))
                    {
                        grid[r, c] = students[index];
                        students[index].Position = (r, c);

                        if (Backtrack(index + 1, students, grid))
                            return true;

                        // Backtrack
                        grid[r, c] = null;
                        students[index].Position = null;
                    }
                }
            }

            return false;
        }

        private static bool IsValid(Student[,] grid, int r, int c, string test)
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;
                    int nr = r + dr, nc = c + dc;
                    if (nr >= 0 && nr < Size && nc >= 0 && nc < Size)
                    {
                        var neighbor = grid[nr, nc];
                        if (neighbor != null && neighbor.Test == test)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}