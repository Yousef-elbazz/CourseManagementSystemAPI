using ITI_Project.Models;

namespace ITI_Project.DTO
{
    public class CourseInfDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public virtual Topic Topic2 { get; set; } = null!;


        public List<string> DepartmentNames { get; set; } = new List<string>();
        public List<string> stdcourse { get; set; } = new List<string>();
        public List<string> instructor { get; set; } = new List<string>();
    }
}
