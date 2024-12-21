using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configuration
{
    internal class OfferedCourseConfiguration : IEntityTypeConfiguration<OfferedCourse>
    {
        public void Configure(EntityTypeBuilder<OfferedCourse> builder)
        {
            builder.Ignore(o=>o.Id);
            builder.HasKey(o=>new { o.CourseId,o.Year });
            builder.HasOne(O=>O.Course).WithMany(C=>C.OfferedCourses).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(O => O.Instructors).WithMany(I => I.OfferedCourses);
            builder.HasMany(O => O.StudentCourses).WithOne(SC => SC.OfferedCourse);
        }
    }
}
