using ITI_Project.DTO;
using ITI_Project.Models;

namespace ITI_Project.Models
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
