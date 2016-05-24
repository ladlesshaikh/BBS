using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BBS.Data;
using BBS.Models;
using System.Configuration;
using BBS.BL.Managers;

namespace BBS.UnitTest
{
    [TestClass]
    public class DbCreationTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SetupDb()
        {
            using (var ctx = new DataContext("name=DataContext"))
            {
                var company = new Company
                {
                    AddressDetails = new Address { CityOrTown = "Pune", Email = "test@gmail.com", Fax = "fax Number", PostalCode = "121212", StreetNo = "11212", SubUrb = "asasa", Telephone = "1231212" },
                    Bank = new BankDetail { BranchCode = "branch", Name = "Nedbank" },
                    CKRegNo = "1121212",
                    Name = "TestComapny",
                    Tax = new TaxDetail { TaxNo = "122345", Rate = 14.5 },
                };

                ctx.Companies.Add(company);
                var rowsAffected = ctx.SaveChanges();
                Assert.IsTrue(rowsAffected > 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SetupData()
        {
            var testResult = false;
            using (var manager = new DataConfigurationManager())
            {
                testResult = manager.SetupDataAsync().Result;
            }
            Assert.IsTrue(testResult);
        }
    }
}
