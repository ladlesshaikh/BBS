using BBS.BL;
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
    public class CustomerTest
    {
        [TestMethod]
        public void AddCustomer()
        {
            using (var customer = new CustomerManager())
            {
                var cust = new Customer
                {
                    AddressDetails = new Address
                    {
                        CityOrTown = "Pune",
                        Email = "test@gmail.com",
                        Fax = "Test fax",
                    },
                    Name = "Test",
                    TaxDetails = new TaxDetail { TaxNo = "test tax number" }
                };
                var result = customer.AddOrUpdateAsync(cust).Result;
                Assert.IsTrue(result);
            }
        }
    }
}
