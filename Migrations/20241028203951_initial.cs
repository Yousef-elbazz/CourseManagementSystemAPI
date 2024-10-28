using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DeptID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mgrHiringDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("department_deptid_primary", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HourRate = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("instructor_insid_primary", x => x.InsID);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("topic_topicid_primary", x => x.TopicID);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    stdID = table.Column<int>(type: "int", nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student_stdid_primary", x => x.stdID);
                    table.ForeignKey(
                        name: "student_deptid_foreign",
                        column: x => x.DeptID,
                        principalTable: "Department",
                        principalColumn: "DeptID");
                });

            migrationBuilder.CreateTable(
                name: "DeptInstructors",
                columns: table => new
                {
                    DeptID = table.Column<int>(type: "int", nullable: false),
                    InsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptInstructors", x => new { x.InsID, x.DeptID });
                    table.ForeignKey(
                        name: "dept_instructor_deptid_foreign",
                        column: x => x.DeptID,
                        principalTable: "Department",
                        principalColumn: "DeptID");
                    table.ForeignKey(
                        name: "dept_instructor_insid_foreign",
                        column: x => x.InsID,
                        principalTable: "Instructor",
                        principalColumn: "InsID");
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    courseID = table.Column<int>(type: "int", nullable: false),
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    Crs_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Crs_Duration = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("course_courseid_primary", x => x.courseID);
                    table.ForeignKey(
                        name: "course_topicid_foreign",
                        column: x => x.TopicID,
                        principalTable: "topic",
                        principalColumn: "TopicID");
                });

            migrationBuilder.CreateTable(
                name: "course-Instructor",
                columns: table => new
                {
                    InsID = table.Column<int>(type: "int", nullable: false),
                    courseID = table.Column<int>(type: "int", nullable: false),
                    Evaluation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "course_instructor_courseid_foreign",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID");
                    table.ForeignKey(
                        name: "course_instructor_insid_foreign",
                        column: x => x.InsID,
                        principalTable: "Instructor",
                        principalColumn: "InsID");
                });

            migrationBuilder.CreateTable(
                name: "StudCourses",
                columns: table => new
                {
                    stdID = table.Column<int>(type: "int", nullable: false),
                    courseID = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourses", x => new { x.stdID, x.courseID });
                    table.ForeignKey(
                        name: "stud_course_courseid_foreign",
                        column: x => x.courseID,
                        principalTable: "course",
                        principalColumn: "courseID");
                    table.ForeignKey(
                        name: "stud_course_stdid_foreign",
                        column: x => x.stdID,
                        principalTable: "student",
                        principalColumn: "stdID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_TopicID",
                table: "course",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_course-Instructor_courseID",
                table: "course-Instructor",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_course-Instructor_InsID",
                table: "course-Instructor",
                column: "InsID");

            migrationBuilder.CreateIndex(
                name: "IX_DeptInstructors_DeptID",
                table: "DeptInstructors",
                column: "DeptID");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_courseID",
                table: "StudCourses",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_student_DeptID",
                table: "student",
                column: "DeptID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course-Instructor");

            migrationBuilder.DropTable(
                name: "DeptInstructors");

            migrationBuilder.DropTable(
                name: "StudCourses");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
