using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class EditingRelationsOfStudCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Degree",
                table: "StudCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentStdId",
                table: "course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_StudentStdId",
                table: "course",
                column: "StudentStdId");

            migrationBuilder.AddForeignKey(
                name: "FK_course_student_StudentStdId",
                table: "course",
                column: "StudentStdId",
                principalTable: "student",
                principalColumn: "stdID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_student_StudentStdId",
                table: "course");

            migrationBuilder.DropIndex(
                name: "IX_course_StudentStdId",
                table: "course");

            migrationBuilder.DropColumn(
                name: "StudentStdId",
                table: "course");

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "StudCourses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
