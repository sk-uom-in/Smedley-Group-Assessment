using System.Linq;
using Xunit;
using ExamHall.Services;
using ExamHall.Models;

namespace ExamHall.Tests.Services
{
    public class StudentFactoryTests
    {
        [Fact]
        public void ShouldCreate25Students()
        {
            var students = StudentFactory.CreateStudents();
            Assert.Equal(25, students.Count);
        }

        [Fact]
        public void ShouldCreateExactlyTwoSpecialStudentsWithTest5()
        {
            var students = StudentFactory.CreateStudents();
            var special = students.Where(s => s.IsSpecial).ToList();

            Assert.Equal(2, special.Count);
            Assert.All(special, s => Assert.Equal("T5", s.Test));
        }

    }
}