using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
