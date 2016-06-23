using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepository<T>, IDisposable where T : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected DataContext dataContext = null;


        public RepositoryBase(DataContext dbContext)
        {
            dataContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(T model)
        {
            var retVal = false;
            var entity = dataContext.Set<T>().Add(model);
            var rowsAffected = dataContext.SaveChanges();
            retVal = rowsAffected > 0;
            return retVal;
        }

        public async Task<bool> InsertAsync(List<T> models)
        {
            var retVal = false;
            var entity = dataContext.Set<T>().AddRange(models);
            var rowsAffected = dataContext.SaveChanges();
            retVal = rowsAffected > 0;
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T model)
        {
            var retVal = false;
            dataContext.Entry<T>(model).State = System.Data.Entity.EntityState.Modified;
            var rowsAffected = dataContext.SaveChanges();
            retVal = rowsAffected > 0;
            return retVal;
        }

        public Task<bool> UpdateAsync(List<T> models)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(T model)
        {
            var retVal = false;
            dataContext.Entry<T>(model).State = System.Data.Entity.EntityState.Deleted;
            var rowsAffected = dataContext.SaveChanges();
            retVal = rowsAffected > 0;
            return retVal;
        }

        public Task<bool> DeleteAsync(IEnumerable<T> models)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return null != dataContext.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetAsync()
        {
            return dataContext.Set<T>().ToList();
        }

        public Task<int> ExecuteQueryAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> SelectAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> SelectAsync(params object[] filedsToInclude)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            if (null != dataContext)
            {
                dataContext = null;
            }
        }
    }
}
