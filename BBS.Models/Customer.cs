﻿using System;
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
    [Table("Customers")]
    public class Customer : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Customer()
        {
            AddressDetails = new Address();
            TaxDetails = new TaxDetail();

        }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Address AddressDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual TaxDetail TaxDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
