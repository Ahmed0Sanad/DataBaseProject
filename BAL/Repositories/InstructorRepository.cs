﻿using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public IEnumerable<Instructor> GetForCourse(OfferedCourse Course)
        {
            //var insInCourse=Course.Instructors.Select(ins=>ins.Id).ToList();
            //var ins = _appDbContext.Instructors.Where(ins => !insInCourse.Contains(ins.Id)).ToList();
            var ins = _appDbContext.Instructors.FromSqlRaw("EXEC GetInstructorsNotInCourse @CourseId, @Year",
                                         new SqlParameter("@CourseId", Course.CourseId),
                                         new SqlParameter("@Year", Course.Year))
                             .ToList();
            return ins;
        }
    }
}
