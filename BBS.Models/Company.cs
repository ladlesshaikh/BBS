using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Models
{
    [Table("Companies")]
    public class Company : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Company()
        {
            Customers = new List<Customer>();
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual TaxDetail Tax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Address AddressDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual BankDetail Bank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CKRegNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Street { get { return AddressDetails.StreetNo; } }

        /// <summary>
        /// 
        /// </summary>
        public string SubUrb { get { return AddressDetails.SubUrb; } }

        /// <summary>
        /// 
        /// </summary>
        public string City { get { return AddressDetails.CityOrTown; } }

        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get { return AddressDetails.PostalCode; } }

        /// <summary>
        /// 
        /// </summary>
        public string TaxNo { get { return Tax.TaxNo; } }

        /// <summary>
        /// 
        /// </summary>
        public string Tel { get { return AddressDetails.Telephone; } }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get { return AddressDetails.Email; } }

        /// <summary>
        /// 
        /// </summary>
        public string Fax { get { return AddressDetails.Fax; } }

        /// <summary>
        /// 
        /// </summary>
        public string BankName { get { return Bank.Name; } }

        /// <summary>
        /// 
        /// </summary>
        public string BankBranch { get { return Bank.BranchCode; } }
    }
}
