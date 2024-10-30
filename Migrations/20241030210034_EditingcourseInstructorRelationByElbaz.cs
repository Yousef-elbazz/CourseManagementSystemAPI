using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class EditingcourseInstructorRelationByElbaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_course-Instructor_courseID",
                table: "course-Instructor");

            migrationBuilder.RenameTable(
                name: "course-Instructor",
                newName: "course_instructor");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructor",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_course-Instructor_InsID",
                table: "course_instructor",
                newName: "IX_course_instructor_InsID");

            migrationBuilder.AddColumn<int>(
                name: "InsId1",
                table: "course_instructor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseInstructor",
                table: "course_instructor",
                columns: new[] { "courseID", "InsID" });

            migrationBuilder.CreateIndex(
                name: "IX_course_instructor_InsId1",
                table: "course_instructor",
                column: "InsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_course_instructor_Instructor_InsId1",
                table: "course_instructor",
                column: "InsId1",
                principalTable: "Instructor",
                principalColumn: "InsID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_instructor_Instructor_InsId1",
                table: "course_instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseInstructor",
                table: "course_instructor");

            migrationBuilder.DropIndex(
                name: "IX_course_instructor_InsId1",
                table: "course_instructor");

            migrationBuilder.DropColumn(
                name: "InsId1",
                table: "course_instructor");

            migrationBuilder.RenameTable(
                name: "course_instructor",
                newName: "course-Instructor");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Instructor",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_course_instructor_InsID",
                table: "course-Instructor",
                newName: "IX_course-Instructor_InsID");

            migrationBuilder.CreateIndex(
                name: "IX_course-Instructor_courseID",
                table: "course-Instructor",
                column: "courseID");
        }
    }
}
