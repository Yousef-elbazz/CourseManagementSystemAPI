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

        // GET: api/Topic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDTO>> GetTopicById(int id)
        {
            var topic = await _context.Topics
                .Where(t => t.TopicId == id)
                .Select(t => new TopicDTO
                {
                    TopicId = t.TopicId,
                    Name = t.Name
                }).FirstOrDefaultAsync();

            if (topic == null)
                return NotFound($"Topic with ID {id} not found.");

            return Ok(topic);
        }

        // POST: api/Topic
        [HttpPost]
        public async Task<IActionResult> AddTopic([FromBody] TopicDTO topicDto)
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

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
                return NotFound($"Topic with ID {id} not found.");

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return Ok(topic);
        }

        // PUT: api/Topic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] TopicDTO topicDto)
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
    }
}
