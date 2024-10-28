using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string? Name { get; set; }

    public DateOnly? MgrHiringDate { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
