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
}
