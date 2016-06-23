using BBS.BL;
using BBS.UI.Xamals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace BBS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupData();
        }

        private void menuProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new ProductManagementUC();
        }

        private void menuCompanyManagement_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new CompanyManagementUC();
        }

        private void menuCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new CustomerManagementUC();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPaymentCollection_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new PaymentCollectionUC();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemViewInvoices_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupData()
        {
            var testResult = false;
            using (var manager = new DataConfigurationManager())
            {
                testResult = manager.SetupDataAsync().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new InvoiceManagementUC();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemHome_Click(object sender, RoutedEventArgs e)
        {
            ccParentContainer.Content = new PureTestUC();
        }
    }
}
