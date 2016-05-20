using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Address")]
    public class Address : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string StreetNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubUrb { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CityOrTown { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }
    }
}
