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
                .Include(s=>s.Courses)
                .Include(s=>s.StdDegree)
                .Where(s => s.StdId == id)
                .Select(s => new StudentDTO
                {
                    StdId = s.StdId,
                    Fname = s.Fname,
                    Lname = s.Lname,
                    DeptName = s.Dept.Name,
                    Grade = s.Grade,
                    Courses = s.Courses.Select(s => s.CrsName).ToList(),
                    Degree = s.StdDegree.Degree,
                }).FirstOrDefaultAsync();
            return Ok(student);
        }
        public async Task<IActionResult> deleteone(int id)
        {

            var deleteStudent = await _context.Students.FirstOrDefaultAsync(x => x.StdId == id);
            if (deleteStudent == null)
            {
                return NotFound($"the id {id} is not exist");
            }
            _context.Students.Remove(deleteStudent);
            _context.SaveChanges();
            return Ok(deleteStudent);
        }

        [HttpPost] // add
        public async Task<IActionResult> Add(int id, string Fname, string Lname, int age , string address , Department Did , string grade)
        {
            Student student = new()
            {
                StdId = id,
                Fname = Fname,
                Lname = Lname,
               Age = age,
               Address = address,
               DeptId = Did.DeptId,
               Grade = grade,

            };
            await _context.Students.AddAsync(student);
            _context.SaveChanges();
            return Ok();
        }

        /*
                 [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStd(int id)
        {

            var deleteStudent = await _context.Students.FirstOrDefaultAsync(x => x.StdId == id);
            if (deleteStudent == null)
            {
                return NotFound($"the id {id} is not exist");
            }
            
            _context.SaveChanges();
            return Ok(deleteStudent);
        }
         */

    }
}
