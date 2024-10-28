using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class CourseInstructor
{
    public int InsId { get; set; }

    public int CourseId { get; set; }

    public string? Evaluation { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Instructor Ins { get; set; } = null!;
}
