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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void AddPrequestes(int id,List<int> prequests)
        {
            var course = _appDbContext.Courses.Find(id);
            foreach (var pre in prequests)
            {

                course.Prerequisites.Add(new Prequestes() { CourseId = course.Id, PrerequisitId = pre });

            }
        }

        public IEnumerable<Course> GetPrequestes(int id )
        {
           var pre= _appDbContext.Prequestes.Where(p=>p.CourseId == id).Select(p=>p.PrerequisitId).ToList();
            var courses=_appDbContext.Courses.Where(c=>pre.Contains(c.Id)).ToList();

            return courses;
        }

        public void UpdatePrequestes(int id, List<int> prequests)
        {

           var oldprequestes=_appDbContext.Prequestes.Where(p=>p.CourseId==id).ToList();
            _appDbContext.Prequestes.RemoveRange(oldprequestes);
            
            foreach (var pre in prequests)
            {

                _appDbContext.Prequestes.Add(new Prequestes() { CourseId = id, PrerequisitId = pre });

            }
        }
    }
}
