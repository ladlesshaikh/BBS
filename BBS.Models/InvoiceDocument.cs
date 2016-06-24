using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Models
{
    [Table("InvoiceDocuments")]
    public class InvoiceDocument : ModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        public DateTime DocDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CreditTermsValidityType CreditTermsOrValidity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual PaymentType PaymentBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceDocumentType InvoiceDocumentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual InvoiceBillingType InvoiceBillingType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double PaidAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<InvoiceItem> InvoiceItems { get; set; }
    }



    [Table("CreditTermsValidityTypes")]
    public class CreditTermsValidityType : KeyValueBase
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("InvoiceDocumentTypes")]
    public class InvoiceDocumentType : KeyValueBase
    {

    }

    /// <summary>
    /// 
    /// </summary>
    [Table("PaymentTypes")]
    public class PaymentType : KeyValueBase
    {

    }
}
