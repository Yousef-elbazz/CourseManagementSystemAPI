using System;
using System.Collections.Generic;

namespace ITI_Project.Models;

public partial class Topic
{
    public int TopicId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
