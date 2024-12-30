using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IOfferdCourseRepository:IGenericRepository<OfferedCourse>
    {
        public  OfferedCourse GetWithYear(int id, int year);
        public void AddInstructor(int id,int year, List<int> Instructors);

        public IEnumerable<Instructor> GetInstructorsForCourse(OfferedCourse Course);
        public List<Student> GetStudentsForCourse(int id);

        public void AddStudents(int id, int year, List<int> students);
        public Dictionary<Student, int> GetStudentsInCourse(int id, int year);
        public void AddGrades(int id , int year, Dictionary<int,int> grades);


    }
    
}
