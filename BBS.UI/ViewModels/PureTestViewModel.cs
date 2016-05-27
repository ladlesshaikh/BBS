using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    public class PureTestViewModel
    {
        public PureTestViewModel()
        {
            SecondColumnTitle = "Second title";
            ThirdColumnTitle = "Third title";
            InvoiceItemDataGridHeaders = new InvoiceItemDataGridHeader();
        }

        public InvoiceItemDataGridHeader InvoiceItemDataGridHeaders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecondColumnTitle { get; set; }

        public string ThirdColumnTitle { get; set; }
    }
}
