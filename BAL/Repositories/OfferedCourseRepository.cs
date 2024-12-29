using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BAL.Repositories
{
    public class OfferedCourseRepository : GenericRepository<OfferedCourse>, IOfferdCourseRepository

    {

        public OfferedCourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public override void Add(OfferedCourse entity)
        {
            var properties = typeof(OfferedCourse).GetProperties();

            var FilteredData = properties.Where(c => c.PropertyType.Name != "ICollection`1" && c.Name != "Id" && c.PropertyType.Name != "Course");

            var values = string.Join(", ", FilteredData.Select(

                p => p.PropertyType.Name == "String" ||
                p.PropertyType.Name == "TimeOnly" ||
                p.PropertyType.Name == "DateOnly" ||
                p.PropertyType.Name == "DateTime" ? $"''{p.GetValue(entity)}''" : $"{p.GetValue(entity)}"));

            var quary = $@"
                Exec OfferedCourseInsert @Columns = 'Year, Semester, SectionNum, Time, ClassRoom, CourseId'  ,    @Values = '{values}';";

            _appDbContext.Database.ExecuteSqlRaw(quary);

        }

        public override void Update(OfferedCourse entity)
        {
            string tableName = "OfferedCourses";

            // Use reflection to get the property names and values from the entity
            var properties = typeof(OfferedCourse).GetProperties();
           
            var FilteredData = properties.Where(c => c.PropertyType.Name != "ICollection`1" && c.Name != "Id" && c.PropertyType.Name != "Course");

            // Combine columns and values into a single SET clause
            var setClause = string.Join(", ", FilteredData.Select(p =>
                $"{p.Name} = " +
                (p.PropertyType.Name == "String" ||
                 p.PropertyType.Name == "DateOnly" ||
                 p.PropertyType.Name == "DateTime" ||
                 p.PropertyType.Name == "TimeOnly"
                    ? $"''{p.GetValue(entity)}''"
                    : $"{p.GetValue(entity)}")
            ));
            string whereClause = "CourseId = " + entity.Id+ " AND year = " + entity.Year;

            // Construct the SQL query
            var query = $@"
                EXEC GenericUpdate 
                @TableName = '{tableName}', 
                @SetClause = '{setClause}', 
                @WhereClause = '{whereClause}';";

            // Execute the query
            _appDbContext.Database.ExecuteSqlRaw(query,
                new SqlParameter("@TableName", tableName),
                new SqlParameter("@SetClause", setClause),
                new SqlParameter("@WhereClause", whereClause));

        }
        public override void Delete(OfferedCourse entity)
        {
           
            var quary = $"Exec DeleteOfferedCourse  {entity.CourseId},{entity.Year}";
            _appDbContext.Database.ExecuteSqlRaw(quary);

        }

        public OfferedCourse GetWithYear(int id,int year)
        {
            var entity = _appDbContext.OfferedCourses.FromSqlRaw("Exec GetOfferedCourseWithYear @CourseId,@Year", new SqlParameter("@CourseId", id), new SqlParameter("@Year", year)).AsEnumerable().FirstOrDefault();
            entity.Course = _appDbContext.Courses.FromSqlRaw("Exec GenericGet @TableName,@Id", new SqlParameter("@TableName", "Courses"), new SqlParameter("@Id", entity.CourseId)).AsEnumerable().FirstOrDefault();
            return entity;
        }
        public override IEnumerable<OfferedCourse> GetAll()
        {
            var entitys = _appDbContext.OfferedCourses.FromSqlRaw("Exec GetAllOfferedCourses ").ToList().AsEnumerable();

            foreach (var offeredCourse in entitys)
            {
                
                offeredCourse.Course = _appDbContext.Courses.FromSqlRaw("Exec GenericGet @TableName,@Id", new SqlParameter("@TableName", "Courses"), new SqlParameter("@Id", offeredCourse.CourseId)).AsEnumerable().FirstOrDefault();
            }

            return entitys;
        }

    
        public void AddInstructor(int id, int year, List<int> Instructors) 
        {
            var ins = string.Join(",", Instructors);

            var quary = $"Exec AddInstructorToCourse  {id},{year},'{ins}'";
            _appDbContext.Database.ExecuteSqlRaw(quary);


            //var course = _appDbContext.OfferedCourses.Find(id, year);
            //foreach (int ins in Instructors)
            //{
            //    var instructor = _appDbContext.Instructors.Find(ins);
            //    course.Instructors.Add(instructor);
            //}
         
        }


        public void AddStudents(int id, int year, List<int> students)
        {
            
            var stu = string.Join(",", students);

            var quary = $"Exec AddStudentsToCourse  {id},{year},'{stu}',{0}";
            _appDbContext.Database.ExecuteSqlRaw(quary);


        }
        public IEnumerable<Instructor> GetInstructorsForCourse(OfferedCourse Course)
        {
            //var insInCourse=Course.Instructors.Select(ins=>ins.Id).ToList();
            //var ins = _appDbContext.Instructors.Where(ins => !insInCourse.Contains(ins.Id)).ToList();
            var ins = _appDbContext.Instructors.FromSqlRaw("EXEC GetInstructorsNotInCourse @CourseId, @Year",
                                         new SqlParameter("@CourseId", Course.CourseId),
                                         new SqlParameter("@Year", Course.Year))
                             .ToList();
            return ins;
        }

        public List<Student> GetStudentsForCourse(int id)
        {
            var enrolled = _appDbContext.StudentsCourse.Where(s => s.OfferedCourseId == id).Select(e => e.StudentId).ToList();
            // student how enrolled in that course
            var students = _appDbContext.Students

            .Where(s => !enrolled.Contains(s.Id)).ToList();

            var SC = students.Join(_appDbContext.StudentsCourse,
                s => s.Id,
                c => c.StudentId,
                (s, c) => new { s.Id, c.OfferedCourseId }

                ).GroupBy(sc => sc.Id).Select(sc => new { StudentId = sc.Key, CourseIds = sc.Select(s => s.OfferedCourseId).ToList() }).ToList();
            //___________

            //courses which student took
            var prequestes = _appDbContext.Prequestes
                .Where(p => p.CourseId == id)
                .Select(p => p.PrerequisitId).ToList();

            List<Student> result = new List<Student>();
            if (prequestes.Count > 0)
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
        public IEnumerable<Student> GetStudentsInCourse(int id) 
        {
            var students = _appDbContext.Students.Join(_appDbContext.StudentsCourse,s=>s.Id,sc=>sc.StudentId,(s,sc)=>s).ToList();

            return students;
        }

    }
}
