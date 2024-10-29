using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_Project.Configurations
{
    public class courseConfiguration :IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.HasKey(e => e.CourseId).HasName("course_courseid_primary");

            entity.HasMany(d => d.Departments).WithMany(c => c.Courses).UsingEntity(j => j.ToTable("CourseDepartment")); ;

            entity.ToTable("course");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("courseID");
            entity.Property(e => e.CrsDuration).HasColumnName("Crs_Duration");
            entity.Property(e => e.CrsName)
                .HasMaxLength(255)
                .HasColumnName("Crs_Name");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("course_topicid_foreign");
        }
    }
}
