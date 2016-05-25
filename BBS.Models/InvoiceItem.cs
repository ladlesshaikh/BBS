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
        private Double quantity = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private Double unitCost = 0.0;

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
        public Double Quantity { get { return quantity; } set { quantity = value; UpdateAmount(); } }

        /// <summary>
        /// 
        /// </summary>
        public Double UnitCost { get { return unitCost; } set { unitCost = value; UpdateAmount(); } }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public Double Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceBillingType InvoiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateAmount()
        {
            Amount = Quantity * UnitCost;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("InvoiceBillingTypes")]
    public class InvoiceBillingType : KeyValueBase
    {

    }
}
