using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI.ReportModels
{ /// <summary>
  ///  <Customer></Customer>
  /// </summary>
    public class CustomerManagementReportModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DocNumber { get; set; }

        public string Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreditTerms { get; set; }

        public string NoOfItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double AmountDue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double AmountOutstanding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double AmountPaid { get; set; }
    }
}
