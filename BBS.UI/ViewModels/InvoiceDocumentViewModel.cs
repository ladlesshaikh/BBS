using BBS.BL;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #region Local resoucre declarations
        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<InvoiceItem> invoiceItems = null;
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
        private PaymentType selectedPaymentType = null;

        /// <summary>
        /// 
        /// </summary>
        private CreditTermsValidityType selectedCreditTermsOrValidityType = null;
        #endregion

        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocumentViewModel()
            : base(new InvoiceDocumentManager())
        {
            InvoiceItemAddedUpdatedCommand = new UserActionOrCommand(InvoiceItemAddedUpdatedCommandHandler);
        }
        #endregion

        #region Public properties
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
                RaisePropertyChanged("InvoiceItems");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PaymentType SelectedPaymentType
        {
            get
            {
                return selectedPaymentType;
            }
            set
            {
                selectedPaymentType = value;
                RaisePropertyChanged("SelectedPaymentType");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CreditTermsValidityType SelectedCreditTermsOrValidityType
        {
            get
            {
                return selectedCreditTermsOrValidityType;
            }
            set
            {
                selectedCreditTermsOrValidityType = value;
                RaisePropertyChanged("SelectedCreditTermsOrValidityType");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Company> Companies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Customer> Customers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PaymentType> PaymentTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<InvoiceDocumentType> InvoiceDocumentTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<InvoiceBillingType> InvoiceBillingTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<CreditTermsValidityType> CreditTermsOrValidityTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<InvoiceItem> InvoiceItems
        {
            get
            {
                return invoiceItems ?? (invoiceItems = null == selectedCustomer ? null : new ObservableCollection<InvoiceItem>(selectedCustomer.InvoiceItems ?? new List<InvoiceItem>()));
            }
            set
            {
                selectedCustomer.InvoiceItems = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public InvoiceTotal InvoiceTotals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand InvoiceItemAddedUpdatedCommand { get; set; }
        #endregion

        #region Overrirde methods
        /// <summary>
        /// 
        /// </summary>
        protected override void PopulateItems()
        {
            SetupOrCreateInvoiceTemplate();
        }
        #endregion

        #region Private helper methods
        /// <summary>
        /// 
        /// </summary>
        private void SetupOrCreateInvoiceTemplate()
        {
            PopulateCompanies();
            PopulateCustomers();
            PopulateInvoiceBillingTypes();
            PopulateInvoiceDocumentTypes();
            PopulatePaymentTypes();
            PopulateCreditTermsOrValidityTypes();
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
            using (var manager = new DataConfigurationManager())
            {
                PaymentTypes = manager.GetDataConfigurationAsync<PaymentType>().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoiceDocumentTypes()
        {
            using (var manager = new DataConfigurationManager())
            {
                InvoiceDocumentTypes = manager.GetDataConfigurationAsync<InvoiceDocumentType>().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateInvoiceBillingTypes()
        {
            using (var manager = new DataConfigurationManager())
            {
                InvoiceBillingTypes = manager.GetDataConfigurationAsync<InvoiceBillingType>().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PopulateCreditTermsOrValidityTypes()
        {
            using (var manager = new DataConfigurationManager())
            {
                CreditTermsOrValidityTypes = manager.GetDataConfigurationAsync<CreditTermsValidityType>().Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void CalculateInvoiceTotals()
        {
            InvoiceTotals = new InvoiceTotal();
            InvoiceTotals.SubTotal = InvoiceItems.Sum(i => i.Amount);
            InvoiceTotals.Tax = null == selectedCompany ? 0.0 : selectedCompany.Tax.Rate;
            RaisePropertyChanged("InvoiceTotals");
        }
        #endregion

        #region Command Hnadlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void InvoiceItemAddedUpdatedCommandHandler(object param)
        {
            CalculateInvoiceTotals();
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class InvoiceTotal
    {
        /// <summary>
        /// 
        /// </summary>
        public Double SubTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double Tax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Double Total
        {
            get
            {
                return SubTotal + Tax;
            }
        }
    }
}
