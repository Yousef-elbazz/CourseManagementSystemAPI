using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class DeptInstructor
{
    public int DeptId { get; set; }

    public int InsId { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual Instructor Ins { get; set; } = null!;
}
