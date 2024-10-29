using ITI_Project.Models;

namespace ITI_Project.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // List of student names
        public List<string> StudentNames { get; set; } = new List<string>();

        // List of instructor names
        public List<string> InstructorNames { get; set; } = new List<string>();

    }
}
