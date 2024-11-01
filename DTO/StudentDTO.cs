using ITI_Project.Models;

namespace ITI_Project.DTO
{
    public class StudentDTO
    {
        public int StdId { get; set; }         
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int DeptID { get; set; }

        public string DeptName { get; set; }
        public string? Grade { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
    public class StudenttDTO
    {

        public string Fname { get; set; }
        public string Lname { get; set; }
        public int DeptID { get; set; }
        public string? Grade { get; set; }
    }
}
