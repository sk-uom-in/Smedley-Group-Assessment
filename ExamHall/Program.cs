using System;
using ExamHall.Models;
using ExamHall.Services;
using System.Collections.Generic;

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

            Console.WriteLine("Final seating arrangement:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
