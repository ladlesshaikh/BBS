using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BBS.UI.Xamals
{
    /// <summary>
    /// Interaction logic for InvoiceManagementContainer.xaml
    /// </summary>
    public partial class InvoiceManagementContainer : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private InvoiceManagementUC invoiceManagementUC = null;

        /// <summary>
        /// 
        /// </summary>
        public InvoiceManagementContainer()
        {
            InitializeComponent();
            invoiceManagementUC = new InvoiceManagementUC();
            invoiceManagementUC.OnInvoiceSaved += InvoiceManagementUC_OnInvoiceSavedOrUpdated;
            ccInvoiceManagementContainer.Content = invoiceManagementUC;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        private void InvoiceManagementUC_OnInvoiceSavedOrUpdated(InvoiceDocument invoice)
        {
            ccInvoiceManagementContainer.Content = new InvoiceDocumentReportUC(invoice);
        }
    }
}
