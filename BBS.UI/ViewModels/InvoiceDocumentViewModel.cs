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
        private InvoiceItemDataGridHeader InvoiceItemDataGridHeaders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private CustomerViewModel customerViewModel = null;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<InvoiceItem> invoiceItems = null;
        ///// <summary>
        ///// 
        ///// </summary>
        //private Company selectedCompany = null;

        ///// <summary>
        ///// 
        ///// </summary>
        //private Customer selectedCustomer = null;

        ///// <summary>
        ///// 
        ///// </summary>
        //private PaymentType selectedPaymentType = null;

        ///// <summary>
        ///// 
        ///// </summary>
        //private CreditTermsValidityType selectedCreditTermsOrValidityType = null;
        #endregion

        #region Object construction
        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocumentViewModel()
            : base(new InvoiceDocumentManager())
        {
            customerViewModel = new CustomerViewModel();
            SelectedItem = new InvoiceDocument();
            InvoiceItemAddedUpdatedCommand = new UserActionOrCommand(InvoiceItemAddedUpdatedCommandHandler);
            DeleteCustomerCommand = new UserActionOrCommand(DeleteCustomerCommandHandler);
            UpdateOrSaveCustomerCommand = new UserActionOrCommand(UpdateOrSaveCustomerCommandHandler);
            AddCustomerCommand = new UserActionOrCommand(AddCustomerCommandHandler);
            InvoiceBillingTypeSelectionChangedCommand = new UserActionOrCommand(InvoiceBillingTypeSelectionChangedCommandHandler);
            InvoiceItemDataGridHeaders = new InvoiceItemDataGridHeader { IsBillingTypeHourBased = false };
            //DefaultSelectedCustomer();
        }
        #endregion

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        public InvoiceBillingType SelectedInvoiceBillingType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Company SelectedCompany
        {
            get { return SelectedItem.Company; }
            set
            {
                SelectedItem.Company = value;
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
                return SelectedItem.Customer;
            }
            set
            {
                SelectedItem.Customer = value;
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
                return SelectedItem.PaymentBy;
            }
            set
            {
                SelectedItem.PaymentBy = value;
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
                return SelectedItem.CreditTermsOrValidity;
            }
            set
            {
                SelectedItem.CreditTermsOrValidity = value;
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
                return invoiceItems ?? (invoiceItems = null == SelectedItem.Customer ? null : new ObservableCollection<InvoiceItem>(SelectedItem.Customer.InvoiceItems ?? new List<InvoiceItem>()));
            }
            set
            {
                SelectedItem.Customer.InvoiceItems = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public InvoiceTotal InvoiceTotals { get; set; }
      
        #endregion

        #region UserActionOrCommands
        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand CreditTermOrValiditySelectionChnagedCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand InvoiceItemAddedUpdatedCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand DeleteCustomerCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand UpdateOrSaveCustomerCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand AddCustomerCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand InvoiceBillingTypeSelectionChangedCommand { get; set; }
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
            InvoiceTotals.Tax = null == SelectedItem.Company ? 0.0 : SelectedItem.Company.Tax.Rate;
            SelectedItem.Customer.InvoiceItems = InvoiceItems;
            RaisePropertyChanged("InvoiceTotals");
        }

        /// <summary>
        /// 
        /// </summary>
        private void DefaultSelectedCustomer()
        {
            SelectedItem.Customer = new Customer { AddressDetails = new Address(), InvoiceItems = new List<InvoiceItem>(), TaxDetails = new TaxDetail() };
        }

        #endregion

        #region Command Hnadlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void InvoiceBillingTypeSelectionChangedCommandHandler(object param)
        {
            int i = 0;
            RaisePropertyChanged("InvoiceItemDataGridHeaders");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void DeleteCustomerCommandHandler(object param)
        {
            customerViewModel.DeleteCommandHandler(param as Customer);
            PopulateCustomers();
            DefaultSelectedCustomer();
            RaisePropertyChanged("Customers");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void UpdateOrSaveCustomerCommandHandler(object param)
        {
            customerViewModel.UpdateCommandHandler(param as Customer);
            PopulateCustomers();
            DefaultSelectedCustomer();
            RaisePropertyChanged("Customers");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void AddCustomerCommandHandler(object param)
        {
            PopulateCustomers();
            DefaultSelectedCustomer();
            RaisePropertyChanged("Customers");
        }

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

    /// <summary>
    /// 
    /// </summary>
    public class InvoiceItemDataGridHeader
    {
        /// <summary>
        /// 
        /// </summary>
        private string quantitiy = "Qty";

        /// <summary>
        /// 
        /// </summary>
        private string UnitCost = "Unit Cost";

        /// <summary>
        /// 
        /// </summary>
        private string hours = "Hour/s";

        /// <summary>
        /// 
        /// </summary>
        private string ratePerHour = "Rate/H";

        public InvoiceItemDataGridHeader()
        {
            Date = "Date";
            Description = "Description";
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBillingTypeHourBased { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Quanitiy { get { return IsBillingTypeHourBased ? hours : quantitiy; } set { } }

        /// <summary>
        /// 
        /// </summary>
        public string Cost { get { return IsBillingTypeHourBased ? ratePerHour : UnitCost; } set { } }
    }
}
