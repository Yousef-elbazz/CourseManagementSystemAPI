﻿// <auto-generated />
using System;
using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITI_Project.Migrations
{
    [DbContext(typeof(ItiProjectContext))]
    partial class ItiProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsDeptId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "DepartmentsDeptId");

                    b.HasIndex("DepartmentsDeptId");

                    b.ToTable("CourseDepartment", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseID");

                    b.Property<int?>("CrsDuration")
                        .HasColumnType("int")
                        .HasColumnName("Crs_Duration");

                    b.Property<string>("CrsName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Crs_Name");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int")
                        .HasColumnName("TopicID");

                    b.HasKey("CourseId")
                        .HasName("course_courseid_primary");

                    b.HasIndex("TopicId");

                    b.ToTable("course", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseID");

                    b.Property<int>("InsId")
                        .HasColumnType("int")
                        .HasColumnName("InsID");

                    b.Property<string>("Evaluation")
                        .HasColumnType("text");

                    b.Property<int>("InsId1")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "InsId")
                        .HasName("PK_CourseInstructor");

                    b.HasIndex("InsId");

                    b.HasIndex("InsId1");

                    b.ToTable("course_instructor", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("DeptID");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DeptId")
                        .HasName("department_deptid_primary");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.DeptInstructor", b =>
                {
                    b.Property<int>("InsId")
                        .HasColumnType("int")
                        .HasColumnName("InsID");

                    b.Property<int>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("DeptID");

                    b.HasKey("InsId", "DeptId");

                    b.HasIndex("DeptId");

                    b.ToTable("DeptInstructors");
                });

            modelBuilder.Entity("ITI_Project.Models.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .HasColumnType("int")
                        .HasColumnName("InsID");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("address");

                    b.Property<int?>("HourRate")
                        .HasColumnType("int")
                        .HasColumnName("HourRate");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("Salary");

                    b.HasKey("InsId")
                        .HasName("instructor_insid_primary");

                    b.ToTable("Instructor", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.StudCourse", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int")
                        .HasColumnName("stdID");

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("courseID");

                    b.Property<int?>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StdId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudCourses");
                });

            modelBuilder.Entity("ITI_Project.Models.Student", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int")
                        .HasColumnName("stdID");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("address");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<int>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("DeptID");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Grade")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("StdId")
                        .HasName("student_stdid_primary");

                    b.HasIndex("DeptId");

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("ITI_Project.Models.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .HasColumnType("int")
                        .HasColumnName("TopicID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TopicId")
                        .HasName("topic_topicid_primary");

                    b.ToTable("topic", (string)null);
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("ITI_Project.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITI_Project.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITI_Project.Models.Course", b =>
                {
                    b.HasOne("ITI_Project.Models.Topic", "Topic")
                        .WithMany("Courses")
                        .HasForeignKey("TopicId")
                        .IsRequired()
                        .HasConstraintName("course_topicid_foreign");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("ITI_Project.Models.CourseInstructor", b =>
                {
                    b.HasOne("ITI_Project.Models.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("course_instructor_courseid_foreign");

                    b.HasOne("ITI_Project.Models.Instructor", null)
                        .WithMany("CourseInstructors")
                        .HasForeignKey("InsId")
                        .IsRequired()
                        .HasConstraintName("course_instructor_insid_foreign");

                    b.HasOne("ITI_Project.Models.Instructor", "Ins")
                        .WithMany()
                        .HasForeignKey("InsId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Ins");
                });

            modelBuilder.Entity("ITI_Project.Models.DeptInstructor", b =>
                {
                    b.HasOne("ITI_Project.Models.Department", "Dept")
                        .WithMany("DeptInstructors")
                        .HasForeignKey("DeptId")
                        .IsRequired()
                        .HasConstraintName("dept_instructor_deptid_foreign");

                    b.HasOne("ITI_Project.Models.Instructor", "Ins")
                        .WithMany("DeptInstructors")
                        .HasForeignKey("InsId")
                        .IsRequired()
                        .HasConstraintName("dept_instructor_insid_foreign");

                    b.Navigation("Dept");

                    b.Navigation("Ins");
                });

            modelBuilder.Entity("ITI_Project.Models.StudCourse", b =>
                {
                    b.HasOne("ITI_Project.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("stud_course_courseid_foreign");

                    b.HasOne("ITI_Project.Models.Student", "Std")
                        .WithMany()
                        .HasForeignKey("StdId")
                        .IsRequired()
                        .HasConstraintName("stud_course_stdid_foreign");

                    b.Navigation("Course");

                    b.Navigation("Std");
                });

            modelBuilder.Entity("ITI_Project.Models.Student", b =>
                {
                    b.HasOne("ITI_Project.Models.Department", "Dept")
                        .WithMany("Students")
                        .HasForeignKey("DeptId")
                        .IsRequired()
                        .HasConstraintName("student_deptid_foreign");

                    b.Navigation("Dept");
                });

            modelBuilder.Entity("ITI_Project.Models.Course", b =>
                {
                    b.Navigation("CourseInstructors");
                });

            modelBuilder.Entity("ITI_Project.Models.Department", b =>
                {
                    b.Navigation("DeptInstructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ITI_Project.Models.Instructor", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("DeptInstructors");
                });

            modelBuilder.Entity("ITI_Project.Models.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
