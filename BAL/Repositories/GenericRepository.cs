using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public void Add(T entity)
        {
            _appDbContext.Add(entity);
            
        }

        public virtual void Delete(T entity)
        {
            _appDbContext.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return _appDbContext.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _appDbContext.Set<T>().AsNoTracking().ToList();
        }

        public  void  Update(T entity)
        {
            _appDbContext.Update(entity);
        }
    }
}
