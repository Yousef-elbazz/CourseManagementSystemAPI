using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseInstructorConfigurationByElbaz04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "dept_instructor_deptid_foreign",
                table: "DeptInstructors");

            migrationBuilder.DropForeignKey(
                name: "dept_instructor_insid_foreign",
                table: "DeptInstructors");

            migrationBuilder.AddForeignKey(
                name: "dept_instructor_deptid_foreign",
                table: "DeptInstructors",
                column: "DeptID",
                principalTable: "Department",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "dept_instructor_insid_foreign",
                table: "DeptInstructors",
                column: "InsID",
                principalTable: "Instructor",
                principalColumn: "InsID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "dept_instructor_deptid_foreign",
                table: "DeptInstructors");

            migrationBuilder.DropForeignKey(
                name: "dept_instructor_insid_foreign",
                table: "DeptInstructors");

            migrationBuilder.AddForeignKey(
                name: "dept_instructor_deptid_foreign",
                table: "DeptInstructors",
                column: "DeptID",
                principalTable: "Department",
                principalColumn: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "dept_instructor_insid_foreign",
                table: "DeptInstructors",
                column: "InsID",
                principalTable: "Instructor",
                principalColumn: "InsID");
        }
    }
}
