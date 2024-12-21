using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configuration
{
    internal class EnrollConfiguration : IEntityTypeConfiguration<Enroll>
    {
        public void Configure(EntityTypeBuilder<Enroll> builder)
        {
            builder.Ignore(e => e.Id);
            builder
        .HasKey(e => new { e.StudentId, e.OfferedCourseId, e.Year }); // Define primary key for Enroll

            builder
                .HasOne(e => e.OfferedCourse)
                .WithMany(o => o.StudentCourses)
                .HasForeignKey(e => new { e.OfferedCourseId, e.Year }) // Use individual properties for composite foreign key
                .OnDelete(DeleteBehavior.Cascade); // Optional: Define cascade delete behavior
        }
    }
}
