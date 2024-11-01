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

        // DELETE: api/department/{id}
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            try
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                Console.Error.WriteLine($"Error deleting department: {ex.Message}");
                return BadRequest("An error occurred while deleting the department.");
            }
        }
        #endregion

        // GET: api/department
        #region GetAll
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
        #endregion

        // GET: api/department/{id}
        #region GetByID
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
        #endregion

        // PUT: api/department/{id}
        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmenttDTO departmentDto)
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
        #endregion

        // POST: api/Courses
        #region Post
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
        #endregion

    }
  


   

   
   
}



