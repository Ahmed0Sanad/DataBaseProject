using DataAccessLayer.Data.Migrations;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext: DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses  { get; set; }
        public DbSet<OfferedCourse> OfferedCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enroll> StudentsCourse { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Prequestes> Prequestes { get; set; }



    }
}
