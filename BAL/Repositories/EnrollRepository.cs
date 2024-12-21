using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Migrations;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class EnrollRepository : GenericRepository<Enroll>, IEnrollRepository
    {
        public EnrollRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public List<Student> GetForCourse(int id)
        {
            var enrolled = _appDbContext.StudentsCourse.Where(s => s.OfferedCourseId == id).Select(e => e.StudentId).ToList();
           // student how enrolled in that course
            var students = _appDbContext.Students
            .Where(s => !enrolled.Contains(s.Id)).ToList();
            //we have student whose do not enroll in that course
            //var courses = _appDbContext.StudentsCourse
            //    .Where(s => students.Contains(s.StudentId)).GroupBy(s => s.StudentId).Select(g => new
            //    {
            //        StudentId = g.Key,
            //        CourseIds = g.Select(s => s.OfferedCourseId).ToList()
            //    }).ToList();
            //___________
            var SC = students.Join(_appDbContext.StudentsCourse,
                s => s.Id,
                c => c.StudentId,
                (s, c) => new {s.Id,c.OfferedCourseId }

                ).GroupBy(sc => sc.Id).Select(sc => new { StudentId=sc.Key, CourseIds=sc.Select(s=>s.OfferedCourseId).ToList() }).ToList();
            //___________

            //courses which student took
            var prequestes = _appDbContext.Prequestes
                .Where(p => p.CourseId == id)
                .Select(p => p.PrerequisitId).ToList();

            List<Student> result = new List<Student>();
            if(prequestes.Count > 0)
            {
                foreach (var student in SC)
                {


                    if (prequestes.All(pr => student.CourseIds.Contains(pr)))
                    {
                        var sturesult = _appDbContext.Students.SingleOrDefault(s => s.Id == student.StudentId);
                        result.Add(sturesult);
                    }
                }
            }
            else
            {
                result.AddRange(students);

            }
          

            return result;
        }

 
    }
}
