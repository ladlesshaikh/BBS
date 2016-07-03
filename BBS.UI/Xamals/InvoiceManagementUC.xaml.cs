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
    /// Interaction logic for InvoiceManagementUC.xaml
    /// </summary>
    public partial class InvoiceManagementUC : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private InvoiceDocumentViewModel invoiceDocumentViewModel = null;

        /// <summary>
        /// 
        /// </summary>
        public event InvoiceSaved OnInvoiceSaved = null;

        /// <summary>
        /// /
        /// </summary>
        /// <param name="result"></param>
        public delegate void InvoiceSaved(InvoiceDocument invoice);

        public InvoiceManagementUC()
        {
            InitializeComponent();
            invoiceDocumentViewModel = new InvoiceDocumentViewModel();
            invoiceDocumentViewModel.OnInvoiceSavedOrUpdated += InvoiceDocumentViewModel_OnInvoiceSavedOrUpdated;
            grdInvoiceManagement.DataContext = invoiceDocumentViewModel;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        private void InvoiceDocumentViewModel_OnInvoiceSavedOrUpdated(InvoiceDocument invoice)
        {
            if (null != OnInvoiceSaved)
            {
                OnInvoiceSaved(invoice);
            }
        }
    }
}
