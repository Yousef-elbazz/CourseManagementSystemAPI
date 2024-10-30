using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class StudCourse
{
    public int StdId { get; set; }

    public int CourseId { get; set; }

    public string? Degree { get; set; }
    public virtual Student Std { get; set; }
    public virtual Course Course { get; set; }
}
