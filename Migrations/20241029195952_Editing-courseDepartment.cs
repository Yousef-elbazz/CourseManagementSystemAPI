using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class EditingcourseDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mgrHiringDate",
                table: "Department");

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    DepartmentsDeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesCourseId, x.DepartmentsDeptId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Department_DepartmentsDeptId",
                        column: x => x.DepartmentsDeptId,
                        principalTable: "Department",
                        principalColumn: "DeptID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_course_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDeptId",
                table: "CourseDepartment",
                column: "DepartmentsDeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.AddColumn<DateOnly>(
                name: "mgrHiringDate",
                table: "Department",
                type: "date",
                nullable: true);
        }
    }
}
