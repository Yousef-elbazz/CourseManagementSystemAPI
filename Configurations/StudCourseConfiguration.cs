using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Configurations
{
    public class StudCourseConfiguration : IEntityTypeConfiguration<StudCourse>
    {
        public void Configure(EntityTypeBuilder<StudCourse> entity)
        {
            entity.HasKey(k => new { k.StdId, k.CourseId });

            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.StdId).HasColumnName("stdID");

            entity.HasOne(d => d.Course)
                 .WithMany(p => p.StudCourses)
                 .HasForeignKey(d => d.CourseId)
                 .OnDelete(DeleteBehavior.Restrict) // Change to cascade
                 .HasConstraintName("stud_course_courseid_foreign");

            entity.HasOne(d => d.Std)
                .WithMany(p => p.StudCourses)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.Restrict) // Change to cascade
                .HasConstraintName("stud_course_stdid_foreign");
        }
    }
}
