using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models;

public partial class Course
{

    public int CourseId { get; set; }

    public int TopicId { get; set; }

    public string? CrsName { get; set; }

    public int? CrsDuration { get; set; }

    public string? Description { get; set; }

    public virtual Topic Topic { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();


}
