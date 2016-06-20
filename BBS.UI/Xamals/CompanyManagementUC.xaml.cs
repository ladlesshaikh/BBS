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
        public CompanyManagementUC()
        {
            InitializeComponent();
            mainGrid.DataContext = new CompanyViewModel();
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
    }
}
