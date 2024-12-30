﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241230145020_ensure")]
    partial class ensure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Syllabus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Enroll", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("OfferedCourseId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "OfferedCourseId", "Year");

                    b.HasIndex("OfferedCourseId", "Year");

                    b.ToTable("StudentsCourse");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birth")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("DataAccessLayer.Models.OfferedCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoom")
                        .HasColumnType("int");

                    b.Property<int>("SectionNum")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("CourseId", "Year");

                    b.ToTable("OfferedCourses");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Prequestes", b =>
                {
                    b.Property<int>("PrerequisitId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("PrerequisitId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Prequestes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Birth")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("InstructorOfferedCourse", b =>
                {
                    b.Property<int>("InstructorsId")
                        .HasColumnType("int");

                    b.Property<int>("OfferedCoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("OfferedCoursesYear")
                        .HasColumnType("int");

                    b.HasKey("InstructorsId", "OfferedCoursesCourseId", "OfferedCoursesYear");

                    b.HasIndex("OfferedCoursesCourseId", "OfferedCoursesYear");

                    b.ToTable("InstructorOfferedCourse");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Enroll", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.OfferedCourse", "OfferedCourse")
                        .WithMany("StudentCourses")
                        .HasForeignKey("OfferedCourseId", "Year")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfferedCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccessLayer.Models.OfferedCourse", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Course", "Course")
                        .WithMany("OfferedCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Prequestes", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Course", "Course")
                        .WithMany("Prerequisites")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.Course", "Prerequisit")
                        .WithMany("IsPrerequisiteFor")
                        .HasForeignKey("PrerequisitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Prerequisit");
                });

            modelBuilder.Entity("InstructorOfferedCourse", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Models.OfferedCourse", null)
                        .WithMany()
                        .HasForeignKey("OfferedCoursesCourseId", "OfferedCoursesYear")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Models.Course", b =>
                {
                    b.Navigation("IsPrerequisiteFor");

                    b.Navigation("OfferedCourses");

                    b.Navigation("Prerequisites");
                });

            modelBuilder.Entity("DataAccessLayer.Models.OfferedCourse", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
