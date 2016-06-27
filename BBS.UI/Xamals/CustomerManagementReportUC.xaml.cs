using BBS.UI.ReportModels;
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
    /// Interaction logic for CustomerManagementReportUC.xaml
    /// </summary>
    public partial class CustomerManagementReportUC : UserControl
    {
        private CustomerManagementReportViewModel customerManagementReportModel = null;
        /// <summary>
        /// 
        /// </summary>
        public CustomerManagementReportUC()
        {
            InitializeComponent();
            customerManagementReportModel = new CustomerManagementReportViewModel();
            grdCustomerManagementReport.DataContext = customerManagementReportModel;
            customerManagementReportModel.OnReportSourceUpdated += CustomerManagementReportModel_OnReportSourceUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        private void CustomerManagementReportModel_OnReportSourceUpdated(IEnumerable<CustomerManagementReportModel> dataSource)
        {
            CustomerManagementReport report = new CustomerManagementReport();
            CrystalReportsViewer1.Owner = Window.GetWindow(this);
            report.SetDataSource(dataSource);
            CrystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}
