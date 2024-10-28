using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class Instructor
{
    public int InsId { get; set; }

    public string? Name { get; set; }

    public int? HourRate { get; set; }

    public int? Salary { get; set; }

    public string? Address { get; set; }
}
