using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        public Dictionary<OfferedCourse, int> GetGrades(int id);
    }
}
