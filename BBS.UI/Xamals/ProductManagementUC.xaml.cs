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
        public ProductManagementUC()
        {
            InitializeComponent();
            dgProduct.DataContext = new ProductViewModel();
        }

        private void dgProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //objEmpToEdit = dgProduct.SelectedItem as Employee;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //isUpdateMode = true;
            //dgProduct.Columns[2].IsReadOnly = false;
            //dgProduct.Columns[3].IsReadOnly = false;
        }

        private void dgProduct_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //if (isUpdateMode) //The Row is edited
            //{
            //    Employee TempEmp = (from emp in objContext.Employee
            //                        where emp.EmpNo == objEmpToEdit.EmpNo
            //                        select emp).First();


            //    FrameworkElement element_1 = dgProduct.Columns[2].GetCellContent(e.Row);
            //    if (element_1.GetType() == typeof(TextBox))
            //    {
            //        var xxSalary = ((TextBox)element_1).Text;
            //        objEmpToEdit.Salary = Convert.ToInt32(xxSalary);
            //    }
            //    FrameworkElement element_2 = dgProduct.Columns[3].GetCellContent(e.Row);
            //    if (element_2.GetType() == typeof(TextBox))
            //    {
            //        var yyDeptNo = ((TextBox)element_2).Text;
            //        objEmpToEdit.DeptNo = Convert.ToInt32(yyDeptNo);
            //    }
            //}

        }

        private void dgProduct_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //objContext.SaveChanges();
            MessageBox.Show("The Current row updation is complete..");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (objEmpToEdit == null)
            //{
            //    MessageBox.Show("Cannot delete the blank Entry");
            //}
            //else
            //{
            //    objContext.DeleteObject(objEmpToEdit);
            //    objContext.SaveChanges();
            //    MessageBox.Show("Record Deleted..");
            //}
        }
    }
}
