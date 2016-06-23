using BBS.BL;
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
    /// Interaction logic for ProductManagementUC.xaml
    /// </summary>
    public partial class ProductManagementUC : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private ProductViewModel productViewModel=null;
        /// <summary>
        /// 
        /// </summary>
        public ProductManagementUC()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
            mainGrid.DataContext = productViewModel;
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
                    productViewModel.ErrorCount++;
                    break;
                case ValidationErrorEventAction.Removed:
                    productViewModel.ErrorCount--;
                    break;
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }
        }
    }
}
