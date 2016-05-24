using BBS.Data;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerManager : ManagerBase, IManager<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customer>> GetAllAsync()
        {
            List<Customer> retVal = null;
            using (var repository = new CustomerRepository())
            {
                retVal = await repository.GetAsync();
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdateAsync(Customer product)
        {
            var retVal = false;
            using (var repository = new CustomerRepository())
            {
                retVal = product.Id > 0 ? await repository.UpdateAsync(product) : await repository.InsertAsync(product);
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Customer product)
        {
            var retVal = false;
            using (var repository = new CustomerRepository())
            {
                retVal = await repository.DeleteAsync(product);
            }
            return retVal;
        }
    }
}
