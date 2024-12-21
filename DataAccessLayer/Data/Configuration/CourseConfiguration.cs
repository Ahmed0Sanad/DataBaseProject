using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configuration
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
        {
            builder.HasMany(c => c.Prerequisites).WithOne(p => p.Course).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c=>c.IsPrerequisiteFor).WithOne(p => p.Prerequisit).OnDelete(DeleteBehavior.NoAction);
           
        }
    }
}
