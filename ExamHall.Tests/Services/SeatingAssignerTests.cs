using Xunit;
using ExamHall.Services;
using ExamHall.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExamHall.Tests.Services
{
    public class SeatingAssignerTests
    {
        [Fact]
        public void ShouldAssignAll25Students()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();

            var grid = SeatingAssigner.AssignSeats(students);

            var assignedStudents = new HashSet<Student>();
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    Assert.NotNull(grid[r, c]);
                    assignedStudents.Add(grid[r, c]);
                }
            }
            Assert.Equal(25, assignedStudents.Count);
        }

        [Fact]
        public void ShouldRespectSpecialStudentTestConstraint()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();

            students[5].IsSpecial = true; 
            students[15].IsSpecial = true;

            students[5].Test = "T5";
            students[15].Test = "T5";

            var grid = SeatingAssigner.AssignSeats(students);

            var assignedStudents = new HashSet<Student>();
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (grid[r, c] != null)
                    {
                        assignedStudents.Add(grid[r, c]);
                    }
                }
            }
            Assert.Equal(25, assignedStudents.Count);
            Assert.Contains(students[5], assignedStudents);
            Assert.Contains(students[15], assignedStudents);
            Assert.Equal("T5", students[5].Test);
            Assert.Equal("T5", students[15].Test);
        }

        [Fact]
        public void ShouldNotHaveAdjacentStudentsWithSameTest()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();

            var grid = SeatingAssigner.AssignSeats(students);

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (grid[r, c] != null)
                    {
                        for (int dr = -1; dr <= 1; dr++)
                        {
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                if (dr == 0 && dc == 0) continue;
                                int nr = r + dr, nc = c + dc;
                                if (nr >= 0 && nr < 5 && nc >= 0 && nc < 5 && grid[nr, nc] != null)
                                {
                                    Assert.NotEqual(grid[r, c].Test, grid[nr, nc].Test);
                                }
                            }
                        }
                    }
                }
            }
        }

        [Fact]
        public void ShouldThrowException_WhenNoValidArrangementPossible()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();
            foreach (var student in students)
            {
                student.Test = "T5";
            }

            Assert.Throws<Exception>(() => SeatingAssigner.AssignSeats(students));
        }

        [Fact]
        public void AllSpecialStudentsMustHaveT5()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();
            foreach (var student in students)
            {
                if (student.IsSpecial)
                {
                    Assert.Equal("T5", student.Test);
                }
            }
        }

        [Fact]
        public void NonSpecialStudentsCanHaveT5()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();
            int t5Count = students.Count(s => s.Test == "T5");
            int specialCount = students.Count(s => s.IsSpecial);
            // There must be at least as many T5s as specials, but possibly more
            Assert.True(t5Count >= specialCount);
            Assert.Equal(2, specialCount);
        }

        [Fact]
        public void NoAdjacentStudentsHaveSameTest_AfterSeating()
        {
            var students = ExamHall.Services.StudentFactory.CreateStudents();
            var grid = ExamHall.Services.SeatingAssigner.AssignSeats(students);
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    var student = grid[r, c];
                    if (student == null) continue;
                    for (int dr = -1; dr <= 1; dr++)
                    {
                        for (int dc = -1; dc <= 1; dc++)
                        {
                            if (dr == 0 && dc == 0) continue;
                            int nr = r + dr, nc = c + dc;
                            if (nr >= 0 && nr < 5 && nc >= 0 && nc < 5)
                            {
                                var neighbor = grid[nr, nc];
                                if (neighbor != null)
                                {
                                    Assert.NotEqual(student.Test, neighbor.Test);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}