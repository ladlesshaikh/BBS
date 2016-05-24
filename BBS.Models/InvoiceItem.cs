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
    [Table("InvoiceItems")]
    public class InvoiceItem : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double UnitCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceBillingType InvoiceType { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("InvoiceBillingTypes")]
    public class InvoiceBillingType : KeyValueBase
    {

    }
}
