﻿using BBS.Data;
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
    public class ProductManager : ManagerBase, IManager<Product>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdateAsync(Product product)
        {
            var retVal = false;
            using (var repository = new ProductRepository())
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
        public async Task<bool> DeleteAsync(Product product)
        {
            var retVal = false;
            using (var repository = new ProductRepository())
            {
                retVal = await repository.DeleteAsync(product);
            }
            return retVal;
        }
    }
}
