using BBS.Data;
using BBS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UnitTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void AddProduct()
        {
            var productId = AddProductToDb();
            Assert.IsTrue(productId > 0);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            var testResult = false;
            var productId = AddProductToDb();
            if (productId > 0)
            {
                using (var repository = new ProductRepository())
                {
                    var existingProduct = repository.FindAsync(i => i.Id == productId).Result;
                    var originalName = existingProduct.Name;
                    existingProduct.Name = "Updated Name";
                    var dbResult = repository.UpdateAsync(existingProduct).Result;
                    testResult = dbResult & (originalName != existingProduct.Name);
                }
            }
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void DeleteProduct()
        {
            var testResult = false;
            using (var repository = new ProductRepository())
            {
                var existingProduct = repository.FindAsync(i => i.Id > 0).Result;
                if (null != existingProduct)
                {
                    testResult = repository.DeleteAsync(existingProduct).Result;
                }
            }
            Assert.IsTrue(testResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int AddProductToDb()
        {
            var product = new Product { Description = "Test product", Name = "Test product name", Value = "Test product value" };
            using (var repository = new ProductRepository())
            {
                var dbresult = repository.InsertAsync(product).Result;
            }
            return product.Id;
        }


    }
}
