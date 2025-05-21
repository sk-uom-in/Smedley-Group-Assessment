namespace ExamHall.Models
{
    public class Student
    {
        public required string Name { get; set; }
        public required string Test { get; set; }

        public bool IsSpecial { get; set; }
        public (int Row, int Col)? Position { get; set; }

        public override string ToString()
        {
            var special = IsSpecial ? " [Special]" : "";
            var pos = Position.HasValue ? $" at ({Position.Value.Row}, {Position.Value.Col})" : "";
            return $"{Name} (T{Test}){special}{pos}";
        }
    }
}
