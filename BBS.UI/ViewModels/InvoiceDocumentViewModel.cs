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
        private InvoiceItem selectedInvoiceItem = null;
        /// <summary>
        /// 
        /// </summary>
        private CustomerViewModel customerViewModel = null;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<InvoiceItem> invoiceItems = null;

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
            InitializeInvoiceDocument();
            OnInvoiceItemDescriptionChange = new UserActionOrCommand(OnInvoiceItemDescriptionChangeHandler);
            OnProductSuggestionSelectionChanged = new UserActionOrCommand(OnProductSuggestionSelectionChangedHandler);
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
        public string SelectedInvoiceItemDescription
        {
            get
            {
                var retVal = string.Empty;
                if (null != SelectedInvoiceItem)
                {
                    retVal = SelectedInvoiceItem.Description;
                }
                return retVal;
            }
            set
            {
                if (null != SelectedInvoiceItem)
                {
                    SelectedInvoiceItem.Description = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public InvoiceItem SelectedInvoiceItem
        {
            get
            {
                if (null != selectedInvoiceItem && null == selectedInvoiceItem.InvoiceType)
                {
                    selectedInvoiceItem.Date = DateTime.Now;
                    selectedInvoiceItem.InvoiceType = SelectedInvoiceBillingType;
                }
                return selectedInvoiceItem;
            }
            set
            {
                selectedInvoiceItem = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> ProductCatlauge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> FilteredProductCatlauge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime SelectedDocDate
        {
            get
            {
                return SelectedItem.DocDate;
            }
            set
            {
                SelectedItem.DocDate = value;
                UpdateDocReference();
                NotifyInvoiceReferenceChange();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public InvoiceItemDataGridHeader InvoiceItemDataGridHeaders { get; set; }

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
                NotifyPropertyChanged("SelectedCompany");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public InvoiceDocumentType SelectedInvoiceDocumentType
        {
            get
            {
                return SelectedItem.InvoiceDocumentType;
            }
            set
            {
                SelectedItem.InvoiceDocumentType = value;
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
                NotifyPropertyChanged("SelectedCustomer");
                NotifyPropertyChanged("InvoiceItems");
                NotifySelectedItemChange();
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
                NotifyPropertyChanged("SelectedPaymentType");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Reference
        {
            get
            {
                return SelectedItem.Reference;
            }
            set
            {
                SelectedItem.Reference = value;
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
                PopulateFormOfPaymentOnCreditTermsOrValidityChange();
                NotifyPropertyChanged("SelectedCreditTermsOrValidityType");
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
        public UserActionOrCommand OnInvoiceItemDescriptionChange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserActionOrCommand OnProductSuggestionSelectionChanged { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected override bool CanSave(object parameter)
        {
            return null != SelectedCompany & null != SelectedCustomer;
        }
        #endregion

        #region Private helper methods
        /// <summary>
        /// 
        /// </summary>
        private void PopulateFormOfPaymentOnCreditTermsOrValidityChange()
        {
            switch (SelectedCreditTermsOrValidityType.Key)
            {
                case "cod":
                    SelectedPaymentType = PaymentTypes.FirstOrDefault(i => i.Key == "cash");
                    break;
                default:
                    SelectedPaymentType = PaymentTypes.FirstOrDefault(i => i.Key == "account");
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void NotifySelectedInvoiceItemDescriptionChange()
        {
            NotifyPropertyChanged("SelectedInvoiceItemDescription");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seachText"></param>
        private void PopulatFilteredProductCatlauge(string seachText)
        {
            FilteredProductCatlauge = ProductCatlauge.Where(i => i.StartsWith(seachText, StringComparison.OrdinalIgnoreCase));
            NotifyFilteredProductCatlauge();
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyFilteredProductCatlauge()
        {
            NotifyPropertyChanged("FilteredProductCatlauge");
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyInvoiceReferenceChange()
        {
            NotifyPropertyChanged("Reference");
        }
        /// <summary>
        /// 
        /// </summary>
        private void UpdateDocReference()
        {
            SelectedItem.Reference = (manager as InvoiceDocumentManager).GenerateInvoiceReferenceForDateAsync(SelectedItem.DocDate).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeInvoiceDocument()
        {
            SelectedItem.DocDate = DateTime.Today;
            SelectedInvoiceDocumentType = InvoiceDocumentTypes.FirstOrDefault(i => i.Key == "taxinvoice");
            SelectedInvoiceBillingType = InvoiceBillingTypes.FirstOrDefault(i => i.Key == "quantitybased");
            using (var manager = new ProductManager())
            {
                ProductCatlauge = from i in manager.GetAllAsync().Result select i.Name;
            }
            UpdateDocReference();
        }
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
            SelectedItem.Customer.InvoiceItems = InvoiceItems;
            NotifySelectedItemChange();
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
            ResetInvoiceItemGridToSelectedBillingType();
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
            NotifyPropertyChanged("Customers");
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
            NotifyPropertyChanged("Customers");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void AddCustomerCommandHandler(object param)
        {
            PopulateCustomers();
            DefaultSelectedCustomer();
            NotifyPropertyChanged("Customers");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void OnProductSuggestionSelectionChangedHandler(object param)
        {
            SelectedInvoiceItemDescription = param as string;
            NotifySelectedInvoiceItemDescriptionChange();
            //var existingInvoice = InvoiceItems.FirstOrDefault(i => i.Id == SelectedInvoiceItem.Id);
            //existingInvoice.Description = param as string;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void OnInvoiceItemDescriptionChangeHandler(object param)
        {
            PopulatFilteredProductCatlauge(param as string);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void InvoiceItemAddedUpdatedCommandHandler(object param)
        {
            CalculateInvoiceTotals();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetInvoiceItemGridToSelectedBillingType()
        {
            InvoiceItemDataGridHeaders.IsBillingTypeHourBased = SelectedInvoiceBillingType.IsHourlyBased;
            NotifyPropertyChanged("InvoiceItemDataGridHeaders");
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    //public class InvoiceTotal
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Double SubTotal { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Double Tax { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Double Total
    //    {
    //        get
    //        {
    //            return SubTotal + Tax;
    //        }
    //    }
    //}

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
        public string Quantity { get { return IsBillingTypeHourBased ? hours : quantitiy; } set { } }

        /// <summary>
        /// 
        /// </summary>
        public string Cost { get { return IsBillingTypeHourBased ? ratePerHour : UnitCost; } set { } }
    }
}
