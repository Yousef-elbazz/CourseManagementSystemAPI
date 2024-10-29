using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<DeptInstructor> DeptInstructors { get; set; } = new List<DeptInstructor>(); // Navigation property

}
