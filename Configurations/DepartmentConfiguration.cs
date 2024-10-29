using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ITI_Project.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(e => e.DeptId).HasName("department_deptid_primary");

            entity.HasMany(c => c.Courses).WithMany(d=>d.Departments).UsingEntity(j => j.ToTable("CourseDepartment")); ;

            entity.ToTable("Department");

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("DeptID");
            entity.Property(e => e.Name).HasMaxLength(255);
        }
    }
}
