using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public Dictionary<OfferedCourse,int> GetGrades(int id) 
        {
            var dic = _appDbContext.StudentsCourse
        .Where(s => s.StudentId == id).Include(sc=>sc.OfferedCourse).ThenInclude(oc=>oc.Course)
        .ToDictionary(s => s.OfferedCourse, s => s.Grade);
            return dic;
        }
    }
}
