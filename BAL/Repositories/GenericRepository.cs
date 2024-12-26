using BAL.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
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


        public virtual void Add(T entity)
        {

            //_appDbContext.Add(entity);
            string tableName = typeof(T).Name + 's';

            // Use reflection to get the property names and values from the entity
            var properties = typeof(T).GetProperties();
         
            var FilteredData = properties.Where(c => c.PropertyType.Name != "ICollection`1" && c.Name != "Id" && c.PropertyType.Name!="Course");
            var columns = string.Join(", ", FilteredData.Select(p => p.Name));
            var values = string.Join(", ", FilteredData.Select(

                p => p.PropertyType.Name == "String" ||
                p.PropertyType.Name == "TimeOnly" ||
                p.PropertyType.Name == "DateOnly" ||
                p.PropertyType.Name == "DateTime" ? $"''{p.GetValue(entity)}''" : $"{p.GetValue(entity)}"));

            // Create the output parameter
            var insertedIdParam = new SqlParameter("@InsertedId", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            // Construct the inline SQL query without declaring @InsertedId
                var query = $@"
                EXEC GenericInsert 
                @TableName = '{tableName}', 
                @Columns = '{columns}', 
                @Values = '{values}', 
                @InsertedId = {insertedIdParam} OUTPUT;";

            // Execute the query and pass the output parameter
            _appDbContext.Database.ExecuteSqlRaw(query,
                new SqlParameter("@TableName", tableName),
                new SqlParameter("@Columns", columns),
                new SqlParameter("@Values", values),
                insertedIdParam);

            // Retrieve the value of the output parameter
            var insertedId = (int)insertedIdParam.Value;

            // Assign the ID to the entity's Id property
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                idProperty.SetValue(entity, insertedId); // entity.Id = inserted;
            }



        }


        public virtual void Delete(T entity)
        {
            string tableName = typeof(T).Name + 's';
            var quary = $"Exec GenericDelete {tableName} , {entity.Id}";
            _appDbContext.Database.ExecuteSqlRaw(quary);
            //_appDbContext.Remove(entity);
        }

        public virtual T Get(int id)
        {
            string tableName = typeof(T).Name + 's';

            var entity = _appDbContext.Set<T>().FromSqlRaw("Exec GenericGet @TableName,@Id", new SqlParameter("@TableName", tableName), new SqlParameter("@Id", id)).AsEnumerable().FirstOrDefault();
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            string tableName = typeof(T).Name + 's';

            var entitys = _appDbContext.Set<T>().FromSqlRaw("Exec GeneicGetAll @TableName", new SqlParameter("@TableName", tableName)).AsEnumerable().ToList();
            return entitys;
        }

        public virtual void  Update(T entity)
        {
           
            string tableName = typeof(T).Name + 's';

            // Use reflection to get the property names and values from the entity
            var properties = typeof(T).GetProperties();
            var temp = properties[3].PropertyType.Name;
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
            string whereClause = "Id = " + entity.Id;

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
    }
}
