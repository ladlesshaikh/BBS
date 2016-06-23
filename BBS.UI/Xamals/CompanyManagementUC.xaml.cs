using Microsoft.Win32;
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
    /// Interaction logic for CompanyManagementUC.xaml
    /// </summary>
    public partial class CompanyManagementUC : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private CompanyViewModel companyViewModel = null;
        /// <summary>
        /// 
        /// </summary>
        public CompanyManagementUC()
        {
            InitializeComponent();
            companyViewModel = new CompanyViewModel();
            mainGrid.DataContext = companyViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnLogoImage_Click(object sender, RoutedEventArgs e)
        {
            var fileDialuge = new OpenFileDialog();

            if (fileDialuge.ShowDialog() == true)
            {
                txtCompanyLogo.Text = fileDialuge.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
                throw new Exception("Unexpected event args");
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    companyViewModel.ErrorCount++;
                    break;
                case ValidationErrorEventAction.Removed:
                    companyViewModel.ErrorCount--;
                    break;
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }
        }
    }
}
