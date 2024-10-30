﻿using ITI_Project.DTO;
using ITI_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                    Grade = s.Grade,
                    DeptName = s.Dept.Name,
                    Courses = s.StudCourses.Select(sc => new CourseDTO
                    {
                        CourseId = sc.Course.CourseId,
                        CourseName = sc.Course.CrsName,
                        Degree = sc.Degree
                    }).ToList()
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            var student = await _context.Students
                .Where(s => s.StdId == id)
                .Select(s => new StudentDTO
                {
                    StdId = s.StdId,
                    Fname = s.Fname,
                    Lname = s.Lname,
                    Grade = s.Grade,
                    DeptName = s.Dept.Name,
                    Courses = s.StudCourses.Select(sc => new CourseDTO
                    {
                        CourseId = sc.Course.CourseId,
                        CourseName = sc.Course.CrsName,
                        Degree = sc.Degree
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            // Find the student
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            // Find and remove related records in the StudCourses table
            var studCourses = await _context.StudCourses.Where(sc => sc.StdId == id).ToListAsync();
            _context.StudCourses.RemoveRange(studCourses); // Remove related records

            // Now remove the student
            _context.Students.Remove(student);

            // Save changes
            await _context.SaveChangesAsync();

            return NoContent(); // Return a 204 No Content response
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
