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
                .HasKey(ci => new { ci.CourseId, ci.InsId }) // Composite primary key
                .HasName("PK_CourseInstructor");

            entity.ToTable("course_instructor");

            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.InsId).HasColumnName("InsID");
            entity.Property(e => e.Evaluation).HasColumnType("text");

            entity.HasIndex(ci => new { ci.CourseId, ci.InsId })
                .IsUnique()
                .HasDatabaseName("IX_Unique_CourseInstructor");

            // Configuring the relationships
            entity.HasOne(ci => ci.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("course_instructor_courseid_foreign");

            entity.HasOne(ci => ci.Ins)
                .WithMany(i => i.CourseInstructors)
                .HasForeignKey(ci => ci.InsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_instructor_insid_foreign");
        }
    }
}
