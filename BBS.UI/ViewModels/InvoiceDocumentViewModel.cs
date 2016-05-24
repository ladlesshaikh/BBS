using BBS.BL;
using BBS.Models;
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
    public class InvoiceDocumentViewModel : ViewModelBase<InvoiceDocument>
    {
        /// <summary>
        /// 
        /// </summary>
        private Company selectedCompany = null;

        /// <summary>
        /// 
        /// </summary>
        private Customer selectedCustomer = null;

        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocumentViewModel()
            : base(new InvoiceDocumentManager())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                selectedCompany = value;
                RaisePropertyChanged("SelectedCompany");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Customer SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Company> Companies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PaymentType> PaymentTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<InvoiceDocumentType> InvoiceDocumentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<InvoiceBillingType> InvoiceBillingTypes { get; set; }

        protected override void PopulateItems()
        {
            SetupOrCreateInvoiceTemplate();
        }

        #region Private helper methods
        private void SetupOrCreateInvoiceTemplate()
        {
            PopulateCompanies();
            PopulateCustomers();
        }
        /// <summary>
        /// 
        /// </summary>
        private void PopulateCompanies()
        {
            using (var manager = new CompanyManager())
            {
                Companies = manager.GetAllAsync().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateCustomers()
        {
            using (var manager = new CustomerManager())
            {
                Customers = manager.GetAllAsync().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulatePaymentTypes()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoiceDocumentTypes()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoiceBillingTypes()
        {

        }
        #endregion
    }
}
