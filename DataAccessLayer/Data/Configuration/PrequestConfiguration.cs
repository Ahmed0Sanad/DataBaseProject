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
    internal class PrequestConfiguration : IEntityTypeConfiguration<Prequestes>
    {
        public void Configure(EntityTypeBuilder<Prequestes> builder)
        {
            builder.HasKey(p => new {p.PrerequisitId,p.CourseId});
        }
    }
}
