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

            entity.HasOne(d => d.Dept).WithMany()
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dept_instructor_deptid_foreign");

            entity.HasOne(d => d.Ins).WithMany()
                .HasForeignKey(d => d.InsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dept_instructor_insid_foreign");
        }
    }
}
