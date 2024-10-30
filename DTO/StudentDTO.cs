using ITI_Project.Models;

namespace ITI_Project.DTO
{
    public class StudentDTO
    {
        public int StdId { get; set; }         // Unique identifier for the student
        public string Fname { get; set; }      // First name of the student
        public string Lname { get; set; }      // Last name of the student
        public string DeptName { get; set; }
        public string? Grade { get; set; }     // Grade of the student
        // If you want to include the department name or other details, you could add those properties as well.
        public List<string> Courses { get; set; } = new List<string>();
    }
}
