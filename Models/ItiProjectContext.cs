using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Models;

public partial class ItiProjectContext : DbContext
{
    public ItiProjectContext()
    {
    }

    public ItiProjectContext(DbContextOptions<ItiProjectContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DeptInstructor> DeptInstructors { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<StudCourse> StudCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

}
