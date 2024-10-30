namespace ITI_Project.DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Degree { get; set; } = null!; // Degree from StudCourse table
    }
}
