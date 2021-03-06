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
    [Table("InvoiceItems")]
    public class InvoiceItem : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public InvoiceItem()
        {
            Date = DateTime.Today;
        }
        /// <summary>
        /// 
        /// </summary>
        private Decimal quantity = 1;

        /// <summary>
        /// 
        /// </summary>
        private Decimal unitCost = 0;

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
        public Decimal Quantity { get { return quantity; } set { quantity = value; UpdateAmount(); } }

        /// <summary>
        /// 
        /// </summary>
        public Decimal UnitCost { get { return unitCost; } set { unitCost = value; UpdateAmount(); } }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public Decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceDocument InvoiceDocument { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public bool IsHourlyBased
        {
            get
            {
                return Key == "hourlybased";
            }
        }
    }
}
