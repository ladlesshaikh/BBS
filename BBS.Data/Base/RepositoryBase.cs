using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        DataContext dataContext = null;


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
            var rowsAffected = await dataContext.SaveChangesAsync();
            retVal = rowsAffected > 0;
            return retVal;
        }

        public Task<bool> InsertAsync(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IEnumerable<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
