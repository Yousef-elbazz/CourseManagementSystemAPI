using ITI_Project.DTO;
using ITI_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace ITI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ItiProjectContext _context; // Replace with your actual DbContext class

        public DepartmentController(ItiProjectContext context)
        {
            _context = context;
        }

        // GET: api/department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAll()
        {
            var departments = await _context.Departments.ToListAsync();

            // Map to DTOs
            var departmentDtos = departments.Select(d => new DepartmentDTO
            {
                Id = d.DeptId,
                Name = d.Name,
                StudentNames = d.Students.Select(s => s.Fname).ToList(), // Only include names
                InstructorNames = d.DeptInstructors.Select(i => i.Ins.Name).ToList() // Only include names
            }).ToList();

            return Ok(departmentDtos);
        }

        // GET: api/department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetById(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Students)
                .Include(d => d.DeptInstructors) // Make sure to include this for instructors
                    .ThenInclude(di => di.Ins) // To get the instructor's details
                .FirstOrDefaultAsync(d => d.DeptId == id);

            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            // Map to DepartmentDTO
            var departmentDto = new DepartmentDTO
            {
                Id = department.DeptId,
                Name = department.Name,
                StudentNames = department.Students.Select(s => s.Fname).ToList(), // Get student names
                InstructorNames = department.DeptInstructors.Select(i => i.Ins.Name).ToList() // Get instructor names
            };

            return Ok(departmentDto); // Return 200 OK with the DTO
        }
        // PUT: api/department/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentDTO departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest(); // Return 400 if ID doesn't match
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            // Update only the class attributes
            department.Name = departmentDto.Name;

            // Save changes
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content to indicate success
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> Adddepart([FromBody] DepartmenttDTO CD)
        {
            var Dept = new Department
            {
               DeptId = CD.Id,
               Name = CD.Name,
            };
            await _context.Departments.AddAsync(Dept);
            await _context.SaveChangesAsync();

            return Ok(CD);
        }



    }
    public class DepartmenttDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
    }


    /*

    // POST: api/department
    [HttpPost]
    public async Task<ActionResult<DepartmentDTO>> Post([FromBody] DepartmentDTO departmentDto)
    {
        var department = new Department
        {
            Name = departmentDto.Name,
            // Initialize lists if needed
            Students = new List<Student>(), // If you want to handle students
            // Instructors can be handled later based on your design
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        // Map the created department to DTO
        departmentDto.Id = department.DeptId;

        return CreatedAtAction(nameof(GetById), new { id = departmentDto.Id }, departmentDto); // Return 201 Created
    }
    */
    // DELETE: api/department/{id}
    /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content to indicate success
        }
    }*/
}


