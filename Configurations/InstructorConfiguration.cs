using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.HasKey(e => e.InsId).HasName("instructor_insid_primary");

            entity.ToTable("Instructor");

            entity.Property(e => e.InsId)
                .ValueGeneratedNever()
                .HasColumnName("InsID");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.HourRate)
                .HasColumnName("HourRate");

            entity.Property(e => e.Salary)
                .HasColumnName("Salary");

            // Configuring Many-to-Many relationship with Course via CourseInstructor
            entity.HasMany(i => i.CourseInstructors)
                .WithOne()
                .HasForeignKey(ci => ci.InsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_instructor_insid_foreign");
        }
    }
}
