using BBS.BL;
using BBS.Models;
using BBS.UI.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerManagementReportViewModel : ViewModelBase<Company>
    {
        /// <summary>
        /// 
        /// </summary>
        public event ReportSourceUpdated OnReportSourceUpdated;

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public delegate void ReportSourceUpdated(IEnumerable<CustomerManagementReportModel> dataSource);

        /// <summary>
        /// 
        /// </summary>
        public CustomerManagementReportViewModel() : base(new CompanyManager())
        {
            StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            EndDate = StartDate.AddMonths(1).AddDays(-1);
            OnGenerateReportCommand = new UserActionOrCommand(OnGenerateReportCommandHandler, CanGenerateReport);
            OnCompanySelectionChanged = new UserActionOrCommand(OnCompanySelectionChangedHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        public Customer SelectedCustomer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand OnCompanySelectionChanged { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand OnGenerateReportCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Customer> Customers { get { return SelectedItem.Customers; } set { } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CanGenerateReport(object parameter)
        {
            return null != SelectedItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        private void OnCompanySelectionChangedHandler(object param)
        {
            NotifySelectedItemChange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        private void OnGenerateReportCommandHandler(object param)
        {
            var customerManagementReportModels = new List<CustomerManagementReportModel>();
            foreach (var item in SelectedItem.Customers)
            {
                customerManagementReportModels.Add(new CustomerManagementReportModel
                {
                    Customer = item.Name
                });
            }
            if (null != OnReportSourceUpdated)
            {
                OnReportSourceUpdated(customerManagementReportModels);
            }
        }
    }

}
