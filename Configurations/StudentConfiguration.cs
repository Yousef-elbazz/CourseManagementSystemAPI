using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ITI_Project.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.HasKey(e => e.StdId).HasName("student_stdid_primary");

            entity.ToTable("student");

            entity.Property(e => e.StdId)
                .ValueGeneratedNever()
                .HasColumnName("stdID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DeptId).HasColumnName("DeptID");
            entity.Property(e => e.Fname).HasMaxLength(255);
            entity.Property(e => e.Grade).HasMaxLength(255);
            entity.Property(e => e.Lname).HasMaxLength(255);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_deptid_foreign");
        }
    }
}
