using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public ICourseRepository Courses { get; }
        public IOfferdCourseRepository OfferdCourse { get; }
        public IStudentRepository Students { get; }
        public IInstructorRepository Instructors { get; }
        //public IEnrollRepository Enrolls { get; }
        //public int Complete();

    }
}
