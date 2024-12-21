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

    
        public void AddInstructor(int id, int year, List<int> Instructors) 
        {
            var course = _appDbContext.OfferedCourses.Find(id, year);
            foreach (int ins in Instructors)
            {
                var instructor = _appDbContext.Instructors.Find(ins);
                course.Instructors.Add(instructor);
            }
         
        }

        public OfferedCourse GetWithInstructors(int id, int year)
        {
           
            return _appDbContext.OfferedCourses.Include(c => c.Course).Include(c => c.Instructors).FirstOrDefault(c => (c.CourseId == id && c.Year == year));
        }
    }
}
