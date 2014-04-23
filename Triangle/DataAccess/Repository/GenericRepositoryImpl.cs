using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepositoryImpl<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public GenericRepositoryImpl(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = this.dbContext.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.dbContext.Set<T>().Where(predicate);
            return query;
        }

        public void Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChange()
        {
            this.dbContext.SaveChanges();
        }
    }
}
