using System;
using System.Collections.Generic;
using ExamHall.Models;
using ExamHall.Services;

namespace ExamHall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating students...");
            List<Student> students = StudentFactory.CreateStudents();

            Console.WriteLine("Assigning seating...");
            Student[,] grid = SeatingAssigner.AssignSeats(students);

            Console.WriteLine("\n Final student list:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            PrintSeatingMatrix(grid);
        }

        static void PrintSeatingMatrix(Student[,] grid)
        {
            Console.WriteLine("\n Seating Layout (Name | Test):\n");

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    var s = grid[r, c];
                    var name = s.Name;
                    var test = s.Test;
                    var label = s.IsSpecial ? $"{name}*|T{test}" : $"{name}|T{test}";
                    Console.Write($"{label.PadRight(10)} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n* = Special student");
        }
    }
}