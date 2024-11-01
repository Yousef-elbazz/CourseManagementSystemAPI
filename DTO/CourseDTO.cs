namespace ITI_Project.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Degree { get; set; } = null!; // Degree from StudCourse table
    }
    public class CourseeDTO
    {
        public int CourseId { get; set; }

        public int TopicId { get; set; }

        public string? CrsName { get; set; }

        public int? CrsDuration { get; set; }

        public string? Description { get; set; }
    }
}
