using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Configurations
{
    public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> entity)
        {
            entity
               .HasNoKey()
               .ToTable("course-Instructor");

            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.Evaluation).HasColumnType("text");
            entity.Property(e => e.InsId).HasColumnName("InsID");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_instructor_courseid_foreign");

            entity.HasOne(d => d.Ins).WithMany()
                .HasForeignKey(d => d.InsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_instructor_insid_foreign");
        }
    }

}
