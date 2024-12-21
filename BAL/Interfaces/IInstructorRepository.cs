using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {
        public IEnumerable<Instructor> GetForCourse(OfferedCourse Course);
    }
}
