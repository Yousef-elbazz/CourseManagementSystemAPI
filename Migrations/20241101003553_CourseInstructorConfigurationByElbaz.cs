using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseInstructorConfigurationByElbaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "course_topicid_foreign",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_instructor_Instructor_InsId1",
                table: "course_instructor");

            migrationBuilder.DropForeignKey(
                name: "course_instructor_courseid_foreign",
                table: "course_instructor");

            migrationBuilder.DropForeignKey(
                name: "stud_course_courseid_foreign",
                table: "StudCourses");

            migrationBuilder.DropForeignKey(
                name: "stud_course_stdid_foreign",
                table: "StudCourses");

            migrationBuilder.DropIndex(
                name: "IX_course_instructor_InsId1",
                table: "course_instructor");

            migrationBuilder.DropColumn(
                name: "InsId1",
                table: "course_instructor");

            migrationBuilder.AddForeignKey(
                name: "course_topicid_foreign",
                table: "course",
                column: "TopicID",
                principalTable: "topic",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "course_instructor_courseid_foreign",
                table: "course_instructor",
                column: "courseID",
                principalTable: "course",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "stud_course_courseid_foreign",
                table: "StudCourses",
                column: "courseID",
                principalTable: "course",
                principalColumn: "courseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "stud_course_stdid_foreign",
                table: "StudCourses",
                column: "stdID",
                principalTable: "student",
                principalColumn: "stdID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "course_topicid_foreign",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "course_instructor_courseid_foreign",
                table: "course_instructor");

            migrationBuilder.DropForeignKey(
                name: "stud_course_courseid_foreign",
                table: "StudCourses");

            migrationBuilder.DropForeignKey(
                name: "stud_course_stdid_foreign",
                table: "StudCourses");

            migrationBuilder.AddColumn<int>(
                name: "InsId1",
                table: "course_instructor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_course_instructor_InsId1",
                table: "course_instructor",
                column: "InsId1");

            migrationBuilder.AddForeignKey(
                name: "course_topicid_foreign",
                table: "course",
                column: "TopicID",
                principalTable: "topic",
                principalColumn: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_course_instructor_Instructor_InsId1",
                table: "course_instructor",
                column: "InsId1",
                principalTable: "Instructor",
                principalColumn: "InsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "course_instructor_courseid_foreign",
                table: "course_instructor",
                column: "courseID",
                principalTable: "course",
                principalColumn: "courseID");

            migrationBuilder.AddForeignKey(
                name: "stud_course_courseid_foreign",
                table: "StudCourses",
                column: "courseID",
                principalTable: "course",
                principalColumn: "courseID");

            migrationBuilder.AddForeignKey(
                name: "stud_course_stdid_foreign",
                table: "StudCourses",
                column: "stdID",
                principalTable: "student",
                principalColumn: "stdID");
        }
    }
}
