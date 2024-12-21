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
    public class OfferedCourseRepository : GenericRepository<OfferedCourse>, IOfferdCourseRepository

    {

        public OfferedCourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public  OfferedCourse GetWithYear(int id,int year)
        {
            return _appDbContext.OfferedCourses.Include(c => c.Course).FirstOrDefault(c=>(c.CourseId==id &&c.Year==year));
        }
        public override IEnumerable<OfferedCourse> GetAll()
        {
            return _appDbContext.OfferedCourses.Include(c => c.Course).AsNoTracking().ToList();
        }

        public override void Delete(OfferedCourse entity)
        {
            _appDbContext.OfferedCourses.Remove(entity);
        }

    }
}
