using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public static class MethodExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public static IEnumerable<CompanyReportModel> ToCompanyReportModel(this IEnumerable<Company> dataSource)
        {
            var retVal = new List<CompanyReportModel>();
            foreach (var item in dataSource)
            {
                retVal.Add(new CompanyReportModel
                {
                    City = item.AddressDetails.CityOrTown,
                    CKNo = item.CKRegNo,
                    Email = item.AddressDetails.Email,
                    Fax = item.AddressDetails.Fax,
                    Name = item.Name,
                    PostalCode = item.AddressDetails.PostalCode,
                    Street = item.AddressDetails.StreetNo,
                    SubUrb = item.AddressDetails.SubUrb,
                    TaxNo = item.Tax.TaxNo,
                    Tel = item.AddressDetails.Telephone,
                    LogoImage = item.LogoImage,
                    LogoImageBytes = item.GetLogoImageBytes()
                });
            }
            return retVal;
        }
    }
}
