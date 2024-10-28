using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class Student
{
    public int StdId { get; set; }

    public int DeptId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public int Age { get; set; }

    public string? Address { get; set; }

    public string? Grade { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
