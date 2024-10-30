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
        //[HttpGet("{id}")]
        //public async Task<ActionResult<InstractorDTO>> getID(int id)
        //{

        //}
        //[HttpPut("{id}")]
        //public async Task<>



    } 
}
