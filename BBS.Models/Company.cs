using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}
