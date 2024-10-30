using ITI_Project.Models;

namespace ITI_Project.Models
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string Name { get; set; }

        // List of related topics
        public List<TopicDTO> RelatedTopics { get; set; } = new List<TopicDTO>();
    }
}
