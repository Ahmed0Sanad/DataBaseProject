using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        public IEnumerable<Course> GetPrequestes(int id);

        public void AddPrequestes(int id ,List<int> prequests);
        public void UpdatePrequestes(int id, List<int> prequests);

    }
}
