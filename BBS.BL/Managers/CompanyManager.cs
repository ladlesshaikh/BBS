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
    public class CompanyManager : ManagerBase, IManager<Company>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllAsync()
        {
            List<Company> retVal = null;
            using (var repository = new CompanyRepository())
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
        public async Task<bool> AddOrUpdateAsync(Company product)
        {
            var retVal = false;
            using (var repository = new CompanyRepository())
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
        public async Task<bool> DeleteAsync(Company product)
        {
            var retVal = false;
            using (var repository = new CompanyRepository())
            {
                retVal = await repository.DeleteAsync(product);
            }
            return retVal;
        }
    }
}
