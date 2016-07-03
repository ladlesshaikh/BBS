using BBS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceDocumentReportModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Company CompanyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocument InvoiceDocumentInfo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CompanyReportModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubUrb { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CKNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TaxNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] LogoImageBytes { get; set; }
    }
}
