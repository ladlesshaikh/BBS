using BBS.BL;
using BBS.Models;
using BBS.UI.Reports;
using CrystalDecisions.CrystalReports.Engine;
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
    /// Interaction logic for InvoiceDocumentReportUC.xaml
    /// </summary>
    public partial class InvoiceDocumentReportUC : UserControl
    {
        /// <summary>
        /// /
        /// </summary>
        private InvoiceDocument invoiceDocumentToRender = null;

        /// <summary>
        /// 
        /// </summary>
        private InvoiceDocumentReportUC()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceDocument"></param>
        public InvoiceDocumentReportUC(InvoiceDocument invoiceDocument) : this()
        {
            invoiceDocumentToRender = invoiceDocument;
            PopulateInvoiceDocumentReport();
        }
        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoiceDocumentReport()
        {
            ReportDocument report = new InvoiceDocumentReport();
            // CrystalReportsViewer1.Owner = Window.GetWindow(this);
            var company = new List<Company> { invoiceDocumentToRender.Customer.Company };
            report.Database.Tables[0].SetDataSource(company.ToCompanyReportModel());
            report.Database.Tables[1].SetDataSource(new List<Customer> { invoiceDocumentToRender.Customer });
            report.Database.Tables[2].SetDataSource(new List<InvoiceDocument> { invoiceDocumentToRender });
            report.Database.Tables[3].SetDataSource(invoiceDocumentToRender.InvoiceItems);
            CrystalReportsViewer1.ViewerCore.ReportSource = report;
        }

        private void bttnViewReport_Click(object sender, RoutedEventArgs e)
        {
            //PopulateInvoiceDocumentReport();

        }
    }

}
