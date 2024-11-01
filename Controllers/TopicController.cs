using ITI_Project.DTO;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ItiProjectContext _context;

        public TopicController(ItiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Topic
        #region Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDTO>>> GetTopics()
        {
            var topics = await _context.Topics
                .Select(t => new TopicDTO
                {
                    TopicId = t.TopicId,
                    Name = t.Name
                })
                .ToListAsync();

            return Ok(topics);
        }
        #endregion

        // GET: api/Topic/5
        #region GetbyID
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDTO>> GetTopicById(int id)
        {
            var topic = await _context.Topics
        .Where(t => t.TopicId == id)
        .Select(t => new TopicDTO
        {
            TopicId = t.TopicId,
            Name = t.Name,
            // Add other properties from the Topic model here
            Courses = t.Courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseName = c.CrsName, // Assuming Degree is part of the Course model
            }).ToList()
        })
        .FirstOrDefaultAsync();

            if (topic == null)
                return NotFound($"Topic with ID {id} not found.");

            return Ok(topic);
        }
        #endregion

        // POST: api/Topic
        #region Post
        [HttpPost]
        public async Task<IActionResult> AddTopic([FromBody] TopiccDTO topicDto)
        {
            var topic = new Topic
            {
                TopicId = topicDto.TopicId,
                Name = topicDto.Name
            };

            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();

            return Ok(topicDto);
        }
        #endregion

        // PUT: api/Topic/5
        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] TopiccDTO topicDto)
        {
            if (id != topicDto.TopicId)
                return BadRequest("ID mismatch.");

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
                return NotFound($"Topic with ID {id} not found.");

            topic.Name = topicDto.Name;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        // DELETE: api/department/{id}
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics
                .Include(t => t.Courses) // Include related courses (optional)
                .FirstOrDefaultAsync(t => t.TopicId == id);

            if (topic == null)
            {
                return NotFound($"Topic with ID {id} not found.");
            }

            // Check for related courses before deletion (optional)
            // You might want to handle scenarios where a topic has associated courses.

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        } 
        #endregion
    }
}
