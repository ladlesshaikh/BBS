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
    /// Interaction logic for CustomerManagementUC.xaml
    /// </summary>
    public partial class CustomerManagementUC : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private CustomerViewModel customerViewModel = null;

        public CustomerManagementUC()
        {
            InitializeComponent();
            customerViewModel = new CustomerViewModel();
            mainGrid.DataContext = customerViewModel;
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
                    customerViewModel.ErrorCount++;
                    break;
                case ValidationErrorEventAction.Removed:
                    customerViewModel.ErrorCount--;
                    break;
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }
        }
    }


}
