using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Project.Models;
using ITI_Project.DTO;

namespace ITI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ItiProjectContext _context;

        public CoursesController(ItiProjectContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseInfDTO>>> GetCourses()
        {
            var courses = await _context.Courses
        .Include(c => c.Departments) // Include Departments
        .Include(c => c.CourseInstructors) // Include Instructors
            .ThenInclude(ci => ci.Ins) // Include Instructor details
        .Include(c => c.StudCourses) // Include CourseStudents
            .ThenInclude(cs => cs.Std) // Include Student details
        .ToListAsync();


            var AllAtt = courses.Select(s => new CourseInfDTO
            {
                Id = s.CourseId,
                Name = s.CrsName,
                Description = s.Description,
                Duration = s.CrsDuration ?? 0, // Set default value if CrsDuration is null
                DepartmentNames = s.Departments.Select(d => d.Name).ToList(),
                instructor= s.CourseInstructors.Select(ci => ci.Ins.Name).ToList(),
                stdcourse = s.StudCourses.Select(cs => cs.Std.Fname).ToList() // Add students

            }).ToList();
            return Ok(AllAtt);
        }



        // GET: api/Courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseInfDTO>> GetCourseById(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Departments) // Include Departments
                .Include(c => c.CourseInstructors) // Include Instructors
                    .ThenInclude(ci => ci.Ins) // Include Instructor details
                .Include(c => c.StudCourses) // Include CourseStudents
                    .ThenInclude(cs => cs.Std) // Include Student details
                .FirstOrDefaultAsync(c => c.CourseId == id);

            // Handle not found scenario
            if (course == null)
            {
                return NotFound();
            }

            var courseInfDTO = new CourseInfDTO
            {
                Id = course.CourseId,
                Name = course.CrsName,
                Description = course.Description,
                Duration = course.CrsDuration ?? 0, // Set default value if CrsDuration is null
                DepartmentNames = course.Departments.Select(d => d.Name).ToList(),
                instructor = course.CourseInstructors.Select(ci => ci.Ins.Name).ToList(),
                stdcourse = course.StudCourses.Select(cs => cs.Std.Fname).ToList() // Add students
            };

            return Ok(courseInfDTO);
        }


        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseeDTO cr)
        {
            if (id != cr.CourseId)
            {
                return BadRequest(); // Return 400 if ID doesn't match
            }

            var Updatecourse = await _context.Courses.FindAsync(id);
            if (Updatecourse == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            // Update only the class attributes
            Updatecourse.CourseId = cr.CourseId;
            Updatecourse.TopicId = cr.TopicId;
            Updatecourse.CrsName = cr.CrsName;
            Updatecourse.Description = cr.Description;
            Updatecourse.CrsDuration = cr.CrsDuration;



            // Save changes
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content to indicate success
        }
        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseeDTO CD)
        {
            var course = new Course
            {
                CourseId = CD.CourseId,
                TopicId = CD.TopicId,
                CrsName = CD.CrsName,
                Description = CD.Description,
                CrsDuration = CD.CrsDuration,
            };
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return Ok(CD);
        }



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
