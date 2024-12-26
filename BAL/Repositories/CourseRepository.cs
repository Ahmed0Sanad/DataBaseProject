using BAL.Interfaces;
using BAL.Repositories;
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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        
        public void AddPrequestes(int id,List<int> prequests)
        {

            var pre = string.Join(",", prequests);

            var quary = $"Exec AddPrequestsToCourse  {id},'{pre}'";
            _appDbContext.Database.ExecuteSqlRaw(quary);

        }

        public IEnumerable<Course> GetPrequestes(int id )
        {
           var courses = _appDbContext.Courses.FromSqlRaw("Exec GetPrequestes @Id",  new SqlParameter("@Id", id)).ToList();

            return courses;
        }

        public void UpdatePrequestes(int id, List<int> prequests)
        {


            var pre = string.Join(",", prequests);

            var quary = $"Exec UpdatePrequestes  {id},'{pre}'";
            _appDbContext.Database.ExecuteSqlRaw(quary);
        }
    }
}
