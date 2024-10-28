using ITI_Project.DTO;
using ITI_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ItiProjectContext _context;

        public StudentController(ItiProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var students = await _context.Students
                .Select(s => new StudentDTO
                {
                    StdId = s.StdId,
                    Fname = s.Fname,
                    Lname = s.Lname,
                    DeptName = s.Dept.Name,
                    Grade = s.Grade,
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)//5
        {
            var student = await _context.Students
                .Include(s => s.Dept)
                .Where(s => s.StdId == id)
                .Select(s => new StudentDTO
                {
                    StdId = s.StdId,
                    Fname = s.Fname,
                    Lname = s.Lname,
                    DeptName = s.Dept.Name,
                    Grade = s.Grade,
                }).FirstOrDefaultAsync();
            return Ok(student);

        }
        
        //implicitly typed local variable ===>VAR




    }
}
