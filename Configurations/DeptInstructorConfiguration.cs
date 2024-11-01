using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ITI_Project.Configurations
{
    public class DeptInstructorConfiguration : IEntityTypeConfiguration<DeptInstructor>
    {
        public void Configure(EntityTypeBuilder<DeptInstructor> entity)
        {
            entity.HasKey(k => new { k.InsId, k.DeptId });

            entity.Property(e => e.DeptId).HasColumnName("DeptID");
            entity.Property(e => e.InsId).HasColumnName("InsID");

            // Configure foreign key from DeptInstructor to Department with Restrict delete behavior
            entity.HasOne(d => d.Dept)
                .WithMany(d => d.DeptInstructors)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("dept_instructor_deptid_foreign");

            // Configure foreign key from DeptInstructor to Instructor with ClientSetNull delete behavior
            entity.HasOne(d => d.Ins)
                .WithMany(i => i.DeptInstructors)
                .HasForeignKey(d => d.InsId)
                .OnDelete(DeleteBehavior.Restrict) 
                .HasConstraintName("dept_instructor_insid_foreign");
        }
    }
}
