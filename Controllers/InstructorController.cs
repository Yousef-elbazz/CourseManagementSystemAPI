using ITI_Project.DTO;
using ITI_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly ItiProjectContext _DB;
        public InstructorController(ItiProjectContext DB)
        {
            _DB = DB;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstractorDTO>>> getall()
        {
            var instractor = await _DB.Instructors.ToListAsync();
            var AllAtt = instractor.Select(s => new InstractorDTO
            {
                Id = s.InsId,
                Name = s.Name,
                HourRate = s.HourRate,
                Salary = s.Salary,
                Address = s.Address,
                DepartmentNames = s.DeptInstructors.Select(f => f.Dept.Name).ToList(),
                Courses = s.CourseInstructors.Select(f =>f.Course.CrsName).ToList()

            }).ToList();
            return Ok(getall);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InstractorDTO>> getID(int id)
        {
            var instractor = await _DB.Instructors
                .Include(s=>s.CourseInstructors)
                .ThenInclude(s=>s.CourseId)
                .Include(s=>s.DeptInstructors)
                .ThenInclude(d=>d.DeptId)
                .FirstOrDefaultAsync(k=>k.InsId==id);
            if (instractor == null)
                return NotFound();

            var data = new InstractorDTO
            {
                Id = instractor.InsId,
                Name = instractor.Name,
                Address = instractor.Address,
                Salary = instractor.Salary,
                HourRate = instractor.HourRate,
                DepartmentNames = instractor.DeptInstructors.Select(f => f.Dept.Name).ToList(),
                Courses = instractor.CourseInstructors.Select(f => f.Course.CrsName).ToList()
            };
            return Ok(data);

        }

        [HttpPut("{id}")]
        public async Task <IActionResult> put(int id, [FromBody] InstractorDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();
            var UpdateIns =await _DB.Instructors.FindAsync(id);
            if (UpdateIns == null)
                return NotFound();

            UpdateIns.InsId = dto.Id;
            UpdateIns.Name = dto.Name;
            UpdateIns.Address = dto.Address;
            UpdateIns.HourRate = dto.HourRate;
            UpdateIns.Salary = dto.Salary;

            await _DB.SaveChangesAsync();
            return NoContent();


        }

        [HttpPost]
        public async Task<IActionResult> post(int id , int salary , int hourrate, string address,string name )
        {
            if(_DB.Instructors.Any(g=>g.InsId ==id))
                return BadRequest("instructor is exist");

            Instructor inst = new()
            {
                InsId = id,
                Name = name,
                Address = address,
                Salary = salary,
                HourRate = hourrate,


            };
            await _DB.AddAsync(inst);
            await _DB.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> delete(int id)
        {
            var instructor = await _DB.Instructors.FindAsync( id);
            if (instructor == null) 
                return NotFound();
            var deleteCourse = await _DB.CourseInstructors.Where(l=>l.InsId == id).ToListAsync();
            _DB.CourseInstructors.RemoveRange(deleteCourse);
            var deletedept = await _DB.DeptInstructors.Where(k=>k.InsId == id).ToListAsync();
            _DB.DeptInstructors.RemoveRange(deletedept);

            await _DB.SaveChangesAsync();
          return  NoContent();
        }

    } 
}
