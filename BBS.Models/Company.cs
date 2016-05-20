using System;
using System.Collections.Generic;
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
        public string CompanyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TaxDetailId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("TaxDetailId")]
        public TaxDetail Tax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address AddressDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BankDetail Bank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CKregNo { get; set; }
    }
}
