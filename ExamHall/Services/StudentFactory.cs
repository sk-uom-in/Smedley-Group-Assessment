using System;
using System.Collections.Generic;
using System.Linq;
using ExamHall.Models;

namespace ExamHall.Services
{
    public static class StudentFactory
    {
        public static List<Student> CreateStudents()
        {
            var students = new List<Student>();
            var names = Enumerable.Range(1, 25).Select(i => $"A{i:00}").ToList();

            var rnd = new Random();
            var specialIndices = new HashSet<int>();
            while (specialIndices.Count < 2)
                specialIndices.Add(rnd.Next(25));

            for (int i = 0; i < names.Count; i++)
            {
                var isSpecial = specialIndices.Contains(i);
                var test = isSpecial ? "5" : ((i % 4) + 1).ToString(); // T1–T4 cyclic
                students.Add(new Student
                {
                    Name = names[i],
                    IsSpecial = isSpecial,
                    Test = test
                });
            }

            return students.OrderBy(s => s.Name).ToList();
        }
    }
}