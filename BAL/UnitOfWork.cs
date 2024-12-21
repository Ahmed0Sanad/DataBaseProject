using BAL.Interfaces;
using BAL.Repositories;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ICourseRepository _courseRepository;
        private IOfferdCourseRepository _offerdCourseRepository;
        private IInstructorRepository _instructorRepository;
        private IStudentRepository _studentRepository;
        private IEnrollRepository _enrollRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICourseRepository Courses { get { return _courseRepository ??= new CourseRepository(_appDbContext); } }

        public IOfferdCourseRepository OfferdCourse { get { return _offerdCourseRepository ??= new OfferedCourseRepository(_appDbContext); } }

        public IStudentRepository Students { get { return _studentRepository ??= new StudentRepository(_appDbContext); } }

        public IInstructorRepository Instructors { get {return _instructorRepository??= new InstructorRepository(_appDbContext); } }

        public IEnrollRepository Enrolls { get { return _enrollRepository??=new EnrollRepository(_appDbContext); } }
        public int Complete()
        {
          return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
