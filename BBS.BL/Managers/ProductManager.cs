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
    public class ProductManager : ManagerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> retVal = null;
            using (var repository = new ProductRepository())
            {
                retVal = await repository.GetAsync();
            }
            return retVal;
        }
    }
}
