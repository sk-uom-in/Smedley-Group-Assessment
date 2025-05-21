using ExamHall.Models;
using Xunit;

namespace ExamHall.Tests.Models
{
    public class StudentTests
    {
        [Fact]
        public void ToString_ShouldIncludeNameTestAndSpecialStatus()
        {
            var student = new Student
            {
                Name = "A01",
                Test = "5",
                IsSpecial = true,
                Position = (2, 3)
            };

            var output = student.ToString();

            Assert.Contains("A01", output);
            Assert.Contains("T5", output);
            Assert.Contains("[Special]", output);
            Assert.Contains("(2, 3)", output);
        }

        [Fact]
        public void ToString_ShouldHandleNullPosition()
        {
            var student = new Student
            {
                Name = "A02",
                Test = "1",
                IsSpecial = false,
                Position = null
            };

            var output = student.ToString();

            Assert.Contains("A02", output);
            Assert.Contains("T1", output);
            Assert.DoesNotContain("Special", output);
            Assert.DoesNotContain("at", output);
        }
    }
}
