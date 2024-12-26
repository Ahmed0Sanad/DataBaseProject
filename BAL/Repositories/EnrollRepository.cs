using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Migrations;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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
    }
}
